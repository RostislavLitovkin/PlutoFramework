namespace PlutoFrameworkCore
{

    public record SecretResult
    {
        public required string Password { get; set; }
        public required string? Value { get; set; }
    }
    /// <summary>
	/// Copy of ISecureStorage from Microsoft.Maui.Storage
	/// </summary>
	public interface IPlutoSecureStorage
    {
        /// <summary>
        /// Gets and decrypts the value for a given key.
        /// </summary>
        /// <param name="key">The key to retrieve the value for.</param>
        /// <returns>The decrypted string value or <see langword="null"/> if a value was not found.</returns>
        Task<string?> GetAsync(string key);

        /// <summary>
        /// Gets and decrypts the value for a given key.
        /// </summary>
        /// <param name="key">The key to retrieve the value for.</param>
        /// <returns>The decrypted string value or <see langword="null"/> if a value was not found.</returns>
        Task<SecretResult> GetWithPasswordAsync(string key, string passwordKey);

        /// <summary>
        /// Sets and encrypts a value for a given key.
        /// </summary>
        /// <param name="key">The key to set the value for.</param>
        /// <param name="value">Value to set.</param>
        /// <returns>A <see cref="Task"/> object with the current status of the asynchronous operation.</returns>
        Task SetAsync(string key, string value);

        /// <summary>
        /// Removes a key and its associated value if it exists.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        bool Remove(string key);

        /// <summary>
        /// Removes all of the stored encrypted key/value pairs.
        /// </summary>
        void RemoveAll();
    }
    public static class PlutoConfigurationModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public static IPlutoSecureStorage SecureStorage;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    }
}
