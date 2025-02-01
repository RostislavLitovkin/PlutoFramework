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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_tx_pause.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> pause
        /// Pause a call.
        /// 
        /// Can only be called by [`Config::PauseOrigin`].
        /// Emits an [`Event::CallPaused`] event on success.
        /// </summary>
        pause = 0,
        
        /// <summary>
        /// >> unpause
        /// Un-pause a call.
        /// 
        /// Can only be called by [`Config::UnpauseOrigin`].
        /// Emits an [`Event::CallUnpaused`] event on success.
        /// </summary>
        unpause = 1,
    }
    
    /// <summary>
    /// >> 251 - Variant[pallet_tx_pause.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseTuple<XCavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT1, XCavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT1>>(Call.pause);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseTuple<XCavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT1, XCavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT1>>(Call.unpause);
        }
    }
}
