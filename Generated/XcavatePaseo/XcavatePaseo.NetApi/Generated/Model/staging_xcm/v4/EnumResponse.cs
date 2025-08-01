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


namespace XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4
{
    
    
    /// <summary>
    /// >> Response
    /// </summary>
    public enum Response
    {
        
        /// <summary>
        /// >> Null
        /// </summary>
        Null = 0,
        
        /// <summary>
        /// >> Assets
        /// </summary>
        Assets = 1,
        
        /// <summary>
        /// >> ExecutionResult
        /// </summary>
        ExecutionResult = 2,
        
        /// <summary>
        /// >> Version
        /// </summary>
        Version = 3,
        
        /// <summary>
        /// >> PalletsInfo
        /// </summary>
        PalletsInfo = 4,
        
        /// <summary>
        /// >> DispatchResult
        /// </summary>
        DispatchResult = 5,
    }
    
    /// <summary>
    /// >> 334 - Variant[staging_xcm.v4.Response]
    /// </summary>
    public sealed class EnumResponse : BaseEnumRust<Response>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumResponse()
        {
				AddTypeDecoder<BaseVoid>(Response.Null);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(Response.Assets);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.xcm.v3.traits.EnumError>>>(Response.ExecutionResult);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Response.Version);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT15>(Response.PalletsInfo);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Model.xcm.v3.EnumMaybeErrorCode>(Response.DispatchResult);
        }
    }
}
