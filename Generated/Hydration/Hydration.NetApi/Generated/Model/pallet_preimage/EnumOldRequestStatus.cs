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


namespace Hydration.NetApi.Generated.Model.pallet_preimage
{
    
    
    /// <summary>
    /// >> OldRequestStatus
    /// </summary>
    public enum OldRequestStatus
    {
        
        /// <summary>
        /// >> Unrequested
        /// </summary>
        Unrequested = 0,
        
        /// <summary>
        /// >> Requested
        /// </summary>
        Requested = 1,
    }
    
    /// <summary>
    /// >> 533 - Variant[pallet_preimage.OldRequestStatus]
    /// </summary>
    public sealed class EnumOldRequestStatus : BaseEnumRust<OldRequestStatus>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumOldRequestStatus()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.U32>>(OldRequestStatus.Unrequested);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>>(OldRequestStatus.Requested);
        }
    }
}
