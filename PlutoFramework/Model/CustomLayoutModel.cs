using PlutoFramework.Components.Balance;
using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.DAppConnectionView;
using PlutoFramework.Components.Extrinsic;
using System.Collections.ObjectModel;
using PlutoFramework.Components.MessagePopup;
using PlutoFramework.Constants;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Components.AwesomeAjunaAvatars;
using PlutoFramework.Components.Contract;
using PlutoFramework.Components.AzeroId;
using PlutoFramework.Components.HydraDX;
using PlutoFramework.Components.Identity;
using PlutoFramework.Components.Referenda;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Nft;
using PlutoFramework.Components.VTokens;
using PlutoFramework.Components.UpdateView;
using PlutoFramework.Components.GalaxyLogicGame;
using PlutoFramework.Components.PredefinedLayouts;
using PlutoFramework.Components.Xcm;
using PlutoFramework.View;

namespace PlutoFramework.Model
{
    public class ComponentInfo
    {
        public string Name { get; set; }
        public ComponentId ComponentId { get; set; }
    }

    public enum ComponentId
    {
        U,
        dApp,
        ExSL,
        UsdB,
        RnT,
        SubK,
        ChaK,
        AAALeaderboard,
        AZEROPrimaryName,
        HDXOmniLiquidity,
        HDXDCA,
        id,
        Ref,
        contract,
        BMnR,
        NftG,
        NftOG,
        NftFG,
        VDot,
        GLGPowerups,
        xTrnsfr,
    }

    public class CustomLayoutModel
    {
        public const string DEFAULT_PLUTO_LAYOUT = "plutolayout: [U, dApp, BMnR, ExSL, UsdB, RnT, SubK, ChaK];[Polkadot, Kusama]";

        // This constant is used to fetch all components
        public static string AllComponentsString = $"plutolayout: [{string.Join(",", Enum.GetValues(typeof(ComponentId)))}];[";

        // EXTRA: StDash, AAASeasonCountdown, PubK, FeeA, CalEx

        public static List<Endpoint> ParsePlutoEndpoints(string plutoLayoutString)
        {
            if (plutoLayoutString.Substring(0, 13) != "plutolayout: ")
            {
                throw new Exception("Could not parse the PlutoLayout");
            }

            string[] componentsAndNetworksStrings = plutoLayoutString.Split(";");

            string[] layoutEndpointKeys = componentsAndNetworksStrings[1].Trim(new char[] { '[', ']' }).Split(',');

            List<Endpoint> result = new List<Endpoint>();

            foreach (var key in layoutEndpointKeys.ToEndpointEnums())
            {
                result.Add(Endpoints.GetEndpointDictionary[key]);
            }

            return result;
        }

        public static List<IView> ParsePlutoLayout(string plutoLayoutString)
        {
            if (plutoLayoutString.Substring(0, 13) != "plutolayout: ")
            {
                throw new Exception("Could not parse the PlutoLayout");
            }

            Console.WriteLine(plutoLayoutString);

            plutoLayoutString = plutoLayoutString.Substring(13);

            List<IView> result = new List<IView>();

            if (plutoLayoutString.Length == 2)
            {
                return result;
            }

            string[] componentsAndNetworksStrings = plutoLayoutString.Split(";");

            string[] componentStrings = componentsAndNetworksStrings[0].Trim(new char[] { '[', ']' }).Split(',');

            foreach (string component in componentStrings)
            {
                result.Add(GetView((ComponentId)Enum.Parse(typeof(ComponentId), component.Trim())));
            }

            return result;
        }

        public static ObservableCollection<ComponentInfo> ParsePlutoComponentInfos(string plutoLayoutString)
        {
            if (plutoLayoutString.Substring(0, 13) != "plutolayout: ")
            {
                throw new Exception("Could not parse the PlutoLayout");
            }

            plutoLayoutString = plutoLayoutString.Substring(13);

            ObservableCollection<ComponentInfo> result = new ObservableCollection<ComponentInfo>();

            if (plutoLayoutString.Length == 2)
            {
                return result;
            }

            string[] componentsAndNetworksStrings = plutoLayoutString.Split(";");

            string[] componentStrings = componentsAndNetworksStrings[0].Trim(new char[] { '[', ']' }).Split(',');

            foreach (string component in componentStrings)
            {
                result.Add(GetComponentInfo((ComponentId)Enum.Parse(typeof(ComponentId), component.Trim())));
            }

            return result;
        }

