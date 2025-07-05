using PlutoFramework.Model;

namespace PlutoFramework.Components.Tabs;

public partial class TwoTabView : ContentView, ISetEmptyView, ISubstrateClientLoadableView, ISubstrateClientLoadableAsyncView, IMainSubstrateClientLoadableView, IMainSubstrateClientLoadableAsyncView
{
    public static readonly BindableProperty Tab1TitleProperty = BindableProperty.Create(
        nameof(Tab1Title), typeof(string), typeof(TwoTabView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TwoTabView)bindable;
            control.tab1.Title = (string)newValue;
        });

    public static readonly BindableProperty Tab2TitleProperty = BindableProperty.Create(
        nameof(Tab2Title), typeof(string), typeof(TwoTabView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TwoTabView)bindable;
            control.tab2.Title = (string)newValue;
        });

    public static readonly BindableProperty Tab1IconProperty = BindableProperty.Create(
        nameof(Tab1Icon), typeof(ImageSource), typeof(TwoTabView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TwoTabView)bindable;
            control.tab1.Icon = (ImageSource)newValue;
        });

    public static readonly BindableProperty Tab2IconProperty = BindableProperty.Create(
        nameof(Tab2Icon), typeof(ImageSource), typeof(TwoTabView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TwoTabView)bindable;
            control.tab2.Icon = (ImageSource)newValue;
        });

    public static readonly BindableProperty ContentView1Property = BindableProperty.Create(
        nameof(ContentView1), typeof(ContentView), typeof(TwoTabView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TwoTabView)bindable;
            control.contentView1.Content = (ContentView)newValue;
        });

    public static readonly BindableProperty ContentView2Property = BindableProperty.Create(
        nameof(ContentView1), typeof(ContentView), typeof(TwoTabView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TwoTabView)bindable;
            control.contentView2.Content = (ContentView)newValue;
        });

    public TwoTabView()
    {
        InitializeComponent();

        BindingContext = new TwoTabViewModel();
    }

    public string Tab1Title
    {
        get => (string)GetValue(Tab1TitleProperty);
        set => SetValue(Tab1TitleProperty, value);
    }
    public string Tab2Title
    {
        get => (String)GetValue(Tab2TitleProperty);
        set => SetValue(Tab2TitleProperty, value);
    }

    public ImageSource Tab1Icon
    {
        get => (ImageSource)GetValue(Tab1IconProperty);
        set => SetValue (Tab1IconProperty, value);
    }

    public ImageSource Tab2Icon
    {
        get => (ImageSource)GetValue(Tab2IconProperty);
        set => SetValue(Tab2IconProperty, value);
    }

    public ContentView ContentView1
    {
        get => (ContentView)GetValue(ContentView1Property);
        set => SetValue(ContentView1Property, value);
    }

    public ContentView ContentView2
    {
        get => (ContentView)GetValue(ContentView2Property);
        set => SetValue(ContentView2Property, value);
    }

    public void SetEmpty()
    {
        if (contentView1.Content is ISetEmptyView emptyView)
        {
            emptyView.SetEmpty();
        }
        if (contentView2.Content is ISetEmptyView emptyView2)
        {
            emptyView2.SetEmpty();
        }
    }

    public void Load(PlutoFrameworkSubstrateClient client)
    {
        if (contentView1.Content is ISubstrateClientLoadableView loadableView)
        {
            loadableView.Load(client);
        }
        if (contentView2.Content is ISubstrateClientLoadableView loadableView2)
        {
            loadableView2.Load(client);
        }
    }
    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (contentView1.Content is ISubstrateClientLoadableAsyncView loadableView)
        {
            await loadableView.LoadAsync(client, token);
        }
        if (contentView2.Content is ISubstrateClientLoadableAsyncView loadableView2)
        {
            await loadableView2.LoadAsync(client, token);
        }
    }

    public void MainLoad(PlutoFrameworkSubstrateClient client)
    {
        if (contentView1.Content is IMainSubstrateClientLoadableView loadableView)
        {
            loadableView.MainLoad(client);
        }
        if (contentView2.Content is IMainSubstrateClientLoadableView loadableView2)
        {
            loadableView2.MainLoad(client);
        }
    }

    public async Task MainLoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (contentView1.Content is IMainSubstrateClientLoadableAsyncView loadableView)
        {
            await loadableView.MainLoadAsync(client, token);
        }
        if (contentView2.Content is IMainSubstrateClientLoadableAsyncView loadableView2)
        {
            await loadableView2.MainLoadAsync(client, token);
        }
    }
}