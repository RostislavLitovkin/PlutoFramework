using System.Numerics;
using UniqueryPlus.Collections;

namespace PlutoFramework.Components.Nft;

public partial class CollectionMintConfigView : ContentView
{
    public static readonly BindableProperty MintTypeProperty = BindableProperty.Create(
        nameof(MintType), typeof(MintType), typeof(CollectionMintConfigView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionMintConfigView)bindable;

            switch (((MintType)newValue).Type)
            {
                case MintTypeEnum.CannotMint:
                    control.mintableByAttribute.Value = "Nobody";
                    break;
                case MintTypeEnum.Issuer:
                    control.mintableByAttribute.Value = "Issuer";
                    break;
                case MintTypeEnum.Public:
                    control.mintableByAttribute.Value = "Public";
                    break;
                case MintTypeEnum.Whitelist:
                    control.mintableByAttribute.Value = "Whitelist";
                    break;
                case MintTypeEnum.Unknown:
                    control.mintableByAttribute.Value = "Unknown";
                    break;
                case MintTypeEnum.HolderOfCollection:
                    control.mintableByAttribute.Value = $"Holders of #{((MintType)newValue).CollectionId}";
                    break;
                default:
                    return;

            }

            control.mintableByAttribute.IsVisible = true;

        });

    public static readonly BindableProperty MintPriceTextProperty = BindableProperty.Create(
        nameof(MintPriceText), typeof(string), typeof(CollectionMintConfigView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionMintConfigView)bindable;

            control.priceAttribute.Value = (string)newValue;
            control.priceAttribute.IsVisible = true;
        });

    public static readonly BindableProperty NftsMintedTextProperty = BindableProperty.Create(
        nameof(NftsMintedText), typeof(string), typeof(CollectionMintConfigView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionMintConfigView)bindable;

            control.nftsMintedAttribute.Value = (string)newValue;
            control.nftsMintedAttribute.IsVisible = true;
        });
    public static readonly BindableProperty FromBlockProperty = BindableProperty.Create(
        nameof(FromBlock), typeof(BigInteger?), typeof(CollectionMintConfigView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionMintConfigView)bindable;

            var from = (BigInteger?)newValue;
            if (from is null)
            {
                return;
            }

            control.fromAttribute.Value = from.ToString();
            control.fromAttribute.IsVisible = true;
        });
    public static readonly BindableProperty ToBlockProperty = BindableProperty.Create(
        nameof(ToBlock), typeof(BigInteger?), typeof(CollectionMintConfigView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (CollectionMintConfigView)bindable;

            var to = (BigInteger?)newValue;
            if (to is null)
            {
                return;
            }

            control.toAttribute.Value = to.ToString();
            control.toAttribute.IsVisible = true;
        });
    public CollectionMintConfigView()
    {
        InitializeComponent();
    }

    public MintType MintType
    {
        get => (MintType)GetValue(MintTypeProperty);
        set => SetValue(MintTypeProperty, value);
    }

    public string MintPriceText
    {
        get => (string)GetValue(MintPriceTextProperty);
        set => SetValue(MintPriceTextProperty, value);
    }

    public string NftsMintedText
    {
        get => (string)GetValue(NftsMintedTextProperty);
        set => SetValue(NftsMintedTextProperty, value);
    }

    public BigInteger? FromBlock
    {
        get => (BigInteger?)GetValue(FromBlockProperty);
        set => SetValue(FromBlockProperty, value);
    }

    public BigInteger? ToBlock
    {
        get => (BigInteger?)GetValue(ToBlockProperty);
        set => SetValue(ToBlockProperty, value);
    }
}