        public static void SaveLayout(ObservableCollection<ComponentInfo> componentInfos)
        {
            var componentIds = string.Join(",", componentInfos.Select(info => info.ComponentId));
            string result = $"plutolayout: [{componentIds}];";

            // save Endpoints
            result += Preferences.Get("SelectedNetworks", EndpointsModel.DefaultEndpoints);

            // Save
            Preferences.Set("PlutoLayout", result);

            MainPage.SetupLayout();
        }

        public static void SaveLayout(string componentInfos)
        {
            Preferences.Set("PlutoLayout", componentInfos);

            SaveEndpoints(componentInfos);

            MainPage.SetupLayout();
        }

        /**
         * This method is useful for saving a change of endpoints
         */
        public static void SaveLayout()
        {
            string plutoLayout = Preferences.Get("PlutoLayout", DEFAULT_PLUTO_LAYOUT);

            string[] plutoLayoutStrings = plutoLayout.Split(";");

            string result = plutoLayoutStrings[0] + ";";

            // save Endpoints
            result += Preferences.Get("SelectedNetworks", EndpointsModel.DefaultEndpoints);

            result = result.Substring(0, result.Length - 2) + "]";

            Preferences.Set("PlutoLayout", result);
        }

        public static void AddComponentToSavedLayout(ComponentId componentId)
        {
            string savedLayout = Preferences.Get("PlutoLayout", DEFAULT_PLUTO_LAYOUT);

            string[] componentsAndNetworksStrings = savedLayout.Split(";");

            string newLayout = componentsAndNetworksStrings[0].Length != 15 ?
                componentsAndNetworksStrings[0].Substring(0, componentsAndNetworksStrings[0].Length - 1) + ", " + componentId + "]" :
                "plutolayout: [" + componentId + "]";

            SaveLayout(newLayout + ";" + componentsAndNetworksStrings[1]);
        }

        public static void RemoveComponentFromSavedLayout(ComponentId componentId)
        {
            var componentInfos = Model.CustomLayoutModel.ParsePlutoComponentInfos(
                    Preferences.Get("PlutoLayout",
                    Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT)
                );

            var infos = new ObservableCollection<ComponentInfo>();

            for (int i = 0; i < componentInfos.Count(); i++)
            {
                if (componentId == componentInfos[i].ComponentId)
                {
                    continue;
                }

                infos.Add(componentInfos[i]);
            }

            Model.CustomLayoutModel.SaveLayout(infos);
        }

        public static void MergePlutoLayouts(string plutoLayout)
        {
            var componentInfos = Model.CustomLayoutModel.ParsePlutoComponentInfos(
                plutoLayout
            );

            var savedComponentInfos = Model.CustomLayoutModel.ParsePlutoComponentInfos(
                Preferences.Get("PlutoLayout",
                Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT)
            );

            var savedComponentIds = savedComponentInfos.Select(info => info.ComponentId);

            for (int i = 0; i < componentInfos.Count(); i++)
            {
                if (!savedComponentIds.Contains(componentInfos[i].ComponentId))
                {
                    savedComponentInfos.Add(componentInfos[i]);
                }
            }

            Model.CustomLayoutModel.SaveLayout(savedComponentInfos);
        }

        private static void SaveEndpoints(string plutoLayoutString)
        {
            if (plutoLayoutString.Substring(0, 13) != "plutolayout: ")
            {
                throw new Exception("Could not parse the PlutoLayout");
            }

            string[] componentsAndNetworksStrings = plutoLayoutString.Split(";");

            if (componentsAndNetworksStrings[1].Length < 2)
            {
                // The endpoint is not saved in the layout

                Console.WriteLine("Endpoint is not saved in the PlutoLayout:");
                Console.WriteLine(plutoLayoutString);

                return;
            }

            // Save Selected Networks
            Preferences.Set("SelectedNetworks", componentsAndNetworksStrings[1]);

            Console.WriteLine("Save Endpoint -> Calling MultiNetworkSelectViewModel.SetupDefault()");

            var multiNetworkSelectViewModel = DependencyService.Get<MultiNetworkSelectViewModel>();
            multiNetworkSelectViewModel.SetupDefault();
        }

