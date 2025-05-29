using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Tabs
{
    public enum SelectedTabEnum
    {
        Tab1, // Tab1 is selected by default
        Tab2
    };


    public partial class TwoTabViewModel : ObservableObject
    {
        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Tab1IsSelected))]
        [NotifyPropertyChangedFor(nameof(Tab2IsSelected))]
        private SelectedTabEnum selectedTab = SelectedTabEnum.Tab1;

        public bool Tab1IsSelected => SelectedTab == SelectedTabEnum.Tab1;

        public bool Tab2IsSelected => SelectedTab == SelectedTabEnum.Tab2;

        [RelayCommand]
        public void SelectTab1()
        {
            SelectedTab = SelectedTabEnum.Tab1;

            // Any other logic
        }

        [RelayCommand]
        public void SelectTab2()
        {
            SelectedTab = SelectedTabEnum.Tab2;

            // Any other logic
        }
    }
}
