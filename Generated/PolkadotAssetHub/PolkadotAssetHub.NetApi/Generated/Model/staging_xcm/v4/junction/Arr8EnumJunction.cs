//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System.Collections.Generic;


namespace PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction
{
    
    
    /// <summary>
    /// >> 54 - Array
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Array)]
    public sealed class Arr8EnumJunction : BaseType
    {
        
        /// <summary>
        /// >> PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumJunction[]
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumJunction[] Value { get; set; }
        
        /// <inheritdoc/>
        public override int TypeSize
        {
            get
            {
                return 8;
            }
        }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return string.Format("[{0}; {1}]", new PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumJunction().TypeName(), this.TypeSize);
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value){result.AddRange(v.Encode());};
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var array = new PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumJunction[TypeSize];
            for (var i = 0; i < array.Length; i++) {var t = new PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumJunction();t.Decode(byteArray, ref p);array[i] = t;};
            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }
        
        /// <inheritdoc/>
        public void Create(PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumJunction[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }
}