        private static void ShowRestartNeededMessage()
        {
            // Tell the user that they need to restart the app.
            var messagePopup = DependencyService.Get<MessagePopupViewModel>();

            messagePopup.Title = "Restart needed";
            messagePopup.Text = "Please, restart PlutoFramework app to apply changes to the layout.";

            messagePopup.IsVisible = true;
        }

        /**
         * This is used to say nicely that the PlutoLayout has been imported
         * 
         * usually overrides the ShowRestartNeededMessage() method
         */
        public static void ShowImportSuccessfulRestartNeededMessage()
        {
            // Tell the user that they need to restart the app.
            var messagePopup = DependencyService.Get<MessagePopupViewModel>();

            messagePopup.Title = "Pluto layout imported!";
            messagePopup.Text = "Please, restart PlutoFramework app to apply changes to the layout.";

            messagePopup.IsVisible = true;
        }

        public static IView GetView(ComponentId componentId)
        {
            switch (componentId)
            {
                case ComponentId.U:
                    return new UpdateView();
                case ComponentId.dApp:
                    return new DAppConnectionView();
                case ComponentId.ExSL:
                    return new ExtrinsicStatusStackLayout();
                case ComponentId.UsdB:
                    return new UsdBalanceView();
                /*case ComponentId.PubK:
                    return new AddressView
                    {
                        Title = "Public key",
                        Address = KeysModel.GetPublicKey(),
                        QrAddress = KeysModel.GetPublicKey(),
                    };*/
                case ComponentId.SubK:
                    return new SubstrateAddressView();
                case ComponentId.ChaK:
                    return new ChainAddressView();
                /*case ComponentId.StDash:
                    return new StakingDashboardView();
                case ComponentId.CalEx:
                    return new CalamarView();
                case ComponentId.AAASeasonCountdown:
                    return new SeasonCountdownView();*/
                case ComponentId.AAALeaderboard:
                    return new AAALeaderboard();
                case ComponentId.contract:
                    return new ContractView();
                case ComponentId.AZEROPrimaryName:
                    return new AzeroPrimaryNameView();
                case ComponentId.HDXOmniLiquidity:
                    return new OmnipoolLiquidityView();
                case ComponentId.HDXDCA:
                    return new DCAView();
                case ComponentId.id:
                    return new IdentityView();
                case ComponentId.Ref:
                    return new ReferendaView();
                case ComponentId.BMnR:
                    return new BackupMnemonicsReminderView();
                case ComponentId.RnT:
                    return new ReceiveAndTransferView();
                case ComponentId.NftG:
                    return new NftFavouriteGalleryView();
                case ComponentId.NftOG:
                    return new NftOwnedGalleryView();
                case ComponentId.NftFG:
                    return new NftFavouriteGalleryView();
                /*case ComponentId.FeeA:
                    return new FeeAssetView();*/
                case ComponentId.VDot:
                    return new VDotTokenView();
                case ComponentId.GLGPowerups:
                    return new GLGPowerupsView();
                case ComponentId.xTrnsfr:
                    return new XcmTransferView();
            }

            throw new Exception("Could not parse the PlutoLayout");
        }

