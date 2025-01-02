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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_nft_fractionalization.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> NftFractionalized
        /// An NFT was successfully fractionalized.
        /// </summary>
        NftFractionalized = 0,
        
        /// <summary>
        /// >> NftUnified
        /// An NFT was successfully returned back.
        /// </summary>
        NftUnified = 1,
    }
    
    /// <summary>
    /// >> 296 - Variant[pallet_nft_fractionalization.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.NftFractionalized);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.NftUnified);
        }
    }
}
