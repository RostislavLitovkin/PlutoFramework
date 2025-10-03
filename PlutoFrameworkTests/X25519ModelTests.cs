using NSec.Cryptography;
using PlutoFrameworkCore.AssetDidComm;
using System.Security.Cryptography;
using System.Text;

namespace PlutoFrameworkTests
{
    internal class X25519ModelTests
    {
        [Test]
        public void EncryptDecrypt_RoundTrip_Works()
        {
            var keypair = X25519Model.GenerateX25519KeyPair();

            var plaintext = Encoding.UTF8.GetBytes("hello sealed world");
            var aad = Encoding.UTF8.GetBytes("context-info");

            var blob = X25519Model.Encrypt(keypair.PublicKey, plaintext, aad);
            var recovered = X25519Model.Decrypt(keypair.PrivateKey, blob, aad);

            Assert.That(recovered, Is.EqualTo(plaintext));

            Console.WriteLine(Encoding.UTF8.GetString(recovered));
        }

        [Test]
        public void EncryptProducesDifferentCiphertexts_ForSameInputs()
        {
            var keypair = X25519Model.GenerateX25519KeyPair();

            var plaintext = Encoding.UTF8.GetBytes("same message");
            var aad = Encoding.UTF8.GetBytes("same aad");

            var blob1 = X25519Model.Encrypt(keypair.PublicKey, plaintext, aad);
            var blob2 = X25519Model.Encrypt(keypair.PublicKey, plaintext, aad);

            // With random salt + nonce + ephemeral key, blobs should virtually always differ
            Assert.That(blob1, Is.Not.EqualTo(blob2), "Ciphertexts should be nondeterministic.");
            // Both should still decrypt
            Assert.That(X25519Model.Decrypt(keypair.PrivateKey, blob1, aad), Is.EqualTo(plaintext));
            Assert.That(X25519Model.Decrypt(keypair.PrivateKey, blob2, aad), Is.EqualTo(plaintext));
        }

        [Test]
        public void Decrypt_WithWrongAAD_Fails()
        {
            var keypair = X25519Model.GenerateX25519KeyPair();

            var plaintext = Encoding.UTF8.GetBytes("bind me to AAD");
            var aad = Encoding.UTF8.GetBytes("correct-aad");
            var wrongAad = Encoding.UTF8.GetBytes("wrong-aad");

            var blob = X25519Model.Encrypt(keypair.PublicKey, plaintext, aad);

            Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(keypair.PrivateKey, blob, wrongAad);
            });
        }

        [Test]
        public void Decrypt_WithWrongPrivateKey_Fails()
        {
            var recipientKeypair = X25519Model.GenerateX25519KeyPair();

            var wrongKeypair = X25519Model.GenerateX25519KeyPair();

            var plaintext = Encoding.UTF8.GetBytes("secret for the right key");

            var blob = X25519Model.Encrypt(recipientKeypair.PublicKey, plaintext);

            Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(wrongKeypair.PrivateKey, blob);
            });
        }

        [Test]
        public void Tampering_CausesDecryptionFailure()
        {
            var recipientKeypair = X25519Model.GenerateX25519KeyPair();

            var plaintext = Encoding.UTF8.GetBytes("flip a bit and fail");
            var blob = X25519Model.Encrypt(recipientKeypair.PublicKey, plaintext);

            // Flip a bit in the ciphertext tail
            var tampered = (byte[])blob.Clone();
            tampered[^1] ^= 0x01;

            Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(recipientKeypair.PrivateKey, tampered);
            });
        }

        [Test]
        public void WrongVersion_Throws()
        {
            var recipientKeypair = X25519Model.GenerateX25519KeyPair();
            var blob = X25519Model.Encrypt(recipientKeypair.PublicKey, new byte[] { 1, 2, 3 });

            var bad = (byte[])blob.Clone();
            bad[0] = 0x02; // unsupported version

            var ex = Assert.Throws<CryptographicException>(() =>
            {
                _ = X25519Model.Decrypt(recipientKeypair.PrivateKey, bad);
            });

            StringAssert.Contains("Unsupported version", ex!.Message);
        }

        [Test]
        public void EmptyPlaintext_RoundTrip_Works()
        {
            var recipientKeypair = X25519Model.GenerateX25519KeyPair();
            var empty = Array.Empty<byte>();
            var blob = X25519Model.Encrypt(recipientKeypair.PublicKey, empty);
            var recovered = X25519Model.Decrypt(recipientKeypair.PrivateKey, blob);
            Assert.That(recovered, Is.EqualTo(empty));
        }

        [Test]
        public void BlobLayout_IsAsExpected()
        {
            var recipientKeypair = X25519Model.GenerateX25519KeyPair();
            var blob = X25519Model.Encrypt(recipientKeypair.PublicKey, Encoding.UTF8.GetBytes("layout"));

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
