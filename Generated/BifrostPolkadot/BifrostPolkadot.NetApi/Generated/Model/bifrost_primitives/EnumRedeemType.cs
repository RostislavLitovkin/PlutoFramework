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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives
{
    
    
    /// <summary>
    /// >> RedeemType
    /// </summary>
    public enum RedeemType
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
    /// >> 902 - Variant[bifrost_primitives.RedeemType]
    /// </summary>
    public sealed class EnumRedeemType : BaseEnumRust<RedeemType>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRedeemType()
        {
				AddTypeDecoder<BaseVoid>(RedeemType.Native);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemType.Astar);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>(RedeemType.Moonbeam);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemType.Hydradx);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemType.Interlay);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(RedeemType.Manta);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>>(RedeemType.HyperBridge);
        }
    }
}
