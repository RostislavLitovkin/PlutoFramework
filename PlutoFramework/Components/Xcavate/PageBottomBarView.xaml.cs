namespace PlutoFramework.Components.Xcavate;

public partial class PageBottomBarView : Grid
{
    public static readonly BindableProperty HasShadowProperty =
       BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(PageBottomBarView),
           propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {
               if ((bool)newValue)
               {
                   return;
               }

               var control = (PageBottomBarView)bindable;

               control.Shadow = new Shadow
               {
                   Brush = Colors.Transparent,
                   Radius = 0,
                   Offset = new Point(0, 0),
                   Opacity = 0
               };

           });
    public PageBottomBarView()
	{
		InitializeComponent();
	}

    public bool HasShadow
    {
        get => (bool)GetValue(HasShadowProperty);
        set => SetValue(HasShadowProperty, value);
    }
}