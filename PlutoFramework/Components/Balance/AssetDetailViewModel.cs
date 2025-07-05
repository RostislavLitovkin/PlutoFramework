using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.HydraDX;
using SkiaSharp;

namespace PlutoFramework.Components.Balance
{
    public partial class AssetDetailViewModel : ObservableObject
    {
        private const uint CHART_STEPS = 20;

        [ObservableProperty]
        private AssetInfo assetInfo;

        [ObservableProperty]
        private Interval chartInterval = Interval.Daily;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MinLayoutBounds))]
        private double minXPosition = 0;

        public Rect MinLayoutBounds => new Rect(MinXPosition, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize);

        [ObservableProperty]
        private string minText = "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MaxLayoutBounds))]
        private double maxXPosition = 0;

        public Rect MaxLayoutBounds => new Rect(MaxXPosition, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize);

        [ObservableProperty]
        private string maxText = "";

        partial void OnChartIntervalChanged(Interval value)
        {
            _ = LoadAsync(CancellationToken.None);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chart))]
        private IEnumerable<(uint, double)> prices = [];

        public LineChart Chart {
            get {
                if (!Prices.Any())
                {
                    return null;
                }

                var entries = GetChartEntries();

                var min = entries.Min(e => e.Value);
                var max = entries.Max(e => e.Value);

                var minIndex = entries.ToList().FindIndex(e => e.Value == min);
                var maxIndex = entries.ToList().FindIndex(e => e.Value == max);

                MinText = ((double)min.Value).ToCurrencyString(currencyFormat: "{0:0.00}");
                MaxText = ((double)max.Value).ToCurrencyString(currencyFormat: "{0:0.00}");

                MinXPosition = (double)minIndex / CHART_STEPS;
                MaxXPosition = (double)maxIndex / CHART_STEPS;

                return new LineChart
                {
                    Margin = 0,
                    LabelTextSize = 32,
                    LabelOrientation = Orientation.Vertical,
                    LineSize = 20,
                    MinValue = min.Value * 0.9f,
                    MaxValue = max.Value * 1.1f,
                    Entries = entries,
                    ValueLabelOrientation = Orientation.Vertical,
                    ValueLabelOption = ValueLabelOption.TopOfElement,
                    ValueLabelTextSize = 32,
                    PointMode = PointMode.None,
                    Typeface = SKTypeface.FromFamilyName("XcavateFont"),
                };
            }
        }

        public async Task LoadAsync(CancellationToken token)
        {
            var hydrationClient = await SubstrateClientModel.GetOrAddSubstrateClientAsync(Constants.EndpointEnum.Hydration, token);

            Prices = await Sdk.GetRestrospectiveSpotPricesAsync(hydrationClient, ChartInterval, AssetInfo.Symbol, CHART_STEPS, token);
        }

        private IEnumerable<ChartEntry> GetChartEntries()
        {
            return Prices.Select((blocknumberPrice, index) =>
            {
                (var blocknumber, var price) = blocknumberPrice;

                var color = SKColor.Parse(((Color)Application.Current.Resources["Primary"]).ToHex());

                return new ChartEntry((float)price)
                {
                    Color = color,
                    ValueLabelColor = color,
                    Label = (index + 3) % 5 == 0 ? GetDateString(CHART_STEPS - (uint)index, ChartInterval) : null,
                };
            });
        }

        private string GetDateString(uint minus, Interval interval)
        {
            var now = DateTime.Now;

            var timeString = interval switch
            {
                Interval.Hourly => now.AddHours(-minus).ToString("hh:mm"),
                Interval.Daily => now.AddDays(-minus).ToString("MMMM d"),
                Interval.Weekly => now.AddDays(-7 * minus).ToString("MMMM d"),
                _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
            };

            return $"  {timeString}  ";
        }

    }
}
