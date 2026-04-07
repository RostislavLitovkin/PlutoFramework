using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Keys;

public partial class ImportEncryptionX25519KeyPage : PageTemplate
{
	public ImportEncryptionX25519KeyPage(ImportEncryptionX25519KeyPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}