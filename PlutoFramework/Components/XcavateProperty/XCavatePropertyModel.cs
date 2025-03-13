using Amazon.S3;
using Microsoft.Extensions.Configuration;
using PlutoFramework.Constants;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.Model;
using UniqueryPlus.Nfts;
using Amazon;

namespace PlutoFramework.Components.XcavateProperty
{
    
    public class XcavatePropertyModel
    {
        public static async Task<NftWrapper> ToNftWrapperAsync(XcavatePaseoNftsPalletNft nft)
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
                Console.WriteLine("To wrapper error:");
                Console.WriteLine(ex);
            }

            return new NftWrapper
            {
                NftBase = nft,
                Endpoint = Endpoints.GetEndpointDictionary[Model.NftModel.GetEndpointKey(nft.Type)]
            };
        }

        public static async Task NavigateToPropertyDetailPageAsync(XcavatePaseoNftsPalletNft nft, CancellationToken token)
        {
            if (nft.XcavateMetadata is null)
            {
                return;
            }

            var viewModel = new PropertyDetailViewModel
            {
                Metadata = nft.XcavateMetadata,
                NftMarketplaceDetails = nft.NftMarketplaceDetails,
            };

            await Application.Current.MainPage.Navigation.PushAsync(new PropertyDetailPage(viewModel));
        }
    }
}
