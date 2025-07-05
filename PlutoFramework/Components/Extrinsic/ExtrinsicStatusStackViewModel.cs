using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlutoFramework.Components.Extrinsic
{

	public partial class ExtrinsicStatusStackViewModel : ObservableObject
	{
		[ObservableProperty]
		private Dictionary<string, ExtrinsicInfo> extrinsics = new Dictionary<string, ExtrinsicInfo>();

        [ObservableProperty]
        private ObservableCollection<ExtrinsicInfo> extrinsicInfos = new ObservableCollection<ExtrinsicInfo>();

        [ObservableProperty]
        private bool isVisible;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LayoutBounds))]
        private int heightRequest;

        public Rect LayoutBounds => new Rect(0.5, 0, 1, HeightRequest);

        public ExtrinsicStatusStackViewModel()
		{
            isVisible = false;
        }

        public void Update()
        {
            ExtrinsicInfos = new ObservableCollection<ExtrinsicInfo>();
            ExtrinsicInfos = new ObservableCollection<ExtrinsicInfo>(Extrinsics.Values);
            IsVisible = ExtrinsicInfos.Any();

            HeightRequest = Math.Max(75 * ExtrinsicInfos.Count() - 15, 0);
        }
	}
}

