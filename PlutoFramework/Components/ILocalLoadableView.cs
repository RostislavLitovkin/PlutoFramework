namespace PlutoFramework.Components
{
    interface ILocalLoadableView
    {
        void Load();
    }
    interface ILocalLoadableAsyncView
    {
        Task LoadAsync(CancellationToken token);
    }
    interface ISetEmptyView
    {
        void SetEmpty();
    }
}
