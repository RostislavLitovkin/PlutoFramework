using System;
using PlutoWallet.Model;

namespace PlutoWalletTests
{
	public class VersionTests
	{
        [Test]
        public async Task GetPlutoWalletVersion()
        {
            var plutoWalletVersion = await VersionModel.GetLatestVersionInfoAsync("https://plutonication.com/plutowallet/latest-version", CancellationToken.None);

            Assert.That(plutoWalletVersion is not null);
            Assert.That(plutoWalletVersion.Version, Is.GreaterThanOrEqualTo(10));
        }

    }
}
