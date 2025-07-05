namespace PlutoFramework.Components.XcavateProperty.Cells;

public partial class ROICellView : ContentView, ISetEmptyView
{
	public ROICellView()
	{
		InitializeComponent();
	}

    public void SetEmpty()
    {
        cell.Value = "7%"; // Change default
    }
}