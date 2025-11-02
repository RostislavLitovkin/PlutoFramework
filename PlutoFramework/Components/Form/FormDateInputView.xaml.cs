using System;

namespace PlutoFramework.Components.Form;

public partial class FormDateInputView : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(FormDateInputView),
        default(string), BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormDateInputView)bindable;
            control.titleLabel.Text = (string?)newValue ?? string.Empty;
        });

    public static readonly BindableProperty DateProperty = BindableProperty.Create(
        nameof(Date), typeof(DateTime), typeof(FormDateInputView),
        default(DateTime), BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormDateInputView)bindable;
            var newDateTime = (DateTime)newValue;

            if (control._settingFromPickers)
                return;

            control._settingFromProperty = true;
            try
            {
                if (control.datePicker.Date != newDateTime.Date)
                    control.datePicker.Date = newDateTime.Date;

                var tp = control.GetTimePicker();
                var newTime = new TimeSpan(newDateTime.Hour, newDateTime.Minute, 0);
                if (tp != null && tp.Time != newTime)
                    tp.Time = newTime;
            }
            finally
            {
                control._settingFromProperty = false;
            }
        });

    public static readonly BindableProperty DefaultValueProperty = BindableProperty.Create(
        nameof(DefaultValue), typeof(DateTime), typeof(FormDateInputView),
        default(DateTime), BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormDateInputView)bindable;
            var date = (DateTime)newValue;
            if (control.Date == default)
            {
                control.Date = date;
            }
        });

    private bool _settingFromPickers;
    private bool _settingFromProperty;

    public FormDateInputView()
    {
        InitializeComponent();
        var tp = GetTimePicker();
        if (Date == default && tp != null)
        {
            tp.Time = TimeSpan.Zero;
        }
    }

    public string? Title
    {
        get => (string?)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public DateTime Date
    {
        get => (DateTime)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    public DateTime DefaultValue
    {
        get => (DateTime)GetValue(DefaultValueProperty);
        set => SetValue(DefaultValueProperty, value);
    }

    private TimePicker? GetTimePicker() => FindByName("timePicker") as TimePicker;

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        if (_settingFromProperty) return;

        _settingFromPickers = true;
        try
        {
            var tp = GetTimePicker();
            var combined = e.NewDate.Date + (tp?.Time ?? TimeSpan.Zero);
            if (Date != combined)
            {
                SetValue(DateProperty, combined);
            }
        }
        finally
        {
            _settingFromPickers = false;
        }
    }

    private void OnTimePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(TimePicker.Time)) return;
        if (_settingFromProperty) return;

        _settingFromPickers = true;
        try
        {
            var tp = (TimePicker)sender;
            var combined = datePicker.Date + tp.Time;
            if (Date != combined)
            {
                SetValue(DateProperty, combined);
            }
        }
        finally
        {
            _settingFromPickers = false;
        }
    }
}
