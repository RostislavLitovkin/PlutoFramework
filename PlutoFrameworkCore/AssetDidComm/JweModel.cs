using NSec.Cryptography;
using Org.BouncyCastle.Crypto.Agreement.Kdf;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Substrate.NetApi.Extensions;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using AesGcm = Jose.AesGcm;

namespace PlutoFrameworkCore.AssetDidComm
{
    public class JweModel
    {
        public static string Encrypt(byte[] plaintext, IEnumerable<byte[]> recipientKeys)
        {
            // Generate a random CEK for A256GCM (32 bytes)
            var cek = new byte[32].Populate();

            var protectedHeaderJson = JsonSerializer.Serialize(new Dictionary<string, object>
            {
                { "enc", "A256GCM" },
                { "alg", "ECDH-ES+A256KW" }
            });

            var protectedB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(protectedHeaderJson));
            var aad = Encoding.ASCII.GetBytes(protectedB64); // AAD is the base64url(protected)

            // Encrypt plaintext with AES-GCM (A256GCM): produce iv, ciphertext, tag
            byte[] iv = new byte[12].Populate();

            var encrypted = AesGcm.Encrypt(cek, iv, aad, plaintext);

            var cipher = encrypted[0];
            var tag = encrypted[1];

            // For each recipient:
            //    - generate ephemeral X25519 keypair
            //    - Z = ECDH(ephemeralSk, recipientPk)
            //    - KEK = ConcatKdf(SHA-256, Z, "A256KW", apu, apv, 256)
            //    - encrypted_key = AES-KW(KEK, CEK)
            //    - header per recipient includes alg, kid (opt), epk (OKP), apu/apv when provided
            var recipientsArray = new List<object>();
            foreach (var recipientKey in recipientKeys)
            {
                // Ephemeral X25519 keypair for this recipient
                using var eph = Key.Create(
                    KeyAgreementAlgorithm.X25519,
                    new KeyCreationParameters { ExportPolicy = KeyExportPolicies.AllowPlaintextExport });

                var epkPub = eph.PublicKey.Export(KeyBlobFormat.RawPublicKey); // 32 bytes

                // Import recipient's public key
                var recipPub = PublicKey.Import(
                    KeyAgreementAlgorithm.X25519,
                    recipientKey,
                    KeyBlobFormat.RawPublicKey);

                // ECDH -> Z (32 bytes)
                using var z = KeyAgreementAlgorithm.X25519.Agree(eph, recipPub, new SharedSecretCreationParameters
                {
                    ExportPolicy = KeyExportPolicies.AllowPlaintextExport
                });
                var zBytes = z.Export(SharedSecretBlobFormat.RawSharedSecret); // 32 bytes

                // Concat KDF (SHA-256) to derive KEK for A256KW (256-bit)
                byte[] otherInfo = BuildOtherInfo(alg: "A256KW", apu: null, apv: null, keyDataLenBits: 256);
                var kdf = new ConcatenationKdfGenerator(new Sha256Digest());
                kdf.Init(new KdfParameters(zBytes, otherInfo));

                var kek = new byte[32]; // 256-bit KEK
                kdf.GenerateBytes(kek, 0, kek.Length);

                // Wrap CEK with KEK using AES Key Wrap (RFC3394)
                var wrap = new Rfc3394WrapEngine(new AesEngine());
                wrap.Init(true, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(kek));

                var encryptedKey = wrap.Wrap(cek, 0, cek.Length);

                // Per-recipient header: 'alg' and sender's ephemeral public key (OKP/X25519)
                recipientsArray.Add(new Dictionary<string, object>
                {
                    ["header"] = new Dictionary<string, object>
                    {
                        ["alg"] = "ECDH-ES+A256KW",
                        ["epk"] = new Dictionary<string, object>
                        {
                            ["kty"] = "OKP",
                            ["crv"] = "X25519",
                            ["x"] = Convert.ToBase64String(epkPub)
                        }
                    },
                    ["encrypted_key"] = Convert.ToBase64String(encryptedKey),
                });
            }

            // Build final JWE JSON (general serialization)
            var jwe = new Dictionary<string, object>
            {
                ["protected"] = protectedB64,
                ["iv"] = Convert.ToBase64String(iv),
                ["ciphertext"] = Convert.ToBase64String(cipher),
                ["tag"] = Convert.ToBase64String(tag),
                ["recipients"] = recipientsArray
            };

            var json = JsonSerializer.Serialize(jwe, new JsonSerializerOptions { WriteIndented = false });

            Console.WriteLine(json);

            return json;
        }

