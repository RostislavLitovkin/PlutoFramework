using PlutoFramework.Constants;

namespace PlutoFramework.Model
{
    public static class EndpointsModel
    {
        public static IEnumerable<EndpointEnum> GetSelectedEndpointKeys()
        {
            return Preferences.Get("SelectedNetworks", (string)Application.Current.Resources["DefaultEndpoints"])
                .ToEndpointEnums();
        }

        public static IEnumerable<EndpointEnum> ToEndpointEnums(this string plutoLayoutKeys)
        {
            return plutoLayoutKeys
                .Trim(new char[] { '[', ']' })
                .Split(',')
                .ToEndpointEnums();
        }

        public static IEnumerable<EndpointEnum> ToEndpointEnums(this string[] keys)
        {
            try
            {
                return keys.Select(str => (EndpointEnum)EndpointEnum.Parse(typeof(EndpointEnum), str));
            }
            catch
            {
                return [EndpointEnum.Polkadot, EndpointEnum.Kusama];
            }
        }

        public static void SaveEndpoint(EndpointEnum newKey, bool setupMultiNetworkSelect = true)
        {
            var savedKeys = GetSelectedEndpointKeys().Append(newKey);

            SaveEndpoints(savedKeys, setupMultiNetworkSelect);
        }

        public static void SaveEndpoints(IEnumerable<EndpointEnum> keys, bool setupMultiNetworkSelect = true)
        {
            string result = "[";
            if (keys.Count() == 0)
            {
                result = "[Polkadot]";
            }
            else
            {
                foreach(var key in keys)
                {
                    result += key + ", ";
                }

                result = result.Substring(0, result.Length - 2) + "]";
            }

            Preferences.Set("SelectedNetworks", result);

            // Save it in the plutolayout:
            string plutoLayoutString = Preferences.Get("PlutoLayout", CustomLayoutModel.DEFAULT_PLUTO_LAYOUT);

            string[] itemsAndNetworksStrings = plutoLayoutString.Split(";");

            string plutoLayoutResult = itemsAndNetworksStrings[0] + ";" + result;

            for (int i = 2; i < itemsAndNetworksStrings.Length; i++)
            {
                plutoLayoutResult += ";" + itemsAndNetworksStrings[i];
            }

            Preferences.Set("PlutoLayout", plutoLayoutResult);

            if (setupMultiNetworkSelect)
            {
                _ = SubstrateClientModel.ChangeConnectedClientsAsync(keys, CancellationToken.None);
            }
        }

        public static Endpoint GetEndpoint(EndpointEnum key)
        {
            return Endpoints.GetEndpointDictionary[key];
        }

        public static List<Endpoint> GetNftEndpoints
        {
            get
            {
                List<Endpoint> endpoints = Endpoints.GetAllEndpoints;

                foreach (Endpoint endpoint in endpoints)
                {
                    if (!endpoint.SupportsNfts)
                    {
                        endpoints.Remove(endpoint);
                    }
                }

                return endpoints;
            }
        }
    }
}

