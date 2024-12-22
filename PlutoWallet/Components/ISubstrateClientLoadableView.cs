using PlutoWallet.Model;

namespace PlutoWallet.Components
{
    public interface ISubstrateClientLoadableView
    {
        void Load(PlutoWalletSubstrateClient client);
    }

    public interface IMainSubstrateClientLoadableView
    {
        void MainLoad(PlutoWalletSubstrateClient client);
    }
    public interface ISubstrateClientLoadableAsyncView
    {
        Task LoadAsync(PlutoWalletSubstrateClient client, CancellationToken token);
    }

    public interface IMainSubstrateClientLoadableAsyncView
    {
        Task MainLoadAsync(PlutoWalletSubstrateClient client, CancellationToken token);
    }
}
