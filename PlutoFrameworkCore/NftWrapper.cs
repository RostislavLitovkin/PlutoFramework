using PlutoFramework.Constants;
using System.ComponentModel;
using UniqueryPlus.Nfts;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using PlutoFramework.Types;

namespace PlutoFramework.Model
{
    public class NftAssetWrapper : NftWrapper
    {
        public required Asset? AssetPrice { get; set; }
        public required NftOperation Operation { get; set; }
    }

    public class NftWrapper : INotifyPropertyChanged
    {
        public NftKey? Key => NftBase is not null ? (NftBase.Type, NftBase.CollectionId, NftBase.Id) : null;
        public INftBase? NftBase { get; set; }
        public Endpoint? Endpoint { get; set; }

        private bool favourite = false;
        public bool Favourite
        {
            get => favourite;
            set
            {
                if (favourite != value)
                {
                    favourite = value;
                    OnPropertyChanged(nameof(Favourite));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public override bool Equals(object? obj)
        {
            return obj is NftWrapper objNft &&
                    objNft.NftBase?.Metadata?.Name == this.NftBase?.Metadata?.Name &&
                    objNft.NftBase?.Metadata?.Description == this.NftBase?.Metadata?.Description &&
                    objNft.NftBase?.Metadata?.Image == this.NftBase?.Metadata?.Image &&
                    objNft.Endpoint?.Key == this.Endpoint?.Key;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NftBase?.Metadata?.Name, NftBase?.Metadata?.Description, NftBase?.Metadata?.Image, Endpoint?.Key);
        }

        public override string ToString()
        {
            return this.NftBase?.Metadata?.Name + " - " + this.NftBase?.Metadata?.Image;
        }
    }
}
