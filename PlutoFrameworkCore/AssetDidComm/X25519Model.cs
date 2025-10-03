using NSec.Cryptography;
using System.Security.Cryptography;
using System.Text;

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
            var key = new Key(KeyAgreementAlgorithm.X25519, new KeyCreationParameters
            {
                ExportPolicy = KeyExportPolicies.AllowPlaintextExport
            });

            byte[] sk = key.Export(KeyBlobFormat.RawPrivateKey);
            byte[] pk = key.PublicKey.Export(KeyBlobFormat.RawPublicKey);

            return new X25519KeyPair
            {
                PublicKey = pk,
                PrivateKey = sk
            };
        }

        public static Key ToKey(byte[] privateKey) => Key.Import(KeyAgreementAlgorithm.X25519, privateKey, KeyBlobFormat.RawPrivateKey, new KeyCreationParameters
        {
            ExportPolicy = KeyExportPolicies.AllowPlaintextExport
        });


        public static byte[] Encrypt(ReadOnlySpan<byte> recipientPublicKeyRaw, ReadOnlySpan<byte> plaintext, ReadOnlySpan<byte> aad = default)
        {
            var kem = KeyAgreementAlgorithm.X25519;
            var aead = AeadAlgorithm.XChaCha20Poly1305;

            // 1) Import recipient public key (raw 32-byte)
            var recipientPk = PublicKey.Import(kem, recipientPublicKeyRaw, KeyBlobFormat.RawPublicKey);

            // 2) Create ephemeral X25519 key pair
            using var ephSk = Key.Create(kem);

            // 3) ECDH -> SharedSecret
            using var shared = kem.Agree(ephSk, recipientPk);

            // 4) Derive an AEAD key from the shared secret with HKDF
            //    We include both public keys as "info" to bind context.
            var info = BuildInfo(ephSk.PublicKey, recipientPk);
            Span<byte> salt = stackalloc byte[16];
            RandomNumberGenerator.Fill(salt); // include salt in message
            using var encKey = KeyDerivationAlgorithm.HkdfSha256.DeriveKey(
                shared,
                salt,           // salt
                info,           // info/context
                aead            // derives a Key usable by this AEAD
            );

            // 5) Nonce and encrypt
            var nonce = new byte[aead.NonceSize];          // 24 bytes for XChaCha20-Poly1305
            RandomNumberGenerator.Fill(nonce);
            var ciphertext = aead.Encrypt(encKey, nonce, aad, plaintext);

            // 6) Build output blob
            var ephPkRaw = ephSk.PublicKey.Export(KeyBlobFormat.RawPublicKey);
            var result = new byte[1 + ephPkRaw.Length + salt.Length + nonce.Length + ciphertext.Length];
            int o = 0;
            result[o++] = 0x01; // version
            Buffer.BlockCopy(ephPkRaw, 0, result, o, ephPkRaw.Length); o += ephPkRaw.Length;
            Buffer.BlockCopy(salt.ToArray(), 0, result, o, salt.Length); o += salt.Length;
            Buffer.BlockCopy(nonce, 0, result, o, nonce.Length); o += nonce.Length;
            Buffer.BlockCopy(ciphertext, 0, result, o, ciphertext.Length);
            return result;
        }

        public static byte[] Decrypt(byte[] recipientSk, ReadOnlySpan<byte> blob, ReadOnlySpan<byte> aad = default)
        {
            return Decrypt(ToKey(recipientSk), blob, aad);
        }

        // Decrypts with recipient's X25519 private key (Key) from blob created above
        public static byte[] Decrypt(Key recipientSk, ReadOnlySpan<byte> blob, ReadOnlySpan<byte> aad = default)
        {
            var kem = KeyAgreementAlgorithm.X25519;
            var aead = AeadAlgorithm.XChaCha20Poly1305;

            int o = 0;
            if (blob[o++] != 0x01) throw new CryptographicException("Unsupported version.");

            // parse eph pk, salt, nonce, ciphertext
            var ephPkRaw = blob.Slice(o, 32).ToArray(); o += 32;
            var salt = blob.Slice(o, 16).ToArray(); o += 16;
            var nonce = blob.Slice(o, aead.NonceSize).ToArray(); o += aead.NonceSize;
            var ciphertext = blob.Slice(o).ToArray();

            var ephPk = PublicKey.Import(kem, ephPkRaw, KeyBlobFormat.RawPublicKey);

            // ECDH -> SharedSecret
            using var shared = kem.Agree(recipientSk, ephPk);

            // Rebuild the same HKDF "info"
            var info = BuildInfo(ephPk, recipientSk.PublicKey);

            using var decKey = KeyDerivationAlgorithm.HkdfSha256.DeriveKey(shared, salt, info, aead);
            return aead.Decrypt(decKey, nonce, aad, ciphertext) ?? throw new CryptographicException("Decryption failed.");
        }

        private static byte[] BuildInfo(PublicKey ephPk, PublicKey recPk)
        {
            var label = Encoding.ASCII.GetBytes("NSec-X25519-SealedBox-v1");
            var e = ephPk.Export(KeyBlobFormat.RawPublicKey);
            var r = recPk.Export(KeyBlobFormat.RawPublicKey);
            var info = new byte[label.Length + e.Length + r.Length];
            Buffer.BlockCopy(label, 0, info, 0, label.Length);
            Buffer.BlockCopy(e, 0, info, label.Length, e.Length);
            Buffer.BlockCopy(r, 0, info, label.Length + e.Length, r.Length);
            return info;
        }
    }
}
