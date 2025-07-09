using MauiView = Microsoft.Maui.Controls.View;

namespace PlutoFramework.Templates.PageTemplate
{
    [ContentProperty(nameof(MainContent))]
    public class PageTemplate : ContentPage
    {
        public MauiView MainContent
        {
            get => (MauiView)GetValue(MainContentProperty);
            set => SetValue(MainContentProperty, value);
        }
        public MauiView PopupContent
        {
            get => (MauiView)GetValue(PopupContentProperty);
            set => SetValue(PopupContentProperty, value);
        }

        public static readonly BindableProperty MainContentProperty =
            BindableProperty.Create(nameof(MainContent), typeof(MauiView), typeof(PageTemplate), default(MauiView));

        public static readonly BindableProperty PopupContentProperty =
            BindableProperty.Create(nameof(PopupContent), typeof(MauiView), typeof(PageTemplate), default(MauiView));
        

        public PageTemplate()
        {
            ControlTemplate = (ControlTemplate)Application.Current.Resources["PageTemplate"];

            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}
