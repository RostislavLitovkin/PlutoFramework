using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Nft;
using PlutoFramework.Model.SQLite;
using UniqueryPlus.Metadata;

namespace PlutoFramework.Components.XcavateProperty
{
    public record ImageSourceWithName
    {
        public required ImageSource ImageSource { get; set; }
        public required string FileName { get; set; }
    }
    public partial class ModifyPropertyViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title = "";

        [ObservableProperty]
        private bool canBeDeleted = true;

        [ObservableProperty]
        private List<ImageSourceWithName> imageSources = new List<ImageSourceWithName>();

        [ObservableProperty]
        private XcavateMetadata metadata = new XcavateMetadata
        {
            Images = [],
            PropertyName = ""
        };

        [ObservableProperty]
        private ButtonStateEnum submitButtonState = ButtonStateEnum.Enabled;

        [RelayCommand]
        public async Task FormChangedAsync()
        {
            Console.WriteLine("Form changed: ");
            Console.WriteLine(Metadata.PropertyName);

            await SaveAsync();
        }

        [RelayCommand]
        public async Task AddImageAsync()
        {
            var token = CancellationToken.None;

            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = ImageSources.Count() == 0 ? "Select the main Property image" : "Select a new Property image",
            });


            if (result == null)
            {
                return;
            }

            string fileName = $"property{DateTime.UtcNow.Ticks}";

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);

            using (var inputStream = await result.OpenReadAsync())
            using (FileStream outputStream = File.Create(targetFile))
            {
                await inputStream.CopyToAsync(outputStream);

                outputStream.Close();
                inputStream.Close();
            }

            Metadata.Images.Add(fileName);
            await SaveAsync();

            LoadPropertyImages();
        }
        private Task SaveAsync() => XcavatePropertyDatabase.SavePropertyAsync(Metadata);
        public void LoadPropertyImages()
        {
            ImageSources = Metadata.Images
                    .Where(fileName => File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, fileName)))
                    .Select(fileName => new ImageSourceWithName
                    {
                        ImageSource = ImageSource.FromStream(() =>
                        {
                            return File.OpenRead(Path.Combine(FileSystem.Current.AppDataDirectory, fileName));
                        }),
                        FileName = fileName
                    }).ToList();
        }

        [RelayCommand]
        public async Task RemoveImageAsync(NftModifyImageView image)
        {
            if (image.ImageSourceWithName is null)
            {
                return;
            }

            Metadata.Images.Remove(image.ImageSourceWithName.FileName);

            ImageSources.Remove(image.ImageSourceWithName);

            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, image.ImageSourceWithName.FileName);

            if (File.Exists(targetFile))
            {
                File.Delete(targetFile);
            }

            await SaveAsync();

            LoadPropertyImages();
        }

        [RelayCommand]
        public async Task DeleteAsync()
        {
            await XcavatePropertyDatabase.DeletePropertyAsync();

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        public async Task SubmitAsync()
        {

        }

        [RelayCommand]
        public async Task CancelAsync()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
