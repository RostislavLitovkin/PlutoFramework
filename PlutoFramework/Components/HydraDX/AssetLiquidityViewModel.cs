using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.HydraDX
{
    public partial class AssetLiquidityViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<LiquidityMiningInfo> liquidityMiningInfos;
    }
}
