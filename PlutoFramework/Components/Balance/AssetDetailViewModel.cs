using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microcharts;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.HydraDX;
using SkiaSharp;

namespace PlutoFramework.Components.Balance
{
    public partial class AssetDetailViewModel : ObservableObject
    {
        public bool MinMaxIsVisible => MinText != MaxText;

        private const uint CHART_STEPS = 24;

        [ObservableProperty]
        private AssetInfo assetInfo;

        [ObservableProperty]
        private string time1Text;

        [ObservableProperty]
        private string time2Text;

        [ObservableProperty]
        private string time3Text;

        [ObservableProperty]
        private string time4Text;

        [ObservableProperty]
        public string pricePerTokenText = "Loading";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HourlyIsSelected))]
        [NotifyPropertyChangedFor(nameof(DailyIsSelected))]
        [NotifyPropertyChangedFor(nameof(WeeklyIsSelected))]
        private Interval chartInterval = Interval.Daily;

        public bool HourlyIsSelected => ChartInterval == Interval.Hourly;
        public bool DailyIsSelected => ChartInterval == Interval.Daily;
        public bool WeeklyIsSelected => ChartInterval == Interval.Weekly;


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MinLayoutBounds))]
        [NotifyPropertyChangedFor(nameof(MinMargin))]
        private double minXPosition = 0;

        public Rect MinLayoutBounds => new Rect(MinXPosition, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize);
        public Thickness MinMargin => MinXPosition switch
        {
            0 => new Thickness(15, 0, 0, 0),
            1 => new Thickness(0, 0, 15, 0),
            _ => new Thickness(0)
        };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MinMaxIsVisible))]
        private string minText = "";


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MaxLayoutBounds))]
        [NotifyPropertyChangedFor(nameof(MaxMargin))]
        private double maxXPosition = 0;
        
        public Rect MaxLayoutBounds => new Rect(MaxXPosition, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize);

        public Thickness MaxMargin => MaxXPosition switch
        {
            0 => new Thickness(15, 0, 0, 0),
            1 => new Thickness(0, 0, 15, 0),
            _ => new Thickness(0)
        };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MinMaxIsVisible))]
        private string maxText = "";


        partial void OnChartIntervalChanged(Interval value)
        {
            _ = LoadAsync(CancellationToken.None);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Chart))]
        private IEnumerable<(uint, double?)> prices = [];

        private IEnumerable<ChartEntry> GetDefaultEntries() {
            var color = SKColor.Parse(((Color)Application.Current.Resources["Primary"]).ToHex());
            
            return Enumerable.Range(0, (int)CHART_STEPS).Select(_ =>
                new ChartEntry(1)
                {
                    Color = color,
                    ValueLabelColor = color,
                });
        }

        public LineChart Chart
        {
            get
            {
                if (!Prices.Any())
                {


                    return new LineChart
                    {
                        Margin = 0,
                        LabelTextSize = 32,
                        LabelOrientation = Orientation.Vertical,
                        LineSize = 20,
                        MinValue = 0,
                        MaxValue = 2,
                        Entries = GetDefaultEntries(),
                        ValueLabelOrientation = Orientation.Vertical,
                        ValueLabelOption = ValueLabelOption.TopOfElement,
                        ValueLabelTextSize = 32,
                        PointMode = PointMode.None,
                        Typeface = SKTypeface.FromFamilyName("XcavateFont"),
                    };
                }

                var entries = GetChartEntries();

                if (entries == null || entries.Count() < CHART_STEPS) {
                    entries = GetDefaultEntries();
                }

                var min = entries.Min(e => e.Value);
                var max = entries.Max(e => e.Value);

                var minIndex = entries.ToList().FindIndex(e => e.Value == min);
                var maxIndex = entries.ToList().FindIndex(e => e.Value == max);

                var tenPercentDifference = (max.Value - min.Value) * 0.1;

                MinText = ((double)min.Value).ToCurrencyString(currencyFormat: "{0:0.00}");
                MaxText = ((double)max.Value).ToCurrencyString(currencyFormat: "{0:0.00}");

                MinXPosition = (double)minIndex / (CHART_STEPS - 1);
                MaxXPosition = (double)maxIndex / (CHART_STEPS - 1);

                uint midStep = CHART_STEPS / 8;
                Time1Text = GetDateString((CHART_STEPS * 4) / 4 + midStep, ChartInterval);
                Time2Text = GetDateString((CHART_STEPS * 3) / 4 + midStep, ChartInterval);
                Time3Text = GetDateString((CHART_STEPS * 2) / 4 + midStep, ChartInterval);
                Time4Text = GetDateString((CHART_STEPS * 1) / 4 + midStep, ChartInterval);

                return new LineChart
                {
                    Margin = 0,
                    LabelTextSize = 32,
                    LabelOrientation = Orientation.Vertical,
                    LineSize = 20,
                    MinValue = (float)(min.Value - tenPercentDifference),
                    MaxValue = (float)(max.Value + tenPercentDifference),
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

            PricePerTokenText = ((double)Sdk.GetSpotPrice(AssetInfo.Symbol)).ToCurrencyString(currencyFormat: "{0:0.00}");
        }

        private IEnumerable<ChartEntry> GetChartEntries()
        {
            var color = SKColor.Parse(((Color)Application.Current.Resources["Primary"]).ToHex());

            return Prices.Select((blocknumberPrice, index) =>
            {
                (var blocknumber, double? price) = blocknumberPrice;

                if (price is null)
                {
                    var spotPrice = Sdk.GetSpotPrice(AssetInfo.Symbol);

                    return new ChartEntry((float)spotPrice)
                    {
                        Color = color,
                        ValueLabelColor = color,
                    };
                }
                return new ChartEntry((float)price)
                {
                    Color = color,
                    ValueLabelColor = color,
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

            return $"{timeString}";
        }


        [RelayCommand]
        public void ChangeChartInterval(Interval interval)
        {
            if (ChartInterval == interval)
            {
                return;
            }

            ChartInterval = interval;
        }

        [RelayCommand]
        public void Receive()
        {
            ReceiveAndTransferModel.Receive();
        }

        [RelayCommand]
        public void Transfer()
        {
            ReceiveAndTransferModel.Transfer();
        }
    }
}
