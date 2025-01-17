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


namespace XCavatePaseo.NetApi.Generated.Model.frame_support.traits.messages
{
    
    
    /// <summary>
    /// >> ProcessMessageError
    /// </summary>
    public enum ProcessMessageError
    {
        
        /// <summary>
        /// >> BadFormat
        /// </summary>
        BadFormat = 0,
        
        /// <summary>
        /// >> Corrupt
        /// </summary>
        Corrupt = 1,
        
        /// <summary>
        /// >> Unsupported
        /// </summary>
        Unsupported = 2,
        
        /// <summary>
        /// >> Overweight
        /// </summary>
        Overweight = 3,
        
        /// <summary>
        /// >> Yield
        /// </summary>
        Yield = 4,
    }
    
    /// <summary>
    /// >> 135 - Variant[frame_support.traits.messages.ProcessMessageError]
    /// </summary>
    public sealed class EnumProcessMessageError : BaseEnumRust<ProcessMessageError>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumProcessMessageError()
        {
				AddTypeDecoder<BaseVoid>(ProcessMessageError.BadFormat);
				AddTypeDecoder<BaseVoid>(ProcessMessageError.Corrupt);
				AddTypeDecoder<BaseVoid>(ProcessMessageError.Unsupported);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_weights.weight_v2.Weight>(ProcessMessageError.Overweight);
				AddTypeDecoder<BaseVoid>(ProcessMessageError.Yield);
        }
    }
}
