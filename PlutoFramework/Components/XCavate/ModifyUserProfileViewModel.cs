﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class ModifyUserProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private ImageSource profilePicture;

        [ObservableProperty]
        private ImageSource profileBackground;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string firstName = "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string lastName = "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string email = "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string phoneNumber = "";

        [RelayCommand]
        public async Task PickProfilePictureAsync()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a profile picture",
                FileTypes = FilePickerFileType.Images,
            });

            if (result == null)
            {
                return;
            }

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "temporaryprofilepicture");

            using (var inputStream = await result.OpenReadAsync())
            using (FileStream outputStream = File.Create(targetFile))
            {
                await inputStream.CopyToAsync(outputStream);

                outputStream.Close();
                inputStream.Close();
            }

            if (File.Exists(targetFile))
            {
                ProfilePicture = ImageSource.FromStream(() =>
                {
                    return File.OpenRead(targetFile);
                });
            }
        }


        [RelayCommand]
        public async Task PickProfileBackgroundAsync()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select a profile background",
                FileTypes = FilePickerFileType.Images,
            });

            if (result == null)
            {
                return;
            }

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "temporaryprofilebackground");

            if (File.Exists(targetFile))
            {
                File.Delete(targetFile);
            }

            using (var inputStream = await result.OpenReadAsync())
            using (FileStream outputStream = new FileStream(targetFile, FileMode.Create, FileAccess.Write))
            {
                await inputStream.CopyToAsync(outputStream);
            }

            if (File.Exists(targetFile))
            {
                ProfileBackground = ImageSource.FromStream(() =>
                {
                    return File.OpenRead(targetFile);
                });
            }
        }

        [RelayCommand]
        public Task CancelAsync() => Application.Current.MainPage.Navigation.PopAsync();

        [RelayCommand]
        public async Task SaveAsync()
        {
            // Save the user profile
            if (UserProfilePage.ViewModel is null)
            {
                return;
            }

            string tempProfilePicturePath = Path.Combine(FileSystem.Current.AppDataDirectory, "temporaryprofilepicture");
            string profilePicturePath = Path.Combine(FileSystem.Current.AppDataDirectory, XcavateConstants.PROFILE_PICTURE_FILE_NAME);

            if (File.Exists(tempProfilePicturePath))
            {
                File.Move(tempProfilePicturePath, profilePicturePath, true);
            }

            string tempProfileBackgroundPath = Path.Combine(FileSystem.Current.AppDataDirectory, "temporaryprofilebackground");
            string profileBackgroundPath = Path.Combine(FileSystem.Current.AppDataDirectory, XcavateConstants.PROFILE_BACKGROUND_FILE_NAME);

            if (File.Exists(tempProfileBackgroundPath))
            {
                File.Move(tempProfileBackgroundPath, profileBackgroundPath, true);
            }

            var newUserInfo = new XcavateUser
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Role = UserProfilePage.ViewModel.User.Role,
                DeveloperStats = UserProfilePage.ViewModel.User.DeveloperStats,
                AccountCreatedAt = UserProfilePage.ViewModel.User.AccountCreatedAt,
                ProfilePicture = XcavateFileModel.GetSavedProfilePicture(),
                ProfileBackground = XcavateFileModel.GetSavedProfileBackground(),
            };

            UserProfilePage.ViewModel.User = newUserInfo;

            await Application.Current.MainPage.Navigation.PopAsync();

            await XcavateUserDatabase.SaveUserInformationAsync(newUserInfo);
        }

        public ButtonStateEnum SaveButtonState => (FirstName != "" && LastName != "" && FormModel.IsValidEmail(Email) && PhoneNumber != "") ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;
    }
}
