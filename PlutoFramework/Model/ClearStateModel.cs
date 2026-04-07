using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Model
{
    public class ClearStateModel
    {
        public static void Clear()
        {
            // Remove accounts
            KeysModel.RemoveAccount();
            KeysModel.RemoveAccount("kilt1");

            // Other
            SecureStorage.Default.Remove(PreferencesModel.PASSWORD);
            Preferences.Remove(PreferencesModel.BIOMETRICS_ENABLED);
            Preferences.Remove(PreferencesModel.SHOW_WELCOME_SCREEN);

            // Models
            AssetsModel.Clear();

            // Files
            XcavateFileModel.DeleteAll();
        }
    }
}
