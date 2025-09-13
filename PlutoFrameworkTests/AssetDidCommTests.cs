using PlutoFramework.Model;
using PlutoFrameworkCore.AssetDidComm;
using Substrate.NET.Schnorrkel.Keys;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Types.Primitive;
using System.Text;
using System.Text.Json;

namespace PlutoFrameworkTests
{
    internal class AssetDidCommTests
    {

        [Test]
        public async Task WriteMessageAsync()
        {
            Random random = new Random();

            var num = random.Next();

            await AssetDidCommModel.WriteMessageAsync(new U128(0), new U128(0), $"C sharp test {num}", tag: "message");
        }
    }
}
