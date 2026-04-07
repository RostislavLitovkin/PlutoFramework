namespace PlutoFramework.Model.Xcavate
{
    public class XcavatePropertyModel
    {
        public static double GetAreaPricesPercentage(decimal price)
        {
            // TODO
            return 0.7;
        }

        public static double GetRentalDemand()
        {
            // TODO
            return 0.8;
        }

        public static string GetAPY(decimal rentalIncome, decimal price)
        {
            if (price == 0)
            {
                return "0.00%";
            }

            var ari = rentalIncome * 12;
            var apy = ari / price;
            return $"{String.Format("{0:0.00}", apy * 100)}%";
        }
    }
}
