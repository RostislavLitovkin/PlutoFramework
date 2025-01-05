using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Model
{
    public class XCavateFileModel
    {
        public static ImageSource? GetSavedProfilePicture()
        {
            var profilePicturePath = Path.Combine(FileSystem.AppDataDirectory, XCavateConstants.PROFILE_PICTURE_FILE_NAME);

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
            var profileBackgroundPath = Path.Combine(FileSystem.AppDataDirectory, XCavateConstants.PROFILE_BACKGROUND_FILE_NAME);

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
