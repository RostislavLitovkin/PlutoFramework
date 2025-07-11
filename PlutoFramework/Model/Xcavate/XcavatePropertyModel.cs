namespace PlutoFramework.Model.Xcavate
{
    public class XcavatePropertyModel
    {
        public static double GetAreaPricesPercentage(long price)
        {
            // TODO
            return 0.7;
        }

        public static double GetRentalDemand()
        {
            // TODO
            return 0.3;
        }

        public static string GetAPY(uint rentalIncome, long price)
        {
            var ari = rentalIncome * 12;
            var apy = (double)ari / price;
            return $"{String.Format("{0:0.00}", apy * 100.0)}%";
        }
    }
}
