using PlutoFramework.Model;

namespace PlutoFramework.Components.Mnemonics;

public partial class BackupMnemonicsReminderView : ContentView
{
    public BackupMnemonicsReminderView()
    {
        InitializeComponent();
    }

    async void OnClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        try
        {
            var secret = await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync();

            await Navigation.PushAsync(new MnemonicsPage(secret));

            Model.CustomLayoutModel.RemoveComponentFromSavedLayout(ComponentId.BMnR);
        }
        catch
        {

        }
    }
}
