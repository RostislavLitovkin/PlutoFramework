using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.Bohemia
{
    public partial class ToJoinDaoViewModel : ObservableObject
    {
        private const uint NFT_COUNT_REQUIRED = 10;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NftCountText))]
        private uint? nftCount = null;

        public string NftCountText => NftCount is not null ? $"{NftCount}/{NFT_COUNT_REQUIRED}" : $"-/{NFT_COUNT_REQUIRED}";
    }
}