        public static ComponentInfo GetComponentInfo(ComponentId componentId)
        {
            switch (componentId)
            {
                case ComponentId.U:
                    return new ComponentInfo
                    {
                        Name = "Update notification",
                        ComponentId = ComponentId.U
                    };
                case ComponentId.dApp:
                    return new ComponentInfo
                    {
                        Name = "dApp connection",
                        ComponentId = ComponentId.dApp,
                    };
                case ComponentId.ExSL:
                    return new ComponentInfo
                    {
                        Name = "Extrinsic status",
                        ComponentId = ComponentId.ExSL,
                    };
                case ComponentId.UsdB:
                    return new ComponentInfo
                    {
                        Name = "Balance",
                        ComponentId = ComponentId.UsdB,
                    };
                /*case ComponentId.PubK:
                    return new ComponentInfo
                    {
                        Name = "Public key",
                        ComponentId = ComponentId.PubK,
                    };*/
                case ComponentId.SubK:
                    return new ComponentInfo
                    {
                        Name = "Substrate key",
                        ComponentId = ComponentId.SubK,
                    };
                case ComponentId.ChaK:
                    return new ComponentInfo
                    {
                        Name = "Chain specific key",
                        ComponentId = ComponentId.ChaK,
                    };
                /*case ComponentId.StDash:
                    return new ComponentInfo
                    {
                        Name = "Staking dashboard",
                        ComponentId = ComponentId.StDash,
                    };
                case ComponentId.CalEx:
                    return new ComponentInfo
                    {
                        Name = "Calamar",
                        ComponentId = ComponentId.CalEx,
                    };
                case ComponentId.AAASeasonCountdown:
                    return new ComponentInfo
                    {
                        Name = "AAA Season countdown",
                        ComponentId = ComponentId.AAASeasonCountdown,
                    };*/
                case ComponentId.AAALeaderboard:
                    return new ComponentInfo
                    {
                        Name = "AAA Leaderboard",
                        ComponentId = ComponentId.AAALeaderboard,
                    };
                case ComponentId.contract:
                    return new ComponentInfo
                    {
                        Name = "Contract",
                        ComponentId = ComponentId.contract,
                    };
                case ComponentId.AZEROPrimaryName:
                    return new ComponentInfo
                    {
                        Name = "AZERO.ID Primary Name",
                        ComponentId = ComponentId.AZEROPrimaryName,
                    };
                case ComponentId.HDXOmniLiquidity:
                    return new ComponentInfo
                    {
                        Name = "Hydration Omnipool Liquidity",
                        ComponentId = ComponentId.HDXOmniLiquidity,
                    };
                case ComponentId.HDXDCA:
                    return new ComponentInfo
                    {
                        Name = "Hydration DCA Position",
                        ComponentId = ComponentId.HDXDCA,
                    };
                case ComponentId.id:
                    return new ComponentInfo
                    {
                        Name = "Identity",
                        ComponentId = ComponentId.id,
                    };
                case ComponentId.Ref:
                    return new ComponentInfo
                    {
                        Name = "Referenda",
                        ComponentId = ComponentId.Ref,
                    };
                case ComponentId.BMnR:
                    return new ComponentInfo
                    {
                        Name = "Backup Mnemonics Reminder",
                        ComponentId = ComponentId.BMnR,
                    };
                case ComponentId.RnT:
                    return new ComponentInfo
                    {
                        Name = "Receive and Transfer",
                        ComponentId = ComponentId.RnT,
                    };
                case ComponentId.NftG:
                    return new ComponentInfo
                    {
                        Name = "Nft Galery",
                        ComponentId = ComponentId.NftG,
                    };
                case ComponentId.NftOG:
                    return new ComponentInfo
                    {
                        Name = "Onwed Nfts Galery",
                        ComponentId = ComponentId.NftOG,
                    };
                case ComponentId.NftFG:
                    return new ComponentInfo
                    {
                        Name = "Favourite Nfts Galery",
                        ComponentId = ComponentId.NftFG,
                    };
                /*case ComponentId.FeeA:
                    return new ComponentInfo
                    {
                        Name = "Fee Asset",
                        ComponentId = ComponentId.FeeA,
                    };*/
                case ComponentId.VDot:
                    return new ComponentInfo
                    {
                        Name = "vDOT staking",
                        ComponentId = ComponentId.VDot,
                    };
                case ComponentId.GLGPowerups:
                    return new ComponentInfo
                    {
                        Name = "Galaxy Logic Game Powerups",
                        ComponentId = ComponentId.GLGPowerups,
                    };
                case ComponentId.xTrnsfr:
                    return new ComponentInfo
                    {
                        Name = "XCM Transfer",
                        ComponentId = ComponentId.xTrnsfr,
                    };
            }

            throw new Exception("Could not parse the ComponentId");
        }

        public static string GetLayoutString(string plutoLayout)
        {
            switch (plutoLayout)
            {
                case "GalaxyLogicGame":
                    return GalaxyLogicGameLayoutItem.LAYOUT;
                case "AwesomeAjunaAwatars":
                    return AwesomaAjunaAvatarsLayoutItem.LAYOUT;
                case "Hydration":
                    return HydrationOmnipoolLayoutItem.LAYOUT;
            }

            throw new Exception("Could not parse the PlutoLayout");
        }
    }
}

