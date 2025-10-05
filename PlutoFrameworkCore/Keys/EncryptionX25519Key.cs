namespace PlutoFrameworkCore.Keys
{
    public record EncryptionX25519Key
    {
        public required byte[] SecretKey { get; set; }
    }
}
