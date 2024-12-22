using PlutoFramework.Model;

namespace PlutoFramework.Components
{
    public interface ISubstrateClientLoadableView
    {
        void Load(PlutoFrameworkSubstrateClient client);
    }

    public interface IMainSubstrateClientLoadableView
    {
        void MainLoad(PlutoFrameworkSubstrateClient client);
    }
    public interface ISubstrateClientLoadableAsyncView
    {
        Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token);
    }

    public interface IMainSubstrateClientLoadableAsyncView
    {
        Task MainLoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token);
    }
}
