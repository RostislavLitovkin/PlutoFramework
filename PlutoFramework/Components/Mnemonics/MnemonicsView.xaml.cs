namespace PlutoFramework.Components.Mnemonics;

public partial class MnemonicsView : ContentView
{
    public static readonly BindableProperty MnemonicsProperty = BindableProperty.Create(
       nameof(Mnemonics), typeof(string), typeof(MnemonicsView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var control = (MnemonicsView)bindable;

           control.mnemonicsLabel.Text = (string)newValue;
       });
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
       nameof(Title), typeof(string), typeof(MnemonicsView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var control = (MnemonicsView)bindable;

           control.titleSpan.Text = (string)newValue;
       });
    public MnemonicsView()
	{
		InitializeComponent();
	}

    public string Mnemonics
    {
        get => (string)GetValue(MnemonicsProperty);
        set => SetValue(MnemonicsProperty, value);
    }
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
}