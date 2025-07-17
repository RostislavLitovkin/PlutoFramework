namespace PlutoFramework.Components.Bohemia;

public partial class ToJoinDaoView : ContentView
{
	public ToJoinDaoView()
	{
		InitializeComponent();

		BindingContext = new ToJoinDaoViewModel();
    }

	public void SetNftCount(uint count)
	{
		if (BindingContext is ToJoinDaoViewModel viewModel)
		{
			viewModel.NftCount = count;
		}
    }
}