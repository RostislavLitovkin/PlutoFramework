using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Nft;

public partial class NftImageFullScreenPage : PageTemplate
{
	public NftImageFullScreenPage(string imageSource)
	{
        InitializeComponent();

        image.Source = imageSource;
    }
}