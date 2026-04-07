extern alias bc26;
using bc26::Org.BouncyCastle.Crypto;
using bc26::Org.BouncyCastle.Crypto.Digests;
using bc26::Org.BouncyCastle.Crypto.Engines;
using bc26::Org.BouncyCastle.Crypto.Generators;
using bc26::Org.BouncyCastle.Crypto.Modes;
using bc26::Org.BouncyCastle.Crypto.Parameters;
using bc26::Org.BouncyCastle.Crypto.Prng;
using bc26::Org.BouncyCastle.Math.EC.Rfc7748;
using bc26::Org.BouncyCastle.Security;
using Substrate.NetApi.Extensions;
using System.Security.Cryptography;

namespace PlutoFrameworkCore.AssetDidComm
{
    public record X25519KeyPair
    {
        public required byte[] PublicKey { get; init; }
        public required byte[] PrivateKey { get; init; }
    }

    public class X25519Model
    {
        public static X25519KeyPair GenerateX25519KeyPair()
        {
            var rng = new byte[32].Populate();

            var sk = new X25519PrivateKeyParameters(rng);
            var pk = sk.GeneratePublicKey();

            return new X25519KeyPair
            {
                PublicKey = pk.GetEncoded(),
                PrivateKey = sk.GetEncoded(),
            };
        }

        /*public static Key ToKey(byte[] privateKey) => Key.Import(KeyAgreementAlgorithm.X25519, privateKey, KeyBlobFormat.RawPrivateKey, new KeyCreationParameters
        {
            ExportPolicy = KeyExportPolicies.AllowPlaintextExport
        });
        */

        public static byte[] Encrypt(ReadOnlySpan<byte> recipientPublicKeyRaw,
                                 ReadOnlySpan<byte> plaintext,
                                 ReadOnlySpan<byte> aad = default)
        {
            if (recipientPublicKeyRaw.Length != 32)
                throw new ArgumentException("recipientPublicKeyRaw must be 32 bytes.", nameof(recipientPublicKeyRaw));

            var rng = new SecureRandom(new CryptoApiRandomGenerator());

            // 1) Ephemeral keypair
            var ephSk = new byte[32];
            X25519.GeneratePrivateKey(rng, ephSk);
            var ephPk = new byte[32];
            X25519.GeneratePublicKey(ephSk, 0, ephPk, 0);

            // 2) ECDH shared secret
            var shared = new byte[32];
            X25519.ScalarMult(ephSk, 0, recipientPublicKeyRaw.ToArray(), 0, shared, 0);

            // 3) HKDF-SHA256 -> AES-256 key (32 bytes)
            var info = KdfInfo(ephPk, recipientPublicKeyRaw.ToArray()); // domain sep + sorted pubs
            var key = HkdfSha256(shared, salt: null, info: info, len: 32);

            // 4) AEAD encrypt (AES-GCM, 12-byte nonce)
            var nonce = new byte[12].Populate();
            var ctTag = AesGcmEncrypt(key, nonce, plaintext.ToArray(), aad);

            // 5) Assemble blob
            var blob = new byte[32 + 12 + ctTag.Length];
            Buffer.BlockCopy(ephPk, 0, blob, 0, 32);
            Buffer.BlockCopy(nonce, 0, blob, 32, 12);
            Buffer.BlockCopy(ctTag, 0, blob, 44, ctTag.Length);

            CryptoZero(shared);
            CryptoZero(ephSk);
            return blob;
        }

