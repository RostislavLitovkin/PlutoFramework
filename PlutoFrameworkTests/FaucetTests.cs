using PlutoFramework.Model.Faucet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFrameworkTests
{
    internal class FaucetTests
    {
        [Test]
        public async Task ApiResponseAsync()
        {
            var WS_URL = "wss://fraa-flashbox-4654-rpc.a.stagenet.tanssi.network";
            var DST_ADDR = "5Di95BnfEUyZaACLhyRhwRop5FReA1WErEwk6MrgqVFFkBGF";
            await FaucetApiModel.PostRequestAsync(WS_URL, DST_ADDR);
        }
    }
}
