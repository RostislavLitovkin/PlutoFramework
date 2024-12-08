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


namespace Polkadot.NetApi.Generated.Model.pallet_parameters.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> set_parameter
        /// Set the value of a parameter.
        /// 
        /// The dispatch origin of this call must be `AdminOrigin` for the given `key`. Values be
        /// deleted by setting them to `None`.
        /// </summary>
        set_parameter = 0,
    }
    
    /// <summary>
    /// >> 169 - Variant[pallet_parameters.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumRuntimeParameters>(Call.set_parameter);
        }
    }
}
