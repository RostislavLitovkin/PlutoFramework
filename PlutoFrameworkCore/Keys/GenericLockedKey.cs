using PlutoFramework.Model;

namespace PlutoFrameworkCore.Keys
{
    public enum KeyTypeEnum
    {
        None,

        Sr25519,
        PolkadotJson,
        Did,
        EncryptionX25519,
    }
    public record GenericLockedKey
    {
        public required KeyTypeEnum Type { get; set; }

        public required string PublicKey { get; set; }

        public required string SecretStorageKey { get; set; }

        public required string PasswordStorageKey { get; set; } = PreferencesModel.PASSWORD;

        public string Name => $"{Type} Key {PublicKey}";

        public async Task<Sr25519Key> ToSr25519KeyAsync()
        {
            if (Type != KeyTypeEnum.Sr25519)
            {
                throw new InvalidOperationException($"Cannot convert key of type {Type} to Sr25519Key");
            }

            var mnemonics = await PlutoConfigurationModel.SecureStorage.GetAsync(SecretStorageKey);

            if (mnemonics == null)
            {
                throw new InvalidOperationException("Mnemonics not found in secure storage");
            }

            return new Sr25519Key
            {
                Mnemonics = mnemonics,
            };
        }

        public async Task<PolkadotJsonKey> ToPolkadotJsonKeyAsync()
        {
            if (Type != KeyTypeEnum.PolkadotJson)
            {
                throw new InvalidOperationException($"Cannot convert key of type {Type} to PolkadotJsonKey");
            }

            var result = await PlutoConfigurationModel.SecureStorage.GetWithPasswordAsync(SecretStorageKey, PasswordStorageKey);

            if (result.Value == null)
            {
                throw new InvalidOperationException("Json not found in secure storage");
            }

            return new PolkadotJsonKey
            {
                Json = result.Value,
                Password = result.Password,
            };
        }

        public async Task<DidKey> ToDidKeyAsync()
        {
            if (Type != KeyTypeEnum.Did)
            {
                throw new InvalidOperationException($"Cannot convert key of type {Type} to DidKey");
            }

            var mnemonics = await PlutoConfigurationModel.SecureStorage.GetAsync(SecretStorageKey);

            if (mnemonics == null)
            {
                throw new InvalidOperationException("Mnemonics not found in secure storage");
            }

            return new DidKey
            {
                Mnemonics = mnemonics,
            };
        }

        public async Task<EncryptionX25519Key> ToEncryptionX25519KeyAsync()
        {
            if (Type != KeyTypeEnum.EncryptionX25519)
            {
                throw new InvalidOperationException($"Cannot convert key of type {Type} to EncryptionX25519Key");
            }

            var secretKey = await PlutoConfigurationModel.SecureStorage.GetAsync(SecretStorageKey);

            if (secretKey == null)
            {
                throw new InvalidOperationException("Mnemonics not found in secure storage");
            }

            return new EncryptionX25519Key
            {
                SecretKey = Convert.FromBase64String(secretKey),

            };
        }
    }
}
