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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types
{
    
    
    /// <summary>
    /// >> ReferendumInfo
    /// </summary>
    public enum ReferendumInfo
    {
        
        /// <summary>
        /// >> Ongoing
        /// </summary>
        Ongoing = 0,
        
        /// <summary>
        /// >> Approved
        /// </summary>
        Approved = 1,
        
        /// <summary>
        /// >> Rejected
        /// </summary>
        Rejected = 2,
        
        /// <summary>
        /// >> Cancelled
        /// </summary>
        Cancelled = 3,
        
        /// <summary>
        /// >> TimedOut
        /// </summary>
        TimedOut = 4,
        
        /// <summary>
        /// >> Killed
        /// </summary>
        Killed = 5,
    }
    
    /// <summary>
    /// >> 428 - Variant[pallet_referenda.types.ReferendumInfo]
    /// </summary>
    public sealed class EnumReferendumInfo : BaseEnumRust<ReferendumInfo>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumReferendumInfo()
        {
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.ReferendumStatus>(ReferendumInfo.Ongoing);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>>>(ReferendumInfo.Approved);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>>>(ReferendumInfo.Rejected);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>>>(ReferendumInfo.Cancelled);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>>>(ReferendumInfo.TimedOut);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(ReferendumInfo.Killed);
        }
    }
}
