using Amazon.S3;
using Microsoft.Extensions.Configuration;
using PlutoFramework.Constants;
using PlutoFramework.Model.XCavate;
using PlutoFramework.Model;
using UniqueryPlus.Nfts;
using Amazon;

namespace PlutoFramework.Components.XcavateProperty
{
    
    public class XCavatePropertyModel
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
        public static async Task<NftWrapper> ToNftWrapperAsync(XCavatePaseoNftsPalletNft nft)
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
                if (nft.XCavateMetadata is not null)
                {
                    var images = new List<string>();

                    foreach (var file in nft.XCavateMetadata.Files.Where(file =>
                        (file.Contains(".jpg") || file.Contains(".jpeg") || file.Contains(".png")) && file[0] == '5'
                    ))
                    {
                        const string bucketName = "real-marketplace-properties";

                        var presignedUrl = await S3Model.GeneratePresignedURLAsync(s3Client, bucketName, file);

                        images.Add(presignedUrl);
                    }
                    nft.XCavateMetadata.Images = images;
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

        public static async Task NavigateToPropertyDetailPageAsync(XCavatePaseoNftsPalletNft nft, CancellationToken token)
        {
            if (nft.XCavateMetadata is null)
            {
                return;
            }

            var viewModel = new PropertyDetailViewModel
            {
                AreaPricesPercentage = GetAreaPricesPercentage(nft.XCavateMetadata.PropertyPrice),
                RentalDemandPercentage = GetRentalDemand(),

                CompanyName = "Bob T builder",

                CompanyImage = "xcavate.png",

                LocationName = nft.XCavateMetadata.LocationName,

                PropertyName = nft.XCavateMetadata.PropertyName,

                ListingPrice = $"£{nft.XCavateMetadata.PropertyPrice}",
                Apy = GetAPY(nft.XCavateMetadata.EstimatedRentalIncome, nft.XCavateMetadata.PropertyPrice),
                Tokens = nft.NftMarketplaceDetails.Listed,
                MaxTokens = nft.XCavateMetadata.NumberOfTokens,
                PropertyType = nft.XCavateMetadata.PropertyType,

                PropertyDescription = nft.XCavateMetadata.PropertyDescription,

                Blocks = nft.XCavateMetadata.Area,
                Bedrooms = nft.XCavateMetadata.NoOfBedrooms,
                Bathrooms = nft.XCavateMetadata.NoOfBathrooms,
                Type = nft.XCavateMetadata.PropertyType,
                LocationShortName = $"{nft.XCavateMetadata.AddressStreet}, {nft.XCavateMetadata.AddressTownCity}",

                UsdtPricePerToken = nft.XCavateMetadata.PricePerToken,

                RentalIncome = $"£{nft.XCavateMetadata.EstimatedRentalIncome}",

                Images = nft.XCavateMetadata.Images,
            };

            await Application.Current.MainPage.Navigation.PushAsync(new PropertyDetailPage(viewModel));
        }
    }
}
