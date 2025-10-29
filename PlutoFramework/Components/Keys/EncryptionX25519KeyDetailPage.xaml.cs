using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Keys;

public partial class EncryptionX25519KeyDetailPage : PageTemplate
{
	public EncryptionX25519KeyDetailPage(EncryptionX25519KeyDetailPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}