using PlutoFramework.Templates.PageTemplate;
using UniqueryPlus.Metadata;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class ModifyPropertyPage : PageTemplate
    {
        public ModifyPropertyPage(XcavateMetadata property)
        {
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