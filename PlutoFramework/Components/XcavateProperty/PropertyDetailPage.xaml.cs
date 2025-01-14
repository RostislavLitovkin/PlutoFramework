namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyDetailPage : ContentPage
{
    public PropertyDetailPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = new PropertyDetailViewModel
        {
            AreaPricesPercentage = 0.7,

            RentalDemandPercentage = 0.3,

            CompanyName = "Gade homes",

            CompanyImage = "xcavate.png",

            LocationName = "Herford, Hertfordshire UK",

            PropertyName = "Plot 1 - Plea Wharf",

            ListingPrice = "£200,000",
            Apy = "5%",
            Tokens = 15,
            MaxTokens = 100,
            PropertyType = "Appartment / Flat",

            PropertyDescription = "XCAV is the native token of the Xcavate ecosystem and has several utilities. XCAV will be used in on-chain governance, allowing holders to decide on protocol changes and parameters (such as the protocol fee). This also gives holders the power to allocate funds from the treasury to further the growth and development of the network. The treasury will get an initial allocation of XCAV tokens (see below) and acquire further inflows by collecting protocol fees",

            Blocks = "10",
            Bedrooms = "3",
            Bathrooms = "2",
            Type = "Appartment",
            LocationShortName = "Herford UK",

            UsdtPricePerToken = 2300.0,

            RentalIncome = "£1,000 pcm",
        };

        ((PropertyDetailViewModel)BindingContext).Images = [
                "https://www.nintendo.com/eu/media/images/assets/nintendo_switch_games/xenobladechroniclesxdefinitiveedition/nswitch_xenobladechroniclesxdefinitiveedition/XenobladeChroniclesXDefinitiveEdition_27.png",
                "https://www.nintendo.com/eu/media/images/assets/nintendo_switch_games/xenobladechroniclesxdefinitiveedition/nswitch_xenobladechroniclesxdefinitiveedition/XenobladeChroniclesXDefinitiveEdition_GP_19.png",
                "xcavatergb.png",
            ];
    }
}