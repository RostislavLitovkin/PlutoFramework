using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.NavigationBar;
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

        /*public static readonly BindableProperty PopupContentProperty =
            BindableProperty.Create(nameof(PopupContent), typeof(MauiView), typeof(PageTemplate), default(MauiView));

        public MauiView PopupContent
        {
            get => (MauiView)GetValue(PopupContentProperty);
            set => SetValue(PopupContentProperty, value);
        }*/


        public static readonly BindableProperty PopupContentProperty =
            BindableProperty.Create(
                nameof(PopupContent),
                typeof(IList<MauiView>),
                typeof(PageTemplate),
                defaultValue: new List<MauiView>());

        public IList<MauiView> PopupContent
        {
            get => (IList<MauiView>)GetValue(PopupContentProperty);
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
        public IAsyncRelayCommand NavigationBarExtra1Command
        {
            get => (IAsyncRelayCommand)GetValue(NavigationBarExtra1CommandProperty);
            set => SetValue(NavigationBarExtra1CommandProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra1ImageProperty =
            BindableProperty.Create(nameof(NavigationBarExtra1Image), typeof(ImageSource), typeof(PageTemplate));
        public ImageSource NavigationBarExtra1Image
        {
            get => (ImageSource)GetValue(NavigationBarExtra1ImageProperty);
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
        public IAsyncRelayCommand NavigationBarExtra2Command
        {
            get => (IAsyncRelayCommand)GetValue(NavigationBarExtra2CommandProperty);
            set => SetValue(NavigationBarExtra2CommandProperty, value);
        }

        public static readonly BindableProperty NavigationBarExtra2ImageProperty =
            BindableProperty.Create(nameof(NavigationBarExtra2Image), typeof(ImageSource), typeof(PageTemplate));
        public ImageSource NavigationBarExtra2Image
        {
            get => (ImageSource)GetValue(NavigationBarExtra2ImageProperty);
            set => SetValue(NavigationBarExtra2ImageProperty, value);
        }

        public static readonly BindableProperty IsNavbarVisibleProperty =
            BindableProperty.Create(nameof(IsNavbarVisible), typeof(bool), typeof(PageTemplate), true,
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {
                    if (bindable is PageTemplate page)
                    {
                        page.ScrollPadding = (bool)newValue ? new Thickness(0, 55, 0, 0) : new Thickness(0);
                    }
                });
        public bool IsNavbarVisible
        {
            get => (bool)GetValue(IsNavbarVisibleProperty);
            set => SetValue(IsNavbarVisibleProperty, value);
        }

        public static readonly BindableProperty ScrollPaddingProperty =
            BindableProperty.Create(nameof(ScrollPadding), typeof(Thickness), typeof(PageTemplate), new Thickness(0));
        public Thickness ScrollPadding
        {
            get => (Thickness)GetValue(ScrollPaddingProperty);
            set => SetValue(ScrollPaddingProperty, value);
        }

        public ScrollView ScrollView { get => this.FindByName<ScrollView>("ScrollView"); }
        public TopNavigationBar TopNavigationBar { get => this.FindByName<TopNavigationBar>("TopNavigationBar"); }

        public PageTemplate()
        {
            ControlTemplate = (ControlTemplate)Application.Current.Resources["PageTemplate"];

            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            ScrollPadding = IsNavbarVisible ? new Thickness(0, 55, 0, 0) : new Thickness(0);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (MainContent != null)
                MainContent.BindingContext = BindingContext;
        }
    }
}
