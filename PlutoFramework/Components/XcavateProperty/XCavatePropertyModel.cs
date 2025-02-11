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
        private static double GetAreaPricesPercentage(uint price)
        {
            // TODO
            return 0.7;
        }

        private static double GetRentalDemand()
        {
            // TODO
            return 0.3;
        }

        public static string GetAPY(uint rentalIncome, uint price)
        {
            var ari = rentalIncome * 12;
            var apy = (double)ari / price;
            return $"{String.Format("{0:0.00}", apy * 100.0)}%";
        }
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

                Console.WriteLine("Property name: " + nft.Type + " " + nft.CollectionId + " - " + nft.Id);

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
                AreaPricesPercentage = GetAreaPricesPercentage(nft.XcavateMetadata.PropertyPrice),
                RentalDemandPercentage = GetRentalDemand(),

                CompanyName = "Bob T builder",

                CompanyImage = "xcavate.png",

                LocationName = nft.XcavateMetadata.LocationName,

                PropertyName = nft.XcavateMetadata.PropertyName,

                ListingPrice = $"£{nft.XcavateMetadata.PropertyPrice}",
                Apy = GetAPY(nft.XcavateMetadata.EstimatedRentalIncome, nft.XcavateMetadata.PropertyPrice),
                Tokens = nft.NftMarketplaceDetails.Listed,
                MaxTokens = nft.XcavateMetadata.NumberOfTokens,
                PropertyType = nft.XcavateMetadata.PropertyType,

                PropertyDescription = nft.XcavateMetadata.PropertyDescription,

                Blocks = nft.XcavateMetadata.Area,
                Bedrooms = nft.XcavateMetadata.NoOfBedrooms,
                Bathrooms = nft.XcavateMetadata.NoOfBathrooms,
                Type = nft.XcavateMetadata.PropertyType,
                LocationShortName = $"{nft.XcavateMetadata.AddressStreet}, {nft.XcavateMetadata.AddressTownCity}",

                UsdtPricePerToken = nft.XcavateMetadata.PricePerToken,

                RentalIncome = $"£{nft.XcavateMetadata.EstimatedRentalIncome}",

                Images = nft.XcavateMetadata.Images,
            };

            await Application.Current.MainPage.Navigation.PushAsync(new PropertyDetailPage(viewModel));
        }
    }
}