        /// <summary>
        /// Decrypts a JWE (general JSON serialization) produced by CreateForRecipients using
        /// the recipient's X25519 key pair. Tries each "recipients[i]" entry until unwrap succeeds.
        /// </summary>
        /// <param name="jweJson">JSON string returned by CreateForRecipients</param>
        /// <param name="recipientPublicKey">Recipient's raw 32-byte X25519 public key</param>
        /// <param name="recipientPrivateKey">Recipient's raw 32-byte X25519 private key</param>
        /// <returns>UTF-8 plaintext</returns>
        public static string DecryptForRecipient(string jweJson, byte[] recipientPublicKey, Key recipientSecretKey)
        {
            using var doc = JsonDocument.Parse(jweJson);
            var root = doc.RootElement;

            // Extract core JWE parts
            var protectedB64 = root.GetProperty("protected").GetString()!;
            var iv = Convert.FromBase64String(root.GetProperty("iv").GetString()!);
            var ciphertext = Convert.FromBase64String(root.GetProperty("ciphertext").GetString()!);
            var tag = Convert.FromBase64String(root.GetProperty("tag").GetString()!);
            var recipients = root.GetProperty("recipients");

            // AAD is the ASCII of the base64url(protected)
            var aad = Encoding.ASCII.GetBytes(protectedB64);

            // Validate enc from protected header
            var protectedJson = Encoding.UTF8.GetString(Convert.FromBase64String(protectedB64));
            using (var ph = JsonDocument.Parse(protectedJson))
            {
                if (!ph.RootElement.TryGetProperty("enc", out var encEl) || encEl.GetString() != "A256GCM")
                    throw new NotSupportedException("Only enc=A256GCM is supported by this decryptor.");
            }

            byte[]? cek = null;

            // Try each recipient entry
            foreach (var rec in recipients.EnumerateArray())
            {
                var header = rec.GetProperty("header");

                // Only handle ECDH-ES+A256KW
                if (!header.TryGetProperty("alg", out var algEl) ||
                    algEl.GetString() != "ECDH-ES+A256KW")
                {
                    continue;
                }

                // epk (sender's ephemeral X25519 public key)
                var epk = header.GetProperty("epk");
                if (epk.GetProperty("kty").GetString() != "OKP") continue;
                if (epk.GetProperty("crv").GetString() != "X25519") continue;

                var epkX = Convert.FromBase64String(epk.GetProperty("x").GetString()!);

                // Optional apu/apv (base64url in JOSE)
                byte[]? apu = header.TryGetProperty("apu", out var apuEl)
                    ? Convert.FromBase64String(apuEl.GetString()!) : null;
                byte[]? apv = header.TryGetProperty("apv", out var apvEl)
                    ? Convert.FromBase64String(apvEl.GetString()!) : null;

                // ECDH -> Z using recipient's private key & sender's epk
                var senderEpk = PublicKey.Import(KeyAgreementAlgorithm.X25519, epkX, KeyBlobFormat.RawPublicKey);
                using var z = KeyAgreementAlgorithm.X25519.Agree(
                    recipientSecretKey,
                    senderEpk,
                    new SharedSecretCreationParameters { ExportPolicy = KeyExportPolicies.AllowPlaintextExport });

                var zBytes = z.Export(SharedSecretBlobFormat.RawSharedSecret); // 32 bytes

                // Concat KDF -> KEK (256 bits for A256KW)
                var otherInfo = BuildOtherInfo("A256KW", apu, apv, 256);
                var kdf = new ConcatenationKdfGenerator(new Sha256Digest());
                kdf.Init(new KdfParameters(zBytes, otherInfo));

                var kek = new byte[32];
                kdf.GenerateBytes(kek, 0, kek.Length);

                // AES-KW unwrap CEK
                var encryptedKey = Convert.FromBase64String(rec.GetProperty("encrypted_key").GetString()!);

                byte[] cekCandidate;

                var wrap = new Rfc3394WrapEngine(new AesEngine());
                wrap.Init(false, new Org.BouncyCastle.Crypto.Parameters.KeyParameter(kek));
                try
                {
                    cekCandidate = wrap.Unwrap(encryptedKey, 0, encryptedKey.Length);
                }
                catch (Org.BouncyCastle.Crypto.InvalidCipherTextException)
                {
                    // Try next recipient
                    continue;
                }

                // If your 'enc' is A256GCM, CEK must be 32 bytes; adjust if you support others.
                if (cekCandidate is { Length: 32 })
                {
                    cek = cekCandidate;
                    break; // success for this recipient
                }

            }

            if (cek is null)
                throw new CryptographicException("No matching recipient entry could unwrap the CEK.");

            var decrypted = AesGcm.Decrypt(cek, iv, aad, ciphertext, tag);

            return Encoding.UTF8.GetString(decrypted);
        }

        static byte[] BuildOtherInfo(string alg, byte[]? apu, byte[]? apv, int keyDataLenBits)
        {
            // OtherInfo = AlgorithmID || PartyUInfo || PartyVInfo || SuppPubInfo || SuppPrivInfo
            // Each of AlgorithmID/PartyUInfo/PartyVInfo = 4-byte big-endian length || value
            static byte[] LenPref(byte[]? data)
            {
                data ??= Array.Empty<byte>();
                var len = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(data.Length));
                var pref = new byte[4 + data.Length];
                Buffer.BlockCopy(len, 0, pref, 0, 4);
                if (data.Length > 0) Buffer.BlockCopy(data, 0, pref, 4, data.Length);
                return pref;
            }

            byte[] algId = LenPref(System.Text.Encoding.UTF8.GetBytes(alg));
            byte[] partyU = LenPref(apu);
            byte[] partyV = LenPref(apv);

            // SuppPubInfo = 4-byte big-endian of keyDataLen in **bits**
            byte[] suppPubInfo = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(keyDataLenBits));

            var otherInfo = new byte[algId.Length + partyU.Length + partyV.Length + suppPubInfo.Length];
            int off = 0;
            Buffer.BlockCopy(algId, 0, otherInfo, off, algId.Length); off += algId.Length;
            Buffer.BlockCopy(partyU, 0, otherInfo, off, partyU.Length); off += partyU.Length;
            Buffer.BlockCopy(partyV, 0, otherInfo, off, partyV.Length); off += partyV.Length;
            Buffer.BlockCopy(suppPubInfo, 0, otherInfo, off, suppPubInfo.Length);
            return otherInfo;
        }
    }
}
