using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class CompanyPage : PageTemplate
{
    public CompanyPage(CompanyViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ((CompanyViewModel)BindingContext).InitialLoadAsync(CancellationToken.None);
    }
}