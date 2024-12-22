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


namespace InvArch.NetApi.Generated.Model.staging_xcm.v4.traits
{
    
    
    /// <summary>
    /// >> Outcome
    /// </summary>
    public enum Outcome
    {
        
        /// <summary>
        /// >> Complete
        /// </summary>
        Complete = 0,
        
        /// <summary>
        /// >> Incomplete
        /// </summary>
        Incomplete = 1,
        
        /// <summary>
        /// >> Error
        /// </summary>
        Error = 2,
    }
    
    /// <summary>
    /// >> 98 - Variant[staging_xcm.v4.traits.Outcome]
    /// </summary>
    public sealed class EnumOutcome : BaseEnumRust<Outcome>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumOutcome()
        {
				AddTypeDecoder<InvArch.NetApi.Generated.Model.sp_weights.weight_v2.Weight>(Outcome.Complete);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_weights.weight_v2.Weight, InvArch.NetApi.Generated.Model.xcm.v3.traits.EnumError>>(Outcome.Incomplete);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.traits.EnumError>(Outcome.Error);
        }
    }
}
