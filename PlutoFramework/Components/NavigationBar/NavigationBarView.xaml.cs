﻿using PlutoFramework.Components.TransferView;
using PlutoFramework.Model;
using PlutoFramework.Components.Account;

namespace PlutoFramework.Components.NavigationBar;

public enum NavigationBarSelectedOption
{
    // Has to exist due to binding
    None,

    Home,
    Nfts
}

public partial class NavigationBarView : ContentView
{
    public static readonly BindableProperty SelectedOptionProperty = BindableProperty.Create(
      nameof(SelectedOption), typeof(NavigationBarSelectedOption), typeof(NavigationBarView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (NavigationBarView)bindable;

          if ((NavigationBarSelectedOption)newValue == NavigationBarSelectedOption.Home)
          {
              control.homeSpan.FontAttributes = FontAttributes.Bold;
              control.nftsSpan.FontAttributes = FontAttributes.None;
          }
          else if ((NavigationBarSelectedOption)newValue == NavigationBarSelectedOption.Nfts)
          {
              control.homeSpan.FontAttributes = FontAttributes.None;
              control.nftsSpan.FontAttributes = FontAttributes.Bold;
          }
      });
    public NavigationBarView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<NavigationBarViewModel>();
    }

    public NavigationBarSelectedOption SelectedOption
    {
        get => (NavigationBarSelectedOption)GetValue(SelectedOptionProperty);
        set => SetValue(SelectedOptionProperty, value);
    }

    async void OnHomeClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (SelectedOption != NavigationBarSelectedOption.Nfts)
        {
            return;
        }

        await Shell.Current.GoToAsync("//MainPage");
    }

    async void OnNFTsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (SelectedOption != NavigationBarSelectedOption.Home)
        {
            return;
        }

        await Shell.Current.GoToAsync("//NftMainPage");
    }
    
    async void OnTransferClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (!KeysModel.HasSubstrateKey())
        {
            var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupModel>();

            noAccountPopupViewModel.IsVisible = true;

            return;
        }

        var viewModel = DependencyService.Get<TransferViewModel>();

        viewModel.IsVisible = true;

        Task fee = viewModel.GetFeeAsync();
    }
}
