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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.astar_dapp_staking.types
{
    
    
    /// <summary>
    /// >> AstarValidator
    /// </summary>
    public enum AstarValidator
    {
        
        /// <summary>
        /// >> Evm
        /// </summary>
        Evm = 0,
        
        /// <summary>
        /// >> Wasm
        /// </summary>
        Wasm = 1,
    }
    
    /// <summary>
    /// >> 508 - Variant[bifrost_slp_v2.astar_dapp_staking.types.AstarValidator]
    /// </summary>
    public sealed class EnumAstarValidator : BaseEnumRust<AstarValidator>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAstarValidator()
        {
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>(AstarValidator.Evm);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(AstarValidator.Wasm);
        }
    }
}
