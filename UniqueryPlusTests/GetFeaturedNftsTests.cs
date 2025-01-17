

using UniqueryPlus;

namespace UniqueryPlusTests
{
    internal class GetFeaturedNftsTests
    {
        [Test]
        public async Task GetFeaturedNftsAsync()
        {
            var featuredNfts = await UniqueryPlusApiModel.GetFeaturedNftsAsync(CancellationToken.None);

            Assert.That(!featuredNfts.ContainsKey(NftTypeEnum.Opal));
            Assert.That(featuredNfts.ContainsKey(NftTypeEnum.PolkadotAssetHub_NftsPallet));

            Console.WriteLine(featuredNfts[NftTypeEnum.Mythos][0].CollectionId);
        }
    }
}