        public static byte[] Decrypt(byte[] recipientSk, ReadOnlySpan<byte> blob, ReadOnlySpan<byte> aad = default)
        {
            if (recipientSk == null || recipientSk.Length != 32)
                throw new ArgumentException("recipientSk must be 32 bytes.", nameof(recipientSk));
            if (blob.Length < 32 + 12 + 16)
                throw new ArgumentException("blob too short.", nameof(blob));

            // Parse blob
            var ephPub = blob.Slice(0, 32).ToArray();
            var nonce = blob.Slice(32, 12).ToArray();
            var ctTag = blob.Slice(44).ToArray();

            // ECDH shared secret
            var shared = new byte[32];
            X25519.ScalarMult(recipientSk, 0, ephPub, 0, shared, 0);

            // KDF to AES-256 key
            var selfPub = new byte[32];
            X25519.GeneratePublicKey(recipientSk, 0, selfPub, 0);
            var key = HkdfSha256(shared, salt: null, info: KdfInfo(ephPub, selfPub), len: 32);

            // AEAD decrypt
            try
            {
                var pt = AesGcmDecrypt(key, nonce, ctTag, aad);
                CryptoZero(shared);
                return pt;
            }
            catch (InvalidCipherTextException ex)
            {
                CryptoZero(shared);
                throw new CryptographicException("Authentication failed (bad key/nonce/AAD or corrupted blob).", ex);
            }
        }

        private static byte[] HkdfSha256(byte[] ikm, byte[]? salt, byte[] info, int len)
        {
            var hkdf = new HkdfBytesGenerator(new Sha256Digest());
            hkdf.Init(new HkdfParameters(ikm, salt, info));
            var okm = new byte[len];
            hkdf.GenerateBytes(okm, 0, len);
            return okm;
        }

        private static byte[] AesGcmEncrypt(byte[] key, byte[] nonce, byte[] plaintext, ReadOnlySpan<byte> aad)
        {
            var gcm = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), 128, nonce, aad.ToArray());
            gcm.Init(true, parameters);

            var outBuf = new byte[gcm.GetOutputSize(plaintext.Length)];
            var off = gcm.ProcessBytes(plaintext, 0, plaintext.Length, outBuf, 0);
            off += gcm.DoFinal(outBuf, off);
            return Trim(outBuf, off);
        }

        private static byte[] AesGcmDecrypt(byte[] key, byte[] nonce, byte[] ciphertextAndTag, ReadOnlySpan<byte> aad)
        {
            var gcm = new GcmBlockCipher(new AesEngine());
            var parameters = new AeadParameters(new KeyParameter(key), 128, nonce, aad.ToArray());
            gcm.Init(false, parameters);

            var outBuf = new byte[gcm.GetOutputSize(ciphertextAndTag.Length)];
            var off = gcm.ProcessBytes(ciphertextAndTag, 0, ciphertextAndTag.Length, outBuf, 0);
            off += gcm.DoFinal(outBuf, off);
            return Trim(outBuf, off);
        }

        private static byte[] KdfInfo(byte[] pubA, byte[] pubB)
        {
            // Domain separation and symmetric ordering of pubkeys
            var label = System.Text.Encoding.ASCII.GetBytes("X25519Box|AES-GCM|HKDF-SHA256|v1");
            bool aFirst = ByteArrayCompare(pubA, pubB) <= 0;
            var min = aFirst ? pubA : pubB;
            var max = aFirst ? pubB : pubA;

            var info = new byte[label.Length + min.Length + max.Length];
            Buffer.BlockCopy(label, 0, info, 0, label.Length);
            Buffer.BlockCopy(min, 0, info, label.Length, min.Length);
            Buffer.BlockCopy(max, 0, info, label.Length + min.Length, max.Length);
            return info;
        }

        private static int ByteArrayCompare(byte[] a, byte[] b)
        {
            int len = Math.Min(a.Length, b.Length);
            for (int i = 0; i < len; i++)
            {
                int d = a[i].CompareTo(b[i]);
                if (d != 0) return d;
            }
            return a.Length.CompareTo(b.Length);
        }

        private static byte[] Trim(byte[] buf, int len)
        {
            if (len == buf.Length) return buf;
            var outBuf = new byte[len];
            Buffer.BlockCopy(buf, 0, outBuf, 0, len);
            return outBuf;
        }

        private static void CryptoZero(byte[] b)
        {
            if (b == null) return;
            for (int i = 0; i < b.Length; i++) b[i] = 0;
        }
    }
}
