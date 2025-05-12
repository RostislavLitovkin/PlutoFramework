using PlutoFramework.Model;

namespace PlutoFramework.Components.Table;

public partial class TwoCellTableView : ContentView, ISetEmptyView, ISubstrateClientLoadableView, ISubstrateClientLoadableAsyncView, IMainSubstrateClientLoadableView, IMainSubstrateClientLoadableAsyncView
{
	public TwoCellTableView(ContentView view1, ContentView view2)
	{
		InitializeComponent();

        cell1.Content = view1;
        cell2.Content = view2;
    }

    public void SetEmpty()
    {
        if (cell1.Content is ISetEmptyView emptyView)
        {
            emptyView.SetEmpty();
        }
        if (cell2.Content is ISetEmptyView emptyView2)
        {
            emptyView2.SetEmpty();
        }
    }

    public void Load(PlutoFrameworkSubstrateClient client)
    {
        if(cell1.Content is ISubstrateClientLoadableView loadableView)
        {
            loadableView.Load(client);
        }
        if (cell2.Content is ISubstrateClientLoadableView loadableView2)
        {
            loadableView2.Load(client);
        }
    }
    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (cell1.Content is ISubstrateClientLoadableAsyncView loadableView)
        {
            await loadableView.LoadAsync(client, token);
        }
        if (cell2.Content is ISubstrateClientLoadableAsyncView loadableView2)
        {
            await loadableView2.LoadAsync(client, token);
        }
    }

    public void MainLoad(PlutoFrameworkSubstrateClient client)
    {
        if (cell1.Content is IMainSubstrateClientLoadableView loadableView)
        {
            loadableView.MainLoad(client);
        }
        if (cell2.Content is IMainSubstrateClientLoadableView loadableView2)
        {
            loadableView2.MainLoad(client);
        }
    }

    public async Task MainLoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (cell1.Content is IMainSubstrateClientLoadableAsyncView loadableView)
        {
            await loadableView.MainLoadAsync(client, token);
        }
        if (cell2.Content is IMainSubstrateClientLoadableAsyncView loadableView2)
        {
            await loadableView2.MainLoadAsync(client, token);
        }
    }
}