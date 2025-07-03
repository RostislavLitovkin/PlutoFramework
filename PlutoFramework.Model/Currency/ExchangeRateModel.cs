namespace PlutoFramework.Model.Currency
{
    public static class ExchangeRateModel
    {
        public static string ToCurrencyString(
            this double usdValue,
            string? location = null
        )
        {
            location ??= AppConfigurationModel.Location;
            var currency = GetCurrencyInLocation(location);

            return $"{currency}{String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, ExchangeRateModel.GetExchangeRate("USDT", currency) * usdValue)}";
        }

        public static double GetExchangeRate(string fromCurrency, string toCurrency)
        {
            if (fromCurrency == "USDT" && toCurrency == "£")
            {
                return DefaultAppConfiguration.POUNDS_TO_USD;
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
