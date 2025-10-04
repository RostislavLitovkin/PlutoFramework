﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.Model.Sumsub;
using PlutoFrameworkCore;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class EnterMnemonicsViewModel : ObservableObject
    {
        public required Func<Task> Navigation;

        [ObservableProperty]
        private bool incorrectMnemonicsEntered = false;

        [ObservableProperty]
        private string mnemonics = "";

        [ObservableProperty]
        private string privateKey = "";

        public bool UsePrivateKeyIsVisible => Preferences.Get(PreferencesModel.SETTINGS_ALLOW_PRIVATE_KEY, false);

        [RelayCommand]
        public async Task ContinueWithMnemonicsAsync()
        {
            try
            {
                await Model.KeysModel.SaveSr25519KeyAsync(
                    Mnemonics
                );

                await PlutoConfigurationModel.AfterAccountImportAsync();

                await Navigation.Invoke();
            }
            catch
            {
                IncorrectMnemonicsEntered = true;
            }
        }

        [RelayCommand]
        public async Task ContinueWithPrivateKeyAsync()
        {
            await Model.KeysModel.GenerateNewAccountFromPrivateKeyAsync(PrivateKey);

            await PlutoConfigurationModel.AfterAccountImportAsync();

            await Navigation.Invoke();
        }

        [RelayCommand]
        public async Task ImportJsonAsync()
        {
            await KeysModel.ImportJsonKeyAsync();

            await Navigation.Invoke();
        }
    }
}
