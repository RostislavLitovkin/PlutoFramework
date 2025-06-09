using Amazon.S3;
using Microsoft.Extensions.Configuration;
using PlutoFramework.Constants;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.Model;
using UniqueryPlus.Nfts;
using Amazon;
using CommunityToolkit.Maui.Alerts;
using PlutoFramework.Model.SQLite;

namespace PlutoFramework.Components.XcavateProperty
{
    public class XcavateNftWrapper : NftWrapper
    {
        public required XcavateRegion Region { get; set; }
    }

    public class XcavatePropertyModel
    {
        public static async Task<XcavateNftWrapper> ToXcavateNftWrapperAsync(INftXcavateBase nft, CancellationToken token)
        {
            try
            {
                var configuration = MauiProgram.Services.GetService<IConfiguration>();

                RegionEndpoint region = RegionEndpoint.EUWest1;

                IAmazonS3 s3Client = new AmazonS3Client(
                    configuration.GetValue<string>("DYNAMO_ACCESS_KEY"),
                    configuration.GetValue<string>("DYNAMO_SECRET_KEY"),
                    region);

                // Handle S3
                if (nft.XcavateMetadata is not null)
                {
                    var images = new List<string>();

                    foreach (var file in nft.XcavateMetadata.Files.Where(file =>
                        (file.Contains(".jpg") || file.Contains(".jpeg") || file.Contains(".png")) && file[0] == '5'
                    ))
                    {
                        const string bucketName = "real-marketplace-properties";

                        var presignedUrl = await S3Model.GeneratePresignedURLAsync(s3Client, bucketName, file);

                        images.Add(presignedUrl);
                    }
                    nft.XcavateMetadata.Images = images;
                }

                /*if (nft.Metadata is not null && nft.Metadata.Image is null)
                {
                    nft.Metadata.Image = "noimage.png";
                }*/
            }
            catch(Exception ex)
            {
                Console.WriteLine("To Xcavate nft wrapper error:");
                Console.WriteLine(ex);
            }
            
            return new XcavateNftWrapper
            {
                Favourite = await XcavatePropertyDatabase.IsPropertyFavouriteAsync(nft.Type, nft.CollectionId, nft.Id).ConfigureAwait(false),
                NftBase = nft,
                Region = await RegionModel.GetCachedRegionAsync(await SubstrateClientModel.GetOrAddSubstrateClientAsync(Model.NftModel.GetEndpointKey(nft.Type), token), ((INftXcavateNftMarketplace)nft).NftMarketplaceDetails.Region, token),
                Endpoint = Endpoints.GetEndpointDictionary[Model.NftModel.GetEndpointKey(nft.Type)]
            };
        }

        public static async Task NavigateToPropertyDetailPageAsync(XcavateNftWrapper nft, CancellationToken token)
        {
            if (nft.NftBase is SavedXcavatePropertyBase)
            {
                nft.NftBase = await nft.NftBase.GetFullAsync(token);
            }
            if (nft.NftBase is not INftXcavateMetadata || ((INftXcavateMetadata)nft.NftBase).XcavateMetadata is null || nft.NftBase is not INftXcavateNftMarketplace)
            {
                var toast = Toast.Make("Could not navigate.");
                await toast.Show();

                return;
            }

            var viewModel = new PropertyDetailViewModel
            {
                Endpoint = nft.Endpoint,
                Favourite = nft.Favourite,
                NftBase = nft.NftBase,
                Metadata = ((INftXcavateMetadata)nft.NftBase).XcavateMetadata,
                NftMarketplaceDetails = ((INftXcavateNftMarketplace)nft.NftBase).NftMarketplaceDetails,
                Region = nft.Region,
            };

            if (nft.Key is not null && XcavateOwnedPropertiesModel.ItemsDict.TryGetValue(nft.Key.Value, out PropertyTokenOwnershipInfo tokenInfo))
            {
                viewModel.TokensOwned = tokenInfo.Amount;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new PropertyDetailPage(viewModel));
        }
    }
}
