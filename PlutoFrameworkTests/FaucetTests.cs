using PlutoFramework.Model.Faucet;

namespace PlutoFrameworkTests
{
    internal class FaucetTests
    {
        [Test]
        public async Task ApiResponseAsync()
        {
            var WS_URL = "wss://xcavate-paseo.api.onfinality.io/public-ws";
            var DST_ADDR = "5Di95BnfEUyZaACLhyRhwRop5FReA1WErEwk6MrgqVFFkBGF";
            var statusCode = await FaucetApiModel.PostRequestAsync(WS_URL, DST_ADDR);

            Console.WriteLine($"Status Code: {statusCode}");
        }
    }
}
