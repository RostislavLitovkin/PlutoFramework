namespace PlutoFramework.Model
{
    public static class AppConfigurationLoader
    {
        public static void Load()
        {
            AppConfigurationModel.Location = Preferences.Get("Location", (string)Application.Current.Resources["Location"]);
        }
    }
}
