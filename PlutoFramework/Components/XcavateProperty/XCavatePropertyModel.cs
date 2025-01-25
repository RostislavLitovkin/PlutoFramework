
using UniqueryPlus.Nfts;

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

        private static string GetAPY(uint rentalIncome, uint price)
        {
            var ari = rentalIncome * 12;
            var apy = (double)ari / price;
            return $"{String.Format("{0:0.00}", apy * 100.0)}";
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

                LocationName = $"{nft.XCavateMetadata.AddressStreet}, {nft.XCavateMetadata.AddressTownCity}",

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

                Images = [
                    "https://www.nintendo.com/eu/media/images/assets/nintendo_switch_games/xenobladechroniclesxdefinitiveedition/nswitch_xenobladechroniclesxdefinitiveedition/XenobladeChroniclesXDefinitiveEdition_27.png",
                    "https://www.nintendo.com/eu/media/images/assets/nintendo_switch_games/xenobladechroniclesxdefinitiveedition/nswitch_xenobladechroniclesxdefinitiveedition/XenobladeChroniclesXDefinitiveEdition_GP_19.png",
                ]
            };

            await Application.Current.MainPage.Navigation.PushAsync(new PropertyDetailPage(viewModel));
        }
    }
}
