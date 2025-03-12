namespace PlutoFramework.Components.CustomLayouts;

public partial class LoadingItemView : ContentView
{
	public LoadingItemView()
	{
		InitializeComponent();

        itemView.HeightRequest = this.HeightRequest;
        itemView.WidthRequest = this.WidthRequest;
    }
}