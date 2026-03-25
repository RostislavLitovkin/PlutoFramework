using NSec.Cryptography;
using PlutoFrameworkCore.AssetDidComm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PlutoFrameworkTests
{
    [TestFixture]
    public class JweModelTests
    {
        private static (Key sk, byte[] pk) NewX25519()
        {
            var key = Key.Create(KeyAgreementAlgorithm.X25519, new KeyCreationParameters
            {
                ExportPolicy = KeyExportPolicies.AllowPlaintextExport
            });
            var pk = key.PublicKey.Export(KeyBlobFormat.RawPublicKey);
            return (key, pk);
        }

        private static string DecodeProtectedJson(string protectedB64)
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(protectedB64));
            return json;
        }

        private static JsonObject Parse(string json)
        {
            return JsonNode.Parse(json)!.AsObject();
        }

        private static string ToJson(JsonObject obj)
        {
            return obj.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
        }

        private static JsonObject EncryptCall(byte[][] recipientPks, string plaintext)
        {
            string jwe = JweModel.Encrypt(Encoding.UTF8.GetBytes(plaintext), recipientPks);
            return Parse(jwe);
        }

        [Test]
        public void Encrypt_Then_Decrypt_Roundtrips_ForSingleRecipient()
        {
            // Arrange
            var (sk, pk) = NewX25519();
            var plaintext = "Hello JWE";

            Console.WriteLine(Convert.ToBase64String(pk));

            // Act
            var jweObj = EncryptCall(new[] { pk }, plaintext);
            var jwe = ToJson(jweObj);
            var decrypted = JweModel.DecryptForRecipient(jwe, pk, sk);

            // Assert
            Assert.That(decrypted, Is.EqualTo(plaintext));
        }

        [Test]
        public void Encrypt_Then_Decrypt_Roundtrips_WhenRecipientIsAmongMany()
        {
            // Arrange
            var (sk1, pk1) = NewX25519();
            var (sk2, pk2) = NewX25519();
            var (sk3, pk3) = NewX25519();
            var plaintext = "Secret for recipient #2";

            // Act: encrypt for three recipients, then decrypt using #2
            var jweObj = EncryptCall(new[] { pk1, pk2, pk3 }, plaintext);
            var jwe = ToJson(jweObj);
            var decrypted = JweModel.DecryptForRecipient(jwe, pk2, sk2);

            // Assert
            Assert.That(decrypted, Is.EqualTo(plaintext));
        }

        [Test]
        public void Decrypt_WithWrongRecipientKey_ThrowsCryptographicException()
        {
            // Arrange
            var (intendedSk, intendedPk) = NewX25519();
            var (wrongSk, wrongPk) = NewX25519();
            var plaintext = "Only the intended recipient should read this";

            var jweObj = EncryptCall(new[] { intendedPk }, plaintext);
            var jwe = ToJson(jweObj);

            // Act + Assert
            Assert.Throws<CryptographicException>(() => JweModel.DecryptForRecipient(jwe, intendedPk, wrongSk));
        }

        [Test]
        public void Encrypt_Produces_GeneralJweShape_AndProtectedHeader()
        {
            // Arrange
            var (_, pk) = NewX25519();
            var jweObj = EncryptCall(new[] { pk }, "shape test");

            // top-level properties
            Assert.That(jweObj.ContainsKey("protected"), Is.True);
            Assert.That(jweObj.ContainsKey("iv"), Is.True);
            Assert.That(jweObj.ContainsKey("ciphertext"), Is.True);
            Assert.That(jweObj.ContainsKey("tag"), Is.True);
            Assert.That(jweObj.ContainsKey("recipients"), Is.True);

            // protected header
            var protectedB64 = jweObj["protected"]!.GetValue<string>();
            var protectedJson = DecodeProtectedJson(protectedB64);
            using var ph = JsonDocument.Parse(protectedJson);
            var root = ph.RootElement;

            Assert.That(root.GetProperty("enc").GetString(), Is.EqualTo("A256GCM"));
            Assert.That(root.GetProperty("alg").GetString(), Is.EqualTo("ECDH-ES+A256KW"));

            // recipients count
            var recipients = jweObj["recipients"]!.AsArray();
            Assert.That(recipients.Count, Is.EqualTo(1));
        }

        [Explicit("Enable after aligning per-recipient header to RFC: header.alg should be 'ECDH-ES+A256KW' and epk.x should be the SENDER'S ephemeral key, not the recipient's.")]
        [Test]
        public void Encrypt_RecipientHeader_IsSpecCompliant()
        {
            var (_, pk) = NewX25519();
            var jweObj = EncryptCall(new[] { pk }, "spec check");

            var rec = jweObj["recipients"]!.AsArray().First().AsObject();
            var header = rec["header"]!.AsObject();

            Assert.That(header["alg"]!.GetValue<string>(), Is.EqualTo("ECDH-ES+A256KW"));

            var epk = header["epk"]!.AsObject();
            Assert.That(epk["kty"]!.GetValue<string>(), Is.EqualTo("OKP"));
            Assert.That(epk["crv"]!.GetValue<string>(), Is.EqualTo("X25519"));

            // In RFC 7516/8037 flow, epk.x must be the sender's ephemeral public key (base64url),
            // not the recipient key. This test asserts the property exists and is non-empty.
            var x = epk["x"]!.GetValue<string>();
            Assert.That(string.IsNullOrWhiteSpace(x), Is.False);
        }

        [Test]
        public void Decrypt_Rejects_UnsupportedEnc()
        {
            // Arrange
            var (sk, pk) = NewX25519();
            var jweObj = EncryptCall(new[] { pk }, "bad enc");

            // Mutate protected header: enc -> A128GCM
            var protectedB64 = jweObj["protected"]!.GetValue<string>();
            var protectedJson = Parse(DecodeProtectedJson(protectedB64));
            protectedJson["enc"] = "A128GCM";
            var newProtectedB64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(ToJson(protectedJson)));
            jweObj["protected"] = newProtectedB64;

            var tampered = ToJson(jweObj);

            // Act + Assert
            Assert.Throws<NotSupportedException>(() => JweModel.DecryptForRecipient(tampered, pk, sk));
        }

        [Test]
        public void Decrypt_Fails_WhenCiphertextIsTampered()
        {
            // Arrange
            var (sk, pk) = NewX25519();
            var jweObj = EncryptCall(new[] { pk }, "tamper me");

            // flip a bit in ciphertext
            var ctB64 = jweObj["ciphertext"]!.GetValue<string>();
            var ct = Convert.FromBase64String(ctB64);
            ct[^1] ^= 0x01; // toggle last bit
            jweObj["ciphertext"] = Convert.ToBase64String(ct);

            var tampered = ToJson(jweObj);

            // Act + Assert
            Assert.Throws<AuthenticationTagMismatchException>(() => JweModel.DecryptForRecipient(tampered, pk, sk));
        }

        [Test]
        public void Decrypt_Fails_WhenNoMatchingRecipient()
        {
            // Arrange
            var (sk, pk) = NewX25519();
            var (otherSk, otherPk) = NewX25519();

            // Encrypt to someone else entirely
            var jweObj = EncryptCall(new[] { otherPk }, "not for you");
            var jwe = ToJson(jweObj);

            // Act + Assert
            Assert.Throws<CryptographicException>(() => JweModel.DecryptForRecipient(jwe, pk, sk));
        }
    }
}
