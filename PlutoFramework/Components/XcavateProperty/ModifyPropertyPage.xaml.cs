using UniqueryPlus.Metadata;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class ModifyPropertyPage : ContentPage
    {
        public ModifyPropertyPage(XcavateMetadata property)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            BindingContext = new ModifyPropertyViewModel {
                Title = "Modify property",
                Metadata = property,
            };

            Console.WriteLine("Loaded property: " + property.PropertyName);

            ((ModifyPropertyViewModel)BindingContext).LoadPropertyImages();
        }
    }
}