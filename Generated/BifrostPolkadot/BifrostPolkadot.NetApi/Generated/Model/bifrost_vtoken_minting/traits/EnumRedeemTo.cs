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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_vtoken_minting.traits
{
    
    
    /// <summary>
    /// >> RedeemTo
    /// </summary>
    public enum RedeemTo
    {
        
        /// <summary>
        /// >> Native
        /// </summary>
        Native = 0,
        
        /// <summary>
        /// >> Astar
        /// </summary>
        Astar = 1,
        
        /// <summary>
        /// >> Moonbeam
        /// </summary>
        Moonbeam = 2,
        
        /// <summary>
        /// >> Hydradx
        /// </summary>
        Hydradx = 3,
        
        /// <summary>
        /// >> Interlay
        /// </summary>
        Interlay = 4,
        
        /// <summary>
        /// >> Manta
        /// </summary>
        Manta = 5,
        
        /// <summary>
        /// >> HyperBridge
        /// </summary>
        HyperBridge = 6,
    }
    
    /// <summary>
    /// >> 578 - Variant[bifrost_vtoken_minting.traits.RedeemTo]
    /// </summary>
    public sealed class EnumRedeemTo : BaseEnumRust<RedeemTo>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRedeemTo()
        {
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemTo.Native);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemTo.Astar);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>(RedeemTo.Moonbeam);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemTo.Hydradx);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemTo.Interlay);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemTo.Manta);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>>(RedeemTo.HyperBridge);
        }
    }
}
