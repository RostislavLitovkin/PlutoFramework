using NSec.Cryptography;
using PlutoFrameworkCore.AssetDidComm;
using System.Security.Cryptography;
using System.Text;

namespace PlutoFrameworkTests
{
    internal class X25519ModelTests
    {
        private static (Key sk, byte[] pkRaw) GenerateRecipientKeypair()
        {
            var kem = KeyAgreementAlgorithm.X25519;
            var sk = Key.Create(kem, new KeyCreationParameters { ExportPolicy = KeyExportPolicies.AllowPlaintextExport });
            var pkRaw = sk.PublicKey.Export(KeyBlobFormat.RawPublicKey);
            return (sk, pkRaw);
        }

        [Test]
        public void EncryptDecrypt_RoundTrip_Works()
        {
            var (recipientSk, recipientPkRaw) = GenerateRecipientKeypair();

            var plaintext = Encoding.UTF8.GetBytes("hello sealed world");
            var aad = Encoding.UTF8.GetBytes("context-info");

            var blob = X25519Model.Encrypt(recipientPkRaw, plaintext, aad);
            var recovered = X25519Model.Decrypt(recipientSk, blob, aad);

            Assert.That(recovered, Is.EqualTo(plaintext));

            Console.WriteLine(Encoding.UTF8.GetString(recovered));
        }

        [Test]
        public void EncryptProducesDifferentCiphertexts_ForSameInputs()
        {
            var (recipientSk, recipientPkRaw) = GenerateRecipientKeypair();

            var plaintext = Encoding.UTF8.GetBytes("same message");
            var aad = Encoding.UTF8.GetBytes("same aad");

            var blob1 = X25519Model.Encrypt(recipientPkRaw, plaintext, aad);
            var blob2 = X25519Model.Encrypt(recipientPkRaw, plaintext, aad);

            // With random salt + nonce + ephemeral key, blobs should virtually always differ
            Assert.That(blob1, Is.Not.EqualTo(blob2), "Ciphertexts should be nondeterministic.");
            // Both should still decrypt
            Assert.That(X25519Model.Decrypt(recipientSk, blob1, aad), Is.EqualTo(plaintext));
            Assert.That(X25519Model.Decrypt(recipientSk, blob2, aad), Is.EqualTo(plaintext));
        }

        [Test]
        public void Decrypt_WithWrongAAD_Fails()
        {
            var (recipientSk, recipientPkRaw) = GenerateRecipientKeypair();

            var plaintext = Encoding.UTF8.GetBytes("bind me to AAD");
            var aad = Encoding.UTF8.GetBytes("correct-aad");
            var wrongAad = Encoding.UTF8.GetBytes("wrong-aad");

            var blob = X25519Model.Encrypt(recipientPkRaw, plaintext, aad);

            Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(recipientSk, blob, wrongAad);
            });
        }

        [Test]
        public void Decrypt_WithWrongPrivateKey_Fails()
        {
            var (_, recipientPkRaw) = GenerateRecipientKeypair();
            var (wrongSk, _) = GenerateRecipientKeypair();

            var plaintext = Encoding.UTF8.GetBytes("secret for the right key");

            var blob = X25519Model.Encrypt(recipientPkRaw, plaintext);

            Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(wrongSk, blob);
            });
        }

        [Test]
        public void Tampering_CausesDecryptionFailure()
        {
            var (recipientSk, recipientPkRaw) = GenerateRecipientKeypair();

            var plaintext = Encoding.UTF8.GetBytes("flip a bit and fail");
            var blob = X25519Model.Encrypt(recipientPkRaw, plaintext);

            // Flip a bit in the ciphertext tail
            var tampered = (byte[])blob.Clone();
            tampered[^1] ^= 0x01;

            Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(recipientSk, tampered);
            });
        }

        [Test]
        public void WrongVersion_Throws()
        {
            var (recipientSk, recipientPkRaw) = GenerateRecipientKeypair();
            var blob = X25519Model.Encrypt(recipientPkRaw, new byte[] { 1, 2, 3 });

            var bad = (byte[])blob.Clone();
            bad[0] = 0x02; // unsupported version

            var ex = Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(recipientSk, bad);
            });

            StringAssert.Contains("Unsupported version", ex!.Message);
        }

        [Test]
        public void EmptyPlaintext_RoundTrip_Works()
        {
            var (recipientSk, recipientPkRaw) = GenerateRecipientKeypair();
            var empty = Array.Empty<byte>();
            var blob = X25519Model.Encrypt(recipientPkRaw, empty);
            var recovered = X25519Model.Decrypt(recipientSk, blob);
            Assert.That(recovered, Is.EqualTo(empty));
        }

        [Test]
        public void BlobLayout_IsAsExpected()
        {
            var (_, recipientPkRaw) = GenerateRecipientKeypair();
            var blob = X25519Model.Encrypt(recipientPkRaw, Encoding.UTF8.GetBytes("layout"));

            // version(1) + ephPK(32) + salt(16) + nonce(24) + rest
            Assert.That(blob.Length, Is.GreaterThan(1 + 32 + 16 + 24));

            int o = 0;
            Assert.That(blob[o++], Is.EqualTo(0x01), "Version mismatch");
            // Basic sanity checks: not all zeros for ephPk, salt, nonce
            var ephPk = blob.Skip(o).Take(32).ToArray(); o += 32;
            var salt = blob.Skip(o).Take(16).ToArray(); o += 16;
            var nonce = blob.Skip(o).Take(24).ToArray(); o += 24;

            Assert.That(ephPk.Any(b => b != 0), "Ephemeral public key looks zeroed");
            Assert.That(salt.Any(b => b != 0), "Salt looks zeroed");
            Assert.That(nonce.Any(b => b != 0), "Nonce looks zeroed");
        }
    }
}
