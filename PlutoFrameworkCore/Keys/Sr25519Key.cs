using PlutoFramework.Model;
using Substrate.NetApi.Model.Types;

namespace PlutoFrameworkCore.Keys
{
    public record Sr25519Key : IAccountKey
    {
        public required string Mnemonics { get; set; }

        public Account Account => MnemonicsModel.GetAccountFromMnemonics(Mnemonics);
    }
}
