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


namespace Opal.NetApi.Generated.Model.frame_system.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// Error for the System pallet
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> InvalidSpecName
        /// The name of specification does not match between the current runtime
        /// and the new runtime.
        /// </summary>
        InvalidSpecName = 0,
        
        /// <summary>
        /// >> SpecVersionNeedsToIncrease
        /// The specification version is not allowed to decrease between the current runtime
        /// and the new runtime.
        /// </summary>
        SpecVersionNeedsToIncrease = 1,
        
        /// <summary>
        /// >> FailedToExtractRuntimeVersion
        /// Failed to extract the runtime version from the new runtime.
        /// 
        /// Either calling `Core_version` or decoding `RuntimeVersion` failed.
        /// </summary>
        FailedToExtractRuntimeVersion = 2,
        
        /// <summary>
        /// >> NonDefaultComposite
        /// Suicide called when the account has non-default composite data.
        /// </summary>
        NonDefaultComposite = 3,
        
        /// <summary>
        /// >> NonZeroRefCount
        /// There is a non-zero reference count preventing the account from being purged.
        /// </summary>
        NonZeroRefCount = 4,
        
        /// <summary>
        /// >> CallFiltered
        /// The origin filter prevent the call to be dispatched.
        /// </summary>
        CallFiltered = 5,
        
        /// <summary>
        /// >> MultiBlockMigrationsOngoing
        /// A multi-block migration is ongoing and prevents the current code from being replaced.
        /// </summary>
        MultiBlockMigrationsOngoing = 6,
        
        /// <summary>
        /// >> NothingAuthorized
        /// No upgrade authorized.
        /// </summary>
        NothingAuthorized = 7,
        
        /// <summary>
        /// >> Unauthorized
        /// The submitted code is not authorized.
        /// </summary>
        Unauthorized = 8,
    }
    
    /// <summary>
    /// >> 468 - Variant[frame_system.pallet.Error]
    /// Error for the System pallet
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
