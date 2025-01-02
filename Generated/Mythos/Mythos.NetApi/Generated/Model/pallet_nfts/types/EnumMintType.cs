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


namespace Mythos.NetApi.Generated.Model.pallet_nfts.types
{
    
    
    /// <summary>
    /// >> MintType
    /// </summary>
    public enum MintType
    {
        
        /// <summary>
        /// >> Issuer
        /// </summary>
        Issuer = 0,
        
        /// <summary>
        /// >> Public
        /// </summary>
        Public = 1,
        
        /// <summary>
        /// >> HolderOf
        /// </summary>
        HolderOf = 2,
    }
    
    /// <summary>
    /// >> 231 - Variant[pallet_nfts.types.MintType]
    /// </summary>
    public sealed class EnumMintType : BaseEnumRust<MintType>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumMintType()
        {
				AddTypeDecoder<BaseVoid>(MintType.Issuer);
				AddTypeDecoder<BaseVoid>(MintType.Public);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.runtime_common.IncrementableU256>(MintType.HolderOf);
        }
    }
}
