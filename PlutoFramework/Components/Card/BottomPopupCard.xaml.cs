using PlutoFramework.Model;

namespace PlutoFramework.Components.Card;

public partial class BottomPopupCard : AbsoluteLayout
{
    private Queue<(float x, float y)> _positions = new Queue<(float, float)>();


    public static readonly BindableProperty IsShownProperty = BindableProperty.Create(
        nameof(IsShown), typeof(bool), typeof(BottomPopupCard),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (BottomPopupCard)bindable;
            if ((bool)newValue)
            {
                Task show = control.ShowCardAsync();
            }
            else
            {
                Task close = control.CloseCardAsync();
            }

            try
            {
                // This is a great workaround.
                // Most of the times, you will use this inside of a ContentView that has got a IPopup BindingContext.
                // If not, then nothing will happen
                ((IPopup)((ContentView)control.Parent).BindingContext).IsVisible = (bool)newValue;
            }
            catch
            {

            }
        });

    public BottomPopupCard()
	{
		InitializeComponent();
    }

    public bool IsShown
    {
        get => (bool)GetValue(IsShownProperty);
        set => SetValue(IsShownProperty, value);
    }

    public Microsoft.Maui.Controls.View View { set { contentView.Content = value; } }

    public string Title { set { titleLabel.Text = value; } }

    private async Task ShowCardAsync()
    {
        await AnimateToTop();
    }

    public async Task CloseCardAsync()
    {
        await AnimateToBottom();

        try
        {
            // This is a great workaround.
            // Most of the times, you will use this inside of a ContentView that has got a ISetToDefault BindingContext.
            // If not, then nothing will happen
            ((ISetToDefault)((ContentView)this.Parent).BindingContext).SetToDefault();
        }
        catch
        {

        }
    }
    private async void OnPanUpdated(System.Object sender, Microsoft.Maui.Controls.PanUpdatedEventArgs e)
    {
        if (e.StatusType == GestureStatus.Started)
        {
            //protectiveLayout.IsVisible = true;

            _positions = new Queue<(float, float)>();
        }

        if (e.StatusType == GestureStatus.Running)
        {
            _positions.Enqueue(((float)(e.TotalX), (float)(e.TotalY)));
            if (_positions.Count > 10)
                _positions.Dequeue();

            float yAverage = _positions.Average(item => item.y);

            if (yAverage >= 0)
            {
                border.TranslationY = yAverage;
                dragger.TranslationY = yAverage;
                contentView.TranslationY = yAverage;
                //closeButton.TranslationY = yAverage;
                titleLabel.TranslationY = yAverage;
                darken.Opacity = 1 - (yAverage / border.Height);
            }
        }

        if (e.StatusType == GestureStatus.Completed)
        {
            if (border.TranslationY < 50)
            {
                await AnimateToTop();
            }
            else
            {
                await CloseCardAsync();
            }
        }
    }

    private Task AnimateToTop() => Task.WhenAll(
                    border.TranslateTo(0, 0, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut),
                    dragger.TranslateTo(0, 0, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut),
                    contentView.TranslateTo(0, 0, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut)
                    //,closeButton.TranslateTo(0, 0, 250, Easing.CubicOut)
                    , titleLabel.TranslateTo(0, 0, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut)
                    , darken.FadeTo(1, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut)
                    );

    private Task AnimateToBottom() => Task.WhenAll(
                    border.TranslateTo(0, border.Height, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut),
                    dragger.TranslateTo(0, border.Height, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut),
                    contentView.TranslateTo(0, border.Height, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut),
                    //,closeButton.TranslateTo(0, border.Height, 250, Easing.CubicOut)
                    titleLabel.TranslateTo(0, border.Height, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut)
                    , darken.FadeTo(0, DefaultAppConfiguration.BOTTOM_CARD_POPUP_ANIMATION_DURATION, Easing.CubicOut)
                );
    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await CloseCardAsync();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}
