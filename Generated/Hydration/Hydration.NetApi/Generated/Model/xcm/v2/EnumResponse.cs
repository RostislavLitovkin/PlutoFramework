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


namespace Hydration.NetApi.Generated.Model.xcm.v2
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
    }
    
    /// <summary>
    /// >> 430 - Variant[xcm.v2.Response]
    /// </summary>
    public sealed class EnumResponse : BaseEnumRust<Response>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumResponse()
        {
				AddTypeDecoder<BaseVoid>(Response.Null);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets>(Response.Assets);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.xcm.v2.traits.EnumError>>>(Response.ExecutionResult);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Response.Version);
        }
    }
}
