namespace PlutoFramework.Components.Notifications;

public partial class DateView : ContentView
{
	public static readonly BindableProperty DateProperty =
		BindableProperty.Create(nameof(Date), typeof(DateTime), typeof(DateView), default(DateTime),
			propertyChanged: (bindable, oldValue, newValue) =>
			{
				var control = (DateView)bindable;
				var date = (DateTime)newValue;

				var now = DateTime.Now;

				control.label.Text = (now.Day - date.Day) switch
				{
					0 => $"Today {date.ToString("HH:mm")}",
					1 => $"Yesterday {date.ToString("HH:mm")}",
					_ => $"{now.Subtract(date).Days} days ago",
				};
            }
            );	
    public DateView()
	{
		InitializeComponent();
	}

	public DateTime Date
	{
		get => (DateTime)GetValue(DateProperty);
		set => SetValue(DateProperty, value);
    }
}