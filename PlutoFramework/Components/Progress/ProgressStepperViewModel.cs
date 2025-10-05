
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Progress
{
    public partial class ProgressStepperViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Borders))]
        private int progressStep = -1;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Borders))]
        private int progressSteps = -1;

        public ObservableCollection<Border> Borders
        {
            get
            {
                Console.WriteLine($"Setting step: {ProgressStep}, total steps: {ProgressSteps}");

                if (ProgressStep == -1)
                {
                    return [];
                }

                if (ProgressSteps == -1)
                {
                    return [];
                }

                return new ObservableCollection<Border>(Enumerable.Range(0, ProgressSteps)
                    .Select(i => new Border
                    {
                        HeightRequest = 4,
                        WidthRequest = i == ProgressStep ? 32 : 12,
                        BackgroundColor = i == ProgressStep ? (Color)Application.Current.Resources["Primary"] : Color.FromArgb("#D9D9D9"),
                        StrokeThickness = 0,
                        StrokeShape = new RoundRectangle
                        {
                            CornerRadius = 2
                        }
                    }));
            }

        }
    }
}
