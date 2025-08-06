namespace PlutoFramework.Components.Progress;

public partial class ProgressStepperView : ContentView
{
    public static readonly BindableProperty StepsProperty = BindableProperty.Create(
        nameof(Steps), typeof(int), typeof(ProgressStepperView),
        defaultValue: -1,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (ProgressStepperView)bindable;

            Console.WriteLine("Setting steps: " + newValue);

            ((ProgressStepperViewModel)control.horizontalStackLayout.BindingContext).ProgressSteps = (int)newValue;
        });

    public static readonly BindableProperty StepProperty = BindableProperty.Create(
        nameof(Step), typeof(int), typeof(ProgressStepperView),
        defaultValue: -1,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (ProgressStepperView)bindable;

            Console.WriteLine("Setting step: " + newValue);

            ((ProgressStepperViewModel)control.horizontalStackLayout.BindingContext).ProgressStep = (int)newValue;
        });

    public ProgressStepperView()
    {
        InitializeComponent();

        horizontalStackLayout.BindingContext = new ProgressStepperViewModel();
    }

    public int Steps
    {
        get => (int)GetValue(StepsProperty);
        set => SetValue(StepsProperty, value);
    }

    public int Step
    {
        get => (int)GetValue(StepProperty);
        set => SetValue(StepProperty, value);
    }
}