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
        public IList<MauiView> PopupContent => new PopupContentCollection(this);

        private AbsoluteLayout? _popupLayoutRef = null;

        private readonly List<MauiView> _pendingPopupContent = new();

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
                propertyChanged: (BindableObject bindable, object oldValue, object newValue) =>
                {
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

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _popupLayoutRef = (AbsoluteLayout)GetTemplateChild("PopupsLayout");

            if (_popupLayoutRef == null)
            {
                Console.WriteLine("PopupsLayout not found in template.");
                return;
            }

            // Add any previously set views into the layout
            foreach (var view in _pendingPopupContent)
            {
                _popupLayoutRef.Children.Add(view);
            }

            if (this.BindingContext != null)
            {
                _popupLayoutRef.BindingContext = this.BindingContext;
            }

            _pendingPopupContent.Clear();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (MainContent != null)
            {
                MainContent.BindingContext = this.BindingContext;
            }

            if (_popupLayoutRef != null)
            {
                _popupLayoutRef.BindingContext = this.BindingContext;
            }

            /*try
            {
                foreach (var popup in PopupContent)
                {
                    try
                    {
                        popup.BindingContext = this.BindingContext;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error setting BindingContext for PopupContent item: {ex}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting BindingContext for PopupContent: {ex}");
            }
            */
        }

        private class PopupContentCollection : IList<MauiView>
        {
            private readonly PageTemplate _owner;

            private IList<MauiView> getMauiViews => _owner._popupLayoutRef != null ? _owner._popupLayoutRef.Children.Where(item => item is MauiView).Select(item => (MauiView)item).ToList() : _owner._pendingPopupContent;

            public PopupContentCollection(PageTemplate owner) => _owner = owner;

            public void Add(MauiView item)
            {
                if (_owner.BindingContext != null)
                {
                    // item.BindingContext = _owner.BindingContext;
                }

                if (_owner._popupLayoutRef != null)
                {
                    _owner._popupLayoutRef.Children.Add(item);
                }
                else
                {
                    _owner._pendingPopupContent.Add(item);
                }
            }

            public void Clear()
            {
                _owner._popupLayoutRef?.Children.Clear();
                _owner._pendingPopupContent.Clear();
            }

            public bool Contains(MauiView item) =>
                _owner._popupLayoutRef?.Children.Contains(item) ?? _owner._pendingPopupContent.Contains(item);

            public void CopyTo(MauiView[] array, int arrayIndex) =>
                getMauiViews.CopyTo(array, arrayIndex);

            public bool Remove(MauiView item)
            {
                if (_owner._popupLayoutRef != null)
                    return _owner._popupLayoutRef.Children.Remove(item);

                return _owner._pendingPopupContent.Remove(item);
            }

            public int Count => _owner._popupLayoutRef?.Children.Count ?? _owner._pendingPopupContent.Count;
            public bool IsReadOnly => false;
            public IEnumerator<MauiView> GetEnumerator() =>
                getMauiViews.GetEnumerator();

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
            public int IndexOf(MauiView item) =>
                getMauiViews.IndexOf(item);

            public void Insert(int index, MauiView item)
            {
                if (_owner.BindingContext != null)
                {
                    // item.BindingContext = _owner.BindingContext;
                }

                getMauiViews.Insert(index, item);
            }

            public void RemoveAt(int index) =>
                getMauiViews.RemoveAt(index);

            public MauiView this[int index]
            {
                get => getMauiViews[index];
                set => getMauiViews[index] = value;
            }
        }
    }
}