namespace UniqueryPlusTests
{
    internal class EVMHelpers
    {
        [Test]
        public void CollectionIdToCollectionAddressConversion()
        {
            Assert.That(UniqueryPlus.EVM.Helpers.GetCollectionAddress(4557), Is.EqualTo("0x17C4E6453Cc49aAAaeaCA894e6d9683e000011cD".ToLower()));
        }

        [Test]
        public void NftIdToNftAddressConversion()
        {
            Assert.That(UniqueryPlus.EVM.Helpers.GetNftAddress(304, 2), Is.EqualTo("0xf8238ccfff8ed887463fd5e00000013000000002".ToLower()));
        }

        [Test]
        public void NftAddresToNftIdsConversion()
        {
            var (collectionId, nftId) = UniqueryPlus.EVM.Helpers.GetNftIdFromNftAddress("0xf8238ccfff8ed887463fd5e00000013000000002");

            Assert.That(collectionId, Is.EqualTo(304));
            Assert.That(nftId, Is.EqualTo(2));
        }
    }
}
