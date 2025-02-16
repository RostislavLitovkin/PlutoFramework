namespace PlutoFramework.Model
{
    public class PermissionsModel
    {
        public static async Task RequestCameraPermissionAsync()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (status != PermissionStatus.Granted)
                await Permissions.RequestAsync<Permissions.Camera>();
        }
    }
}
