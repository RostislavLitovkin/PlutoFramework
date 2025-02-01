namespace PlutoFramework.Components.Card;

public partial class ClickableCard : ContentView
{
    public ClickableCard()
    {
        InitializeComponent();
    }

    public Microsoft.Maui.Controls.View View { set { contentView.Content = value; } }

    public bool IsPopup
    {
        set
        {
            border.Padding = new Thickness(15);
            border.SetAppThemeColor(Border.BackgroundColorProperty, Color.FromArgb("ffffff"), Color.FromArgb("0a0a0a"));
        }
    }

    public bool IsTransparent
    {
        set
        {
            if (value)
            {
                border.SetAppThemeColor(Border.BackgroundColorProperty, Color.FromArgb("88ffffff"), Color.FromArgb("88000000"));
            }
        }
    }

    public bool IsThin
    {
        set
        {
            if (value)
            {
                roundRectangle.CornerRadius = 15;
                border.Padding = new Thickness(20, 0, 20, 0);
            }
        }
    }

    public Thickness CardPadding { set { border.Padding = value; } }
    public Color Color { set { border.BackgroundColor = value; } }
    public void SetDefaultColor()
    {
        if (border.BackgroundColor == Colors.White || border.BackgroundColor == Colors.Black)
        {
            return;
        }

        border.SetAppThemeColor(
            Border.BackgroundColorProperty,
            Resources.TryGetValue("White", out object white) ? (Color)white : Colors.White,
            Resources.TryGetValue("Black", out object black) ? (Color)black : Colors.Black);
    }

    public void SetRedColor()
    {
        border.SetAppThemeColor(
            Border.BackgroundColorProperty,
            Color.FromArgb("#ffb3b3"),
            Color.FromArgb("#260000")
            );
    }
    public LinearGradientBrush LinearGradientBrushColor { set { border.Background = value; } }
}