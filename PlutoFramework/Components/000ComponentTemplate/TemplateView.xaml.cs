using PlutoFramework.Model;

namespace PlutoFramework.Components._000ComponentTemplate;

public partial class TemplateView : ContentView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public TemplateView()
	{
		InitializeComponent();

        BindingContext = new TemplateViewModel();
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        var viewModel = (TemplateViewModel)BindingContext;
        // Implement loading logic here
    }

    public void SetEmpty()
    {
        var viewModel = (TemplateViewModel)BindingContext;
        // Implement empty state logic here
    }
}