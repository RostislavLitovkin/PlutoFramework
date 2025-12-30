using Substrate.NET.Wallet;
using Substrate.NET.Wallet.Keyring;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Types;
using static Substrate.NetApi.Mnemonic;

namespace PlutoFramework.Model
{
    public class MnemonicsModel
    {
        private static readonly Meta META = new Meta() { Name = "PlutoFramework" };

        public static string[] GenerateMnemonicsArray()
        {
            return MnemonicFromEntropy(new byte[16].Populate(), BIP39Wordlist.English);
        }

        public static string GenerateMnemonics()
        {
            var mnemonicsArray = GenerateMnemonicsArray();
            string mnemonics = string.Empty;

            foreach (string mnemonic in mnemonicsArray)
            {
                mnemonics += " " + mnemonic;
            }

            return mnemonics.Trim();
        }

        public static Account GenerateNewAccount()
        {
            var mnemonics = GenerateMnemonics();

            return GetAccountFromMnemonics(mnemonics);
        }

        public static (Account, string) GenerateNewAccountAndMnemonics()
        {
            var mnemonics = GenerateMnemonics();

            return (GetAccountFromMnemonics(mnemonics), mnemonics);
        }

        public static Account GetAccountFromMnemonics(string mnemonics)
        {
            var keyring = new Substrate.NET.Wallet.Keyring.Keyring();

            Wallet wallet = keyring.AddFromMnemonic(mnemonics, META, Substrate.NetApi.Model.Types.KeyType.Sr25519);

            return wallet.Account;
        }

        public static string ExportJson(string mnemonics, string password)
        {
            var keyring = new Substrate.NET.Wallet.Keyring.Keyring();

            Wallet wallet = keyring.AddFromMnemonic(mnemonics, META, Substrate.NetApi.Model.Types.KeyType.Sr25519);

            return wallet.ToJson("PlutoFramework", password);
        }

        /// <summary>
        /// Imports the Json string and returns Wallet
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Wallet? ImportJson(string json, string password)
        {
            var keyring = new Substrate.NET.Wallet.Keyring.Keyring();

            // Later remove .Replace(..)
            Wallet wallet = keyring.AddFromJson(json.Replace("\"3\"", "3"));

            if (!wallet.Unlock(password))
            {
                throw new Exception("Wrong password");
            }

            return wallet;
        }
    }
}

