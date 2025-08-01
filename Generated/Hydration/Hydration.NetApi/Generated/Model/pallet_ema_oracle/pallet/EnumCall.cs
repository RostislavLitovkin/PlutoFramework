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


namespace Hydration.NetApi.Generated.Model.pallet_ema_oracle.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> add_oracle
        /// </summary>
        add_oracle = 0,
        
        /// <summary>
        /// >> remove_oracle
        /// </summary>
        remove_oracle = 1,
        
        /// <summary>
        /// >> update_bifrost_oracle
        /// </summary>
        update_bifrost_oracle = 2,
    }
    
    /// <summary>
    /// >> 409 - Variant[pallet_ema_oracle.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Types.Base.Arr8U8, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>(Call.add_oracle);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Types.Base.Arr8U8, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>(Call.remove_oracle);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.EnumVersionedLocation, Hydration.NetApi.Generated.Model.xcm.EnumVersionedLocation, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.update_bifrost_oracle);
        }
    }
}
