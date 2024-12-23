using PlutoFramework.Model;

namespace PlutoFramework.Components
{
    public interface ISubstrateClientLoadableView
    {
        /// <summary>
        /// Loads information from the SubstrateClient.
        /// </summary>
        void Load(PlutoFrameworkSubstrateClient client);
    }

    public interface IMainSubstrateClientLoadableView
    {
        /// <summary>
        /// Loads information from the main SubstrateClient.
        /// </summary>
        void MainLoad(PlutoFrameworkSubstrateClient client);
    }

    public interface ISubstrateClientLoadableAsyncView
    {
        /// <summary>
        /// Loads information asynchronically from the SubstrateClient.
        /// Usually queries on-chain state.
        /// </summary>
        Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token);
    }

    public interface IMainSubstrateClientLoadableAsyncView
    {
        /// <summary>
        /// Loads information asynchronically from the main SubstrateClient.
        /// Usually queries on-chain state.
        /// </summary>
        Task MainLoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token);
    }
}
