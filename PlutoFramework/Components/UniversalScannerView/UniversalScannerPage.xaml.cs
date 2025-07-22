using PlutoFramework.Templates.PageTemplate;
using ZXing.Net.Maui;

namespace PlutoFramework.Components.UniversalScannerView;

public partial class UniversalScannerPage : PageTemplate
{
	public UniversalScannerPage()
	{
        InitializeComponent();

        scanner.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.TwoDimensional,
        };
    }

    public EventHandler<BarcodeDetectionEventArgs> OnScannedMethod
    {
        set
        {
            scanner.BarcodesDetected += value;
        }
    }

    private void OnDetected(System.Object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        scanner.IsDetecting = false;
    }
}
