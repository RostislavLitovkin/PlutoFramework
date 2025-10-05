using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class NoMnemonicsPage : PageTemplate
    {
        public NoMnemonicsPage()
        {
            InitializeComponent();

            BindingContext = new NoMnemonicsViewModel(); 
        }

        public NoMnemonicsPage(NoMnemonicsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}