using CommunityToolkit.Mvvm.Input;
using MauiView = Microsoft.Maui.Controls.View;

namespace PlutoFramework.Templates.PageTemplate
{
    [ContentProperty(nameof(MainContent))]
    public class PageTemplate : ContentPage
    {
        public static readonly BindableProperty MainContentProperty =
            BindableProperty.Create(nameof(MainContent), typeof(MauiView), typeof(PageTemplate), default(MauiView));
        public MauiView MainContent
        {
            get => (MauiView)GetValue(MainContentProperty);
            set => SetValue(MainContentProperty, value);
        }

        public static readonly BindableProperty PopupContentProperty =
            BindableProperty.Create(nameof(PopupContent), typeof(MauiView), typeof(PageTemplate), default(MauiView));
        public MauiView PopupContent
        {
            get => (MauiView)GetValue(PopupContentProperty);
            set => SetValue(PopupContentProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra1TextProperty =
            BindableProperty.Create(nameof(NavigationBarExtra1Text), typeof(string), typeof(PageTemplate));
        public string NavigationBarExtra1Text
        {
            get => (string)GetValue(NavigationBarExtra1TextProperty);
            set => SetValue(NavigationBarExtra1TextProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra1CommandProperty =
            BindableProperty.Create(nameof(NavigationBarExtra1Command), typeof(IAsyncRelayCommand), typeof(PageTemplate));
        public string NavigationBarExtra1Command
        {
            get => (string)GetValue(NavigationBarExtra1CommandProperty);
            set => SetValue(NavigationBarExtra1CommandProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra1ImageProperty =
            BindableProperty.Create(nameof(NavigationBarExtra1Image), typeof(string), typeof(PageTemplate));
        public string NavigationBarExtra1Image
        {
            get => (string)GetValue(NavigationBarExtra1ImageProperty);
            set => SetValue(NavigationBarExtra1ImageProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra2TextProperty =
            BindableProperty.Create(nameof(NavigationBarExtra2Text), typeof(string), typeof(PageTemplate));
        public string NavigationBarExtra2Text
        {
            get => (string)GetValue(NavigationBarExtra2TextProperty);
            set => SetValue(NavigationBarExtra2TextProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra2CommandProperty =
            BindableProperty.Create(nameof(NavigationBarExtra2Command), typeof(IAsyncRelayCommand), typeof(PageTemplate));
        public string NavigationBarExtra2Command
        {
            get => (string)GetValue(NavigationBarExtra2CommandProperty);
            set => SetValue(NavigationBarExtra2CommandProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra2ImageProperty =
            BindableProperty.Create(nameof(NavigationBarExtra2Image), typeof(string), typeof(PageTemplate));
        public string NavigationBarExtra2Image
        {
            get => (string)GetValue(NavigationBarExtra2ImageProperty);
            set => SetValue(NavigationBarExtra2ImageProperty, value);
        }        

        public PageTemplate()
        {
            ControlTemplate = (ControlTemplate)Application.Current.Resources["PageTemplate"];

            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}
