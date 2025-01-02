using Microsoft.VisualStudio.Threading;
using PlutoFramework.Components;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Constants;
using PlutoFramework.View;
using PlutoFramework.ViewModel;

namespace PlutoFramework.Model
{
    public class SubstrateClientModel
    {
        public static Dictionary<EndpointEnum, Task<PlutoFrameworkSubstrateClient>> Clients = new Dictionary<EndpointEnum, Task<PlutoFrameworkSubstrateClient>>();

        // Probably I want to avoid using this
        // public static async Task<PlutoFrameworkSubstrateClient> GetMainClientAsync() => await Clients[DependencyService.Get<MultiNetworkSelectViewModel>().SelectedKey.Value].Task;

        public static async Task RemoveAndDisconnectSubstrateClientAsync(EndpointEnum endpointKey, CancellationToken token)
        {
            if (!Clients.ContainsKey(endpointKey))
            {
                return;
            }

           (await Clients[endpointKey].WithCancellation(token)).Disconnect();

            Clients.Remove(endpointKey);
        }

        public static Task<PlutoFrameworkSubstrateClient> GetMainSubstrateClientAsync(CancellationToken token) => GetOrAddSubstrateClientAsync(DependencyService.Get<MultiNetworkSelectViewModel>().SelectedKey ?? EndpointEnum.None, CancellationToken.None);

        public static async Task<PlutoFrameworkSubstrateClient> GetOrAddSubstrateClientAsync(EndpointEnum endpointKey, CancellationToken token)
        {
            if (endpointKey == EndpointEnum.None)
            {
                Console.WriteLine("Should not have happened: endpointKey was none");
                return null;
            }

            if (!Clients.ContainsKey(endpointKey))
            {
                Clients.Add(endpointKey, ConnectSubstrateClientAsync(endpointKey));
            }

            var client = await Clients[endpointKey];

            // Client is not connected, reconnect it
            if (!await client.IsConnectedAsync())
            {
                Console.WriteLine(endpointKey + " was not connected successfully");

                await client.ConnectAndLoadMetadataAsync();

                Console.WriteLine(endpointKey + " now connected?");
            }

            return client;
        }

        private static async Task<PlutoFrameworkSubstrateClient> ConnectSubstrateClientAsync(EndpointEnum endpointKey)
        {
            Endpoint endpoint = EndpointsModel.GetEndpoint(endpointKey);

            string bestWebSecket = await WebSocketModel.GetFastestWebSocketAsync(endpoint.URLs);

            Console.WriteLine("Best WebSocket: " + bestWebSecket);

            var newClient = new PlutoFrameworkSubstrateClient(
                        endpoint,
                        new Uri(bestWebSecket),
                        Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await newClient.ConnectAndLoadMetadataAsync();

            return newClient;
        }

        public static async Task ChangeClientGroupAsync(IEnumerable<EndpointEnum> endpointKeys, CancellationToken token, bool reload = true)
        {
            #region Remove clients that are not used anymore
            foreach (var key in Clients.Keys)
            {
                if (!endpointKeys.Contains(key))
                {
                    await RemoveAndDisconnectSubstrateClientAsync(key, token);
                }
            }
            #endregion

            foreach (var endpointKey in endpointKeys)
            {
                if (!Clients.ContainsKey(endpointKey))
                {
                    Clients.Add(endpointKey, ConnectSubstrateClientAsync(endpointKey));
                }
            }

            if (!reload)
            {
                return;
            }

            await ViewLocalLoadAsync(MainPage.Views, token);

            var clientTasks = SubstrateClientModel.Clients.Values.ToList();

            while (clientTasks.Count() > 0)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }

                // Inspiration: https://youtu.be/zhCRX3B7qwY?si=RyNtzmzGHrxO17FD&t=2678
                var completedClientTask = await Task.WhenAny(clientTasks).WithCancellation(token).ConfigureAwait(false);

                clientTasks.Remove(completedClientTask);

                var client = await completedClientTask.ConfigureAwait(false);

                if (DependencyService.Get<MultiNetworkSelectViewModel>().SelectedKey == client.Endpoint.Key)
                {
                    await ViewMainSubstrateClientLoadAsync(MainPage.Views, client, token);
                }

                await ViewSubstrateClientLoadAsync(MainPage.Views, client, token);
            }

            ViewSetEmpty(MainPage.Views);
        }

        public static Task ViewLocalLoadAsync(IEnumerable<object> views, CancellationToken token)
        {
            List<Task> asyncLoads = [];

            foreach (var view in views)
            {
                if (view is ILocalLoadableView)
                {
                    (view as ILocalLoadableView).Load();
                }
                if (view is ILocalLoadableAsyncView)
                {
                    asyncLoads.Add((view as ILocalLoadableAsyncView).LoadAsync(token));
                }
            }

            return Task.WhenAll(asyncLoads);
        }

        public static void ViewSetEmpty(IEnumerable<object> views)
        {
            foreach (var view in views)
            {
                if (view is ISetEmptyView)
                {
                    try
                    {
                        (view as ISetEmptyView).SetEmpty();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Set empty exception:");
                        Console.WriteLine(e);
                    }
                }
            }
        }

        public static Task ViewSubstrateClientLoadAsync(IEnumerable<object> views, PlutoFrameworkSubstrateClient client, CancellationToken token)
        {
            List<Task> asyncLoads = [];

            foreach (var view in views)
            {
                if (view is ISubstrateClientLoadableView)
                {
                    try
                    {
                        (view as ISubstrateClientLoadableView).Load(client);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                if (view is ISubstrateClientLoadableAsyncView)
                {
                    try
                    {
                        asyncLoads.Add((view as ISubstrateClientLoadableAsyncView).LoadAsync(client, token));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return Task.WhenAll(asyncLoads);
        }

        public static async Task ChangeMainSubstrateClientAsync(EndpointEnum selectedEndpointKey, CancellationToken token)
        {
            var mainClient = await GetOrAddSubstrateClientAsync(selectedEndpointKey, token);

            await ViewMainSubstrateClientLoadAsync(
                MainPage.Views,
                mainClient,
                token
            );
        }
        public static Task ViewMainSubstrateClientLoadAsync(IEnumerable<object> views, PlutoFrameworkSubstrateClient mainClient, CancellationToken token)
        {
            List<Task> asyncLoads = [];

            foreach (var view in views)
            {
                if (view is IMainSubstrateClientLoadableView)
                {
                    try
                    {
                        (view as IMainSubstrateClientLoadableView).MainLoad(mainClient);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                if (view is IMainSubstrateClientLoadableAsyncView)
                {
                    try
                    {
                        asyncLoads.Add((view as IMainSubstrateClientLoadableAsyncView).MainLoadAsync(mainClient, token));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return Task.WhenAll(asyncLoads);
        }
    }
}
