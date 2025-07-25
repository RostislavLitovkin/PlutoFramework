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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_vstoken_conversion.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> vsbond_convert_to_vstoken
        /// </summary>
        vsbond_convert_to_vstoken = 0,
        
        /// <summary>
        /// >> vstoken_convert_to_vsbond
        /// </summary>
        vstoken_convert_to_vsbond = 1,
        
        /// <summary>
        /// >> set_exchange_fee
        /// </summary>
        set_exchange_fee = 2,
        
        /// <summary>
        /// >> set_exchange_rate
        /// </summary>
        set_exchange_rate = 3,
        
        /// <summary>
        /// >> set_relaychain_lease
        /// </summary>
        set_relaychain_lease = 4,
    }
    
    /// <summary>
    /// >> 438 - Variant[bifrost_vstoken_conversion.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.vsbond_convert_to_vstoken);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.vstoken_convert_to_vsbond);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.bifrost_vstoken_conversion.primitives.VstokenConversionExchangeFee>(Call.set_exchange_fee);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.I32, BifrostPolkadot.NetApi.Generated.Model.bifrost_vstoken_conversion.primitives.VstokenConversionExchangeRate>>(Call.set_exchange_rate);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.set_relaychain_lease);
        }
    }
}
