namespace PlutoFramework.Model.Xcavate
{
    public class XcavateFileModel
    {
        public static void DeleteAll()
        {
            var profilePicturePath = Path.Combine(FileSystem.AppDataDirectory, XcavateConstants.PROFILE_PICTURE_FILE_NAME);

            if (File.Exists(profilePicturePath))
            {
                File.Delete(profilePicturePath);
            }

            var profileBackgroundPath = Path.Combine(FileSystem.AppDataDirectory, XcavateConstants.PROFILE_BACKGROUND_FILE_NAME);

            if (File.Exists(profileBackgroundPath))
            {
                File.Delete(profileBackgroundPath);
            }
        }

        public static ImageSource? GetSavedProfilePicture()
        {
            var profilePicturePath = Path.Combine(FileSystem.AppDataDirectory, XcavateConstants.PROFILE_PICTURE_FILE_NAME);

            if (!File.Exists(profilePicturePath))
            {
                return null;
            }

            return ImageSource.FromStream(() =>
            {
                return File.OpenRead(profilePicturePath);
            });
        }
        public static ImageSource? GetSavedProfileBackground()
        {
            var profileBackgroundPath = Path.Combine(FileSystem.AppDataDirectory, XcavateConstants.PROFILE_BACKGROUND_FILE_NAME);

            if (!File.Exists(profileBackgroundPath))
            {
                return null;
            }

            return ImageSource.FromStream(() =>
            {
                return File.OpenRead(profileBackgroundPath);
            });
        }
    }
}
