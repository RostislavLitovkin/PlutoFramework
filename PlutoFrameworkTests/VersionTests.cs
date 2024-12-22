using System;
using PlutoFramework.Model;

namespace PlutoFrameworkTests
{
	public class VersionTests
	{
        [Test]
        public async Task GetPlutoFrameworkVersion()
        {
            var plutoWalletVersion = await VersionModel.GetLatestVersionInfoAsync("https://plutonication.com/plutowallet/latest-version", CancellationToken.None);

            Assert.That(plutoWalletVersion is not null);
            Assert.That(plutoWalletVersion.Version, Is.GreaterThanOrEqualTo(10));
        }

    }
}
