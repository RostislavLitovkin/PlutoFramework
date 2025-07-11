using PlutoFramework.Components;
using PlutoFramework.Model;
using PlutoFramework.Components.NetworkSelect;
using Microsoft.VisualStudio.Threading;

namespace PlutoFramework
{
    public interface IPlutoFrameworkMainPage
    {
        public IList<IView> Views { get; }
    }
    public class MainPageLayoutUpdater
    {
        public static IPlutoFrameworkMainPage? MainPage = null;

        public static IList<IView> Views => MainPage?.Views ?? [];

        public static async Task ReloadAsync(CancellationToken token)
        {
            try
            {
                await ViewLocalLoadAsync(token);
            }
            catch (Exception e)
            {
                Console.WriteLine("ViewLocalLoadAsync exception:");
                Console.WriteLine(e);
            }

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
                    try
                    {
                        await ViewMainSubstrateClientLoadAsync(client, token);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ViewMainSubstrateClientLoadAsync exception:");
                        Console.WriteLine(e);
                    }
                }

                try
                {
                    await ViewSubstrateClientLoadAsync(client, token);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ViewSubstrateClientLoadAsync exception:");
                    Console.WriteLine(e);
                }
            }

            try
            {
                ViewSetEmpty();
            }
            catch (Exception e)
            {
                Console.WriteLine("ViewSetEmpty exception:");
                Console.WriteLine(e);

            }
        }

        public static Task ViewLocalLoadAsync(CancellationToken token)
        {
            List<Task> asyncLoads = [];

            foreach (var view in Views)
            {
                if (view is ILocalLoadableView)
                {
                    ((ILocalLoadableView)view).Load();
                }
                if (view is ILocalLoadableAsyncView)
                {
                    asyncLoads.Add(((ILocalLoadableAsyncView)view).LoadAsync(token));
                }
            }

            return Task.WhenAll(asyncLoads);
        }

        public static void ViewSetEmpty()
        {
            foreach (var view in Views)
            {
                if (view is ISetEmptyView)
                {
                    try
                    {
                        ((ISetEmptyView)view).SetEmpty();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Set empty exception:");
                        Console.WriteLine(e);
                    }
                }
            }
        }

        public static Task ViewSubstrateClientLoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
        {
            List<Task> asyncLoads = [];

            foreach (var view in Views)
            {
                if (view is ISubstrateClientLoadableView)
                {
                    try
                    {
                        ((ISubstrateClientLoadableView)view).Load(client);
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
                        asyncLoads.Add(((ISubstrateClientLoadableAsyncView)view).LoadAsync(client, token));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return Task.WhenAll(asyncLoads);
        }

        public static Task ViewMainSubstrateClientLoadAsync(PlutoFrameworkSubstrateClient mainClient, CancellationToken token)
        {
            List<Task> asyncLoads = [];

            foreach (var view in Views)
            {
                if (view is IMainSubstrateClientLoadableView)
                {
                    try
                    {
                        ((IMainSubstrateClientLoadableView)view).MainLoad(mainClient);
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
                        asyncLoads.Add(((IMainSubstrateClientLoadableAsyncView)view).MainLoadAsync(mainClient, token));
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
