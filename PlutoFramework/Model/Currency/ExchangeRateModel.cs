namespace PlutoFramework.Model.Currency
{
    public static class ExchangeRateModel
    {
        public static string ToCurrencyString(
            this double usdValue,
            string? location = null,
            string? currencyFormat = null
        )
        {
            return ToCurrencyString((decimal)usdValue, location, currencyFormat);
        }

        public static string ToCurrencyString(
            this decimal usdValue,
            string? location = null,
            string? currencyFormat = null
        )
        {
            currencyFormat ??= (string)Application.Current.Resources["CurrencyFormat"];

            location ??= AppConfigurationModel.Location;
            var currency = GetCurrencyInLocation(location);

            return $"{currency}{String.Format(currencyFormat, (decimal)ExchangeRateModel.GetExchangeRate("USDT", currency) * usdValue)}";
        }

        public static double GetExchangeRate(string fromCurrency, string toCurrency)
        {
            if (fromCurrency == "USDT" && toCurrency == "£")
            {
                return (double)Application.Current.Resources["UsdToGbp"];
            }
            if (fromCurrency == "USDT" && toCurrency == "$")
            {
                return 1;
            }

            return 1;
        }

        public static string GetCurrencyInLocation(string location)
        {
            if (location == "UK")
            {
                return "£";
            }

            if (location == "US")
            {
                return "$";
            }

            return "$";
        }
    }
}
