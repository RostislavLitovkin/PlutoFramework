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


namespace Unique.NetApi.Generated.Model.xcm.v3
{
    
    
    /// <summary>
    /// >> MaybeErrorCode
    /// </summary>
    public enum MaybeErrorCode
    {
        
        /// <summary>
        /// >> Success
        /// </summary>
        Success = 0,
        
        /// <summary>
        /// >> Error
        /// </summary>
        Error = 1,
        
        /// <summary>
        /// >> TruncatedError
        /// </summary>
        TruncatedError = 2,
    }
    
    /// <summary>
    /// >> 241 - Variant[xcm.v3.MaybeErrorCode]
    /// </summary>
    public sealed class EnumMaybeErrorCode : BaseEnumRust<MaybeErrorCode>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumMaybeErrorCode()
        {
				AddTypeDecoder<BaseVoid>(MaybeErrorCode.Success);
				AddTypeDecoder<Unique.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT7>(MaybeErrorCode.Error);
				AddTypeDecoder<Unique.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT7>(MaybeErrorCode.TruncatedError);
        }
    }
}
