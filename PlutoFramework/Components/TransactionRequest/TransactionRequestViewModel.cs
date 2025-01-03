﻿using System;
using Substrate.NetApi.Model.Extrinsics;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using PlutoFramework.Types;
using PlutoFramework.Model;
using Substrate.NetApi;
using PlutoFramework.Constants;
using PlutoFramework.Model.AjunaExt;

namespace PlutoFramework.Components.TransactionRequest
{
    public partial class TransactionRequestViewModel : ObservableObject
    {
        [ObservableProperty]
        private string chainIcon;

        [ObservableProperty]
        private string chainName;

        [ObservableProperty]
        private EndpointEnum endpointKey;

        [ObservableProperty]
        private string palletIndex;

        [ObservableProperty]
        private string callIndex;

        [ObservableProperty]
        private string parameters;

        [ObservableProperty]
        private Method ajunaMethod;

        [ObservableProperty]
        private string fee;

        [ObservableProperty]
        private bool isVisible;

        [ObservableProperty]
        private Payload payload;

        public TransactionRequestViewModel()
        {
            isVisible = false;
        }

        public async Task CalculateFeeAsync(SubstrateClientExt client, Method method)
        {
            if (!await client.IsConnectedAsync())
            {
                Fee = "Fee: Failed";

                return;
            }

            Fee = "Fee: " + await Model.FeeModel.GetMethodFeeAsync(client, method);
        }
    }
}

