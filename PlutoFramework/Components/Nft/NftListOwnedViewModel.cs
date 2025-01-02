﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualStudio.Threading;
using PlutoFramework.Model;
using System.Collections.ObjectModel;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.Nft
{
    public partial class NftListOwnedViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<NftWrapper> nfts = new ObservableCollection<NftWrapper>() { };

        private IAsyncEnumerator<INftBase> uniqueryNftEnumerator = null;

        private const uint limit = 4;

        private List<Task<PlutoFrameworkSubstrateClient>> clientTasks;
        public NftListOwnedViewModel(CancellationToken token = default)
        {
            clientTasks = SubstrateClientModel.Clients.Values.ToList();

            Task load = LoadMoreNftsAsync(token);
        }

        private void LoadSavedNfts()
        {

        }

        [RelayCommand]
        public async Task LoadMoreNftsAsync(CancellationToken token)
        {
            for (uint i = 0; i < limit; i++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    Nfts.Add(Model.NftModel.ToNftWrapper(uniqueryNftEnumerator.Current));
                }

                else
                {
                    if (clientTasks.Count() == 0)
                    {
                        return;
                    }

                    // Inspiration: https://youtu.be/zhCRX3B7qwY?si=RyNtzmzGHrxO17FD&t=2678
                    var completedClientTask = await Task.WhenAny(clientTasks).WithCancellation(token).ConfigureAwait(false);

                    clientTasks.Remove(completedClientTask);

                    var uniqueryNftEnumerable = UniqueryPlus.Nfts.NftModel.GetNftsOwnedByAsync(
                        [(await completedClientTask.ConfigureAwait(false)).SubstrateClient],
                        KeysModel.GetSubstrateKey(),
                        limit: limit
                    );

                    uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

                    i--;
                }
            }
        }
    }
}
