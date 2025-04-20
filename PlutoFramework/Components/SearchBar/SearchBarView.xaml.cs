
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.SearchBar;

public partial class SearchBarView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(SearchBarView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (SearchBarView)bindable;

            if (control.entry.Text == (string)newValue)
            {
                return;
            }

            try
            {
                control.entry.Text = (string)newValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        });

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder), typeof(string), typeof(SearchBarView),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (SearchBarView)bindable;

            control.entry.Placeholder = (string)newValue;
        });

    public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
        nameof(SearchCommand), typeof(IAsyncRelayCommand), typeof(SearchBarView));
    public SearchBarView()
	{
		InitializeComponent();
	}

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public IAsyncRelayCommand SearchCommand
    {
        get => (IAsyncRelayCommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }


    private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        try
        {
            if (e.PropertyName != "Text")
            {
                return;
            }

            SetValue(TextProperty, ((Entry)sender).Text);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }


    private async void OnSearchClicked(object sender, TappedEventArgs e)
    {
        await entry.HideKeyboardAsync();

        await SearchCommand?.ExecuteAsync(null);
    }
}