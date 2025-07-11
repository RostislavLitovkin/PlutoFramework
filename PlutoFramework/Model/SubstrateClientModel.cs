using Microsoft.VisualStudio.Threading;
using PlutoFramework.Components;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Constants;

namespace PlutoFramework.Model
{
    public class SubstrateClientModel
    {
        public static Dictionary<EndpointEnum, Task<PlutoFrameworkSubstrateClient>> Clients = new Dictionary<EndpointEnum, Task<PlutoFrameworkSubstrateClient>>();

        /// <summary>
        /// Disconnects the endpoint efficiently
        /// </summary>
        /// <param name="endpointKey">Endpoint to disconnect</param>
        /// <param name="token">Cancellation token</param>
        public static async Task RemoveAndDisconnectSubstrateClientAsync(EndpointEnum endpointKey, CancellationToken token)
        {
            if (!Clients.ContainsKey(endpointKey))
            {
                return;
            }

           (await Clients[endpointKey].WithCancellation(token)).Disconnect();

            Clients.Remove(endpointKey);
        }

        /// <summary>
        /// 
        /// - This method also waits for the client to connect to the websocket RPC if it has not connected yet.
        /// </summary>
        /// <param name="token">Cancellation token</param>
        /// <returns>Main Substrate Client</returns>
        public static Task<PlutoFrameworkSubstrateClient> GetMainSubstrateClientAsync(CancellationToken token) => GetOrAddSubstrateClientAsync(DependencyService.Get<MultiNetworkSelectViewModel>().SelectedKey ?? EndpointEnum.None, CancellationToken.None);

        /// <summary>
        ///
        /// - This method also waits for the client to connect to the websocket RPC if it has not connected yet.
        /// </summary>
        /// <param name="endpointKey">Endpoint to use</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>Substrate client</returns>
        public static async Task<PlutoFrameworkSubstrateClient> GetOrAddSubstrateClientAsync(EndpointEnum endpointKey, CancellationToken token)
        {
            if (endpointKey == EndpointEnum.None)
            {
                throw new Exception("Endpoint was None");
            }

            if (!Clients.ContainsKey(endpointKey))
            {
                Clients.Add(endpointKey, ConnectSubstrateClientAsync(endpointKey));
            }

            var client = await Clients[endpointKey];

            // Client is not connected, reconnect it
            if (!await client.IsConnectedAsync())
            {
                await client.ConnectAndLoadMetadataAsync();
            }

            return client;
        }

        private static async Task<PlutoFrameworkSubstrateClient> ConnectSubstrateClientAsync(EndpointEnum endpointKey)
        {
            Endpoint endpoint = EndpointsModel.GetEndpoint(endpointKey);

            string bestWebSecket = await WebSocketModel.GetFastestWebSocketAsync(endpoint.URLs);

            var newClient = new PlutoFrameworkSubstrateClient(
                endpoint,
                new Uri(bestWebSecket),
                Substrate.NetApi.Model.Extrinsics.ChargeTransactionPayment.Default());

            await newClient.ConnectAndLoadMetadataAsync();

            return newClient;
        }

        /// <summary>
        /// Changes the substrate clients that are connected.
        /// Disconnects the ones that were connected before but are not present in the new list.
        /// Handles the UI changes
        /// </summary>
        /// <param name="endpointKeys">Endpoints that will be connected</param>
        /// <param name="token">Cancellation token</param>
        /// <param name="reload">Reload data?</param>
        public static async Task ChangeConnectedClientsAsync(IEnumerable<EndpointEnum> endpointKeys, CancellationToken token, bool reload = true)
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

            #region Connect new clients
            foreach (var endpointKey in endpointKeys)
            {
                if (!Clients.ContainsKey(endpointKey))
                {
                    Clients.Add(endpointKey, ConnectSubstrateClientAsync(endpointKey));
                }
            }
            #endregion

            if (!reload)
            {
                return;
            }

            await MainPageLayoutUpdater.ReloadAsync(token);
        }

        /// <summary>
        /// Handles the UI changes
        /// </summary>
        /// <param name="selectedEndpointKey">Main endpoint</param>
        /// <param name="token">Cancellation token</param>
        public static async Task ChangeMainSubstrateClientAsync(EndpointEnum selectedEndpointKey, CancellationToken token)
        {
            var mainClient = await GetOrAddSubstrateClientAsync(selectedEndpointKey, token);

            await MainPageLayoutUpdater.ViewMainSubstrateClientLoadAsync(mainClient, token);

            // TODO update UI
        }
    }
}
