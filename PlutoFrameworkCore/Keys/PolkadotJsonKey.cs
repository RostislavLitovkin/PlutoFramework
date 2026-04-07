
using PlutoFramework.Model;
using Substrate.NetApi.Model.Types;

namespace PlutoFrameworkCore.Keys
{
    public record PolkadotJsonKey : IAccountKey
    {
        public required string Password { get; set; }
        public required string Json { get; set; }

        public Account Account => MnemonicsModel.ImportJson(Json, Password)?.Account!;
    }
}
