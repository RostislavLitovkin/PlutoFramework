using Kilt.NetApi.Generated;
using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Kilt;

public partial class DidManagementPage : PageTemplate
{
	public DidManagementPage(string? secret)
	{
        InitializeComponent();

        BindingContext = new DidManagementViewModel
        {
            Did = Preferences.Get(PreferencesModel.PUBLIC_KEY + "kilt1", ""),
            Mnemonics = secret ?? "No mnemonics found",
        };
    }

    private async Task LoadAsync()
    {
        CancellationToken token = CancellationToken.None;

        var viewModel = (DidManagementViewModel)BindingContext;
        var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(Constants.EndpointEnum.Kilt, token);

        var didDetails = await ((SubstrateClientExt)client.SubstrateClient).DidStorage.Did(
            DidModel.DidAddressToAccountId32(viewModel.Did),
            null,
            token
        );

        if (didDetails is null)
        {
            return;
        }

        viewModel.DidVerification = DidVerificationEnum.Full;

        Preferences.Set(PreferencesModel.DID_VERIFICATION + "kilt1", DidVerificationEnum.Full.ToString());
    }
}