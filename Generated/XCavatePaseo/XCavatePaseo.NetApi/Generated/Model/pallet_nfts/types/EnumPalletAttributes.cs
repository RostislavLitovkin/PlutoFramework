//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace XCavatePaseo.NetApi.Generated.Model.pallet_nfts.types
{
    
    
    /// <summary>
    /// >> PalletAttributes
    /// </summary>
    public enum PalletAttributes
    {
        
        /// <summary>
        /// >> UsedToClaim
        /// </summary>
        UsedToClaim = 0,
        
        /// <summary>
        /// >> TransferDisabled
        /// </summary>
        TransferDisabled = 1,
    }
    
    /// <summary>
    /// >> 156 - Variant[pallet_nfts.types.PalletAttributes]
    /// </summary>
    public sealed class EnumPalletAttributes : BaseEnumRust<PalletAttributes>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumPalletAttributes()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(PalletAttributes.UsedToClaim);
				AddTypeDecoder<BaseVoid>(PalletAttributes.TransferDisabled);
        }
    }
}
