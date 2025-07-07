using Microsoft.Maui.Layouts;

namespace PlutoFramework.Templates.TopNavigationBarTemplate
{
    public class TopNavigationBarTemplate : ContentView
    {
        public TopNavigationBarTemplate()
        {
            BindingContext = new TopNavigationBarViewModel();

            ControlTemplate = (ControlTemplate)Application.Current.Resources["TopNavigationBarTemplate"];

            var height = (double)Application.Current.Resources["TopNavigationBarHeight"];
            AbsoluteLayout.SetLayoutBounds(this, new Rect(0.5, 0, 1, height));
            AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        }
    }
}
