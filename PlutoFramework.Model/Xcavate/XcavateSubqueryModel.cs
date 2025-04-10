using UniqueryPlus.Collections;
using UniqueryPlus.Ipfs;
using UniqueryPlus.Metadata;
using UniqueryPlus;
using XcavateSubquery;
using XcavatePaseo.NetApi.Generated;
using StrawberryShake;
using UniqueryPlus.Nfts;
using System.Text.Json;
using System.Numerics;

namespace PlutoFramework.Model.Xcavate
{
    public class XcavateSubqueryModel
    {
        public static IXcavateSubquery GetXcavateSubqueryClient()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddXcavateSubquery()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://api.subquery.network/sq/XcavateBlockchain/realxmarket"));

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            return services.GetRequiredService<IXcavateSubquery>();
        }        
        public static async Task<IEnumerable<INftBase>> GetPropertiesForSaleAsync(SubstrateClientExt client, int limit = 25, int offset = 0, CancellationToken token = default)
        {
            var subqueryClient = GetXcavateSubqueryClient();

            var result = await subqueryClient.PropertyListings.ExecuteAsync(limit, offset).ConfigureAwait(false);

            result.EnsureNoErrors();

            if (result.Data is null || result.Data.PropertyListings is null)
            {
                Console.WriteLine("Was null");
                return [];
            }

            return result.Data.PropertyListings.Nodes.Select(property =>
            {
                var fileUrls = JsonSerializer.Deserialize<List<string>>(property.Files);

                return new XcavatePaseoNftsPalletNft(client)
                {
                    CollectionId = BigInteger.Parse(property.PropertyId),
                    Owner = property.Signer,
                    Metadata = new MetadataBase
                    {
                        Name = property.PropertyName ?? "Unknown",
                        Description = property.PropertyDescription ?? "",
                        Image = IpfsModel.ToIpfsLink(fileUrls?.ElementAtOrDefault(0) ?? "")
                    },
                    XcavateMetadata = new XcavateMetadata
                    {
                        PropertyName = property.PropertyName ?? "Unknown",
                        PropertyDescription = property.PropertyDescription ?? "",
                        PropertyId = long.Parse(property.PropertyId),
                        PropertyType = property.PropertyType,
                        PropertyPrice = long.Parse(property.PropertyPrice),
                        Location = 1,
                        Area = property.Area,
                        NoOfBedrooms = property.NoOfBedrooms.ToString(),
                        NoOfBathrooms = property.NoOfBedrooms.ToString(),
                        ConstructionDate = property.ConstructionDate,
                        OffStreetParking = property.OffStreetParking,
                        OutdoorSpace = property.OutdoorSpace,
                        PlanningPermissionCode = property.PlanningPermissionCode,
                        Region = property.Region,
                        TitleDeedNumber = property.TitleDeedNumber,
                        AddressStreet = property.AddressStreet,
                        AddressTownCity = property.AddressTownCity,
                        Files = fileUrls ?? [],
                        Images = fileUrls ?? []
                    }
                };
            });
        }
    }
}
