extern alias bc26; 

using bc26::Org.BouncyCastle.Crypto.Parameters;
using PlutoFrameworkCore.AssetDidComm;
using Substrate.NetApi.Extensions;
using System.Security.Cryptography;
using System.Text;

namespace PlutoFrameworkTests
{
    internal class X25519ModelTests
    {
        [Test]
        public void X25519SecretKeyToPublicKey()
        {
            var rng = new byte[32].Populate();

            var sk = new X25519PrivateKeyParameters(rng);
            var pk = sk.GeneratePublicKey();

            var sk2 = new X25519PrivateKeyParameters(sk.GetEncoded());
            var pk2 = sk2.GeneratePublicKey();

            Assert.Equals(pk.GetEncoded(), pk2.GetEncoded());
        }

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
            var plaintext = Encoding.UTF8.GetBytes("layout"); // n = 6
            var blob = X25519Model.Encrypt(recipientKeypair.PublicKey, plaintext);

            // Layout: ephPk(32) | nonce(12) | ciphertext+tag(n + 16)
            int n = plaintext.Length;
            int expectedLen = 32 + 12 + (n + 16); // 60 + n
            Assert.That(blob.Length, Is.EqualTo(expectedLen));

            int o = 0;
            var ephPk = blob.Skip(o).Take(32).ToArray(); o += 32;
            var nonce = blob.Skip(o).Take(12).ToArray(); o += 12;
            var ctTag = blob.Skip(o).ToArray();

            // Basic sanity: not all zeros
            Assert.That(ephPk.Any(b => b != 0), "Ephemeral public key looks zeroed");
            Assert.That(nonce.Any(b => b != 0), "Nonce looks zeroed");

            // ct+tag length must be n + 16 and tag present
            Assert.That(ctTag.Length, Is.EqualTo(n + 16));
        }
    }
}
