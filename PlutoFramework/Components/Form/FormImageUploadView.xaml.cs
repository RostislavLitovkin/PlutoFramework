namespace PlutoFramework.Components.Form;

public partial class FormImageUploadView : ContentView
{
	public static readonly BindableProperty ImageStreamProperty = BindableProperty.Create(
	   nameof(ImageStream), typeof(Stream), typeof(FormImageUploadView),
	   defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(FormImageUploadView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormImageUploadView)bindable;
            control.titleSpan.Text = (string)newValue;
        });
    public FormImageUploadView()
	{
		InitializeComponent();
	}

	public Stream ImageStream {
		get => (Stream)GetValue(ImageStreamProperty);
		set => SetValue(ImageStreamProperty, value);
    }

    public string Title {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    private async void OnCaptureTapped(object sender, TappedEventArgs e)
    {
        var result = await MediaPicker.Default.CapturePhotoAsync();

        await SetImageAsync(result);
    }

    private async void OnSelectTapped(object sender, TappedEventArgs e)
    {
        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        {
            Title = Title,
        });

        await SetImageAsync(result);
    }

    private async Task SetImageAsync(FileResult? result)
    {
        if (result == null) return;

        string localFilePath = Path.Combine(FileSystem.CacheDirectory, result.FileName);

        var sourceStream = await result.OpenReadAsync();

        using FileStream localFileStream = File.OpenWrite(localFilePath);

        await sourceStream.CopyToAsync(localFileStream);

        image.Source = ImageSource.FromFile(localFilePath);

        SetValue(ImageStreamProperty, sourceStream);
    }
}