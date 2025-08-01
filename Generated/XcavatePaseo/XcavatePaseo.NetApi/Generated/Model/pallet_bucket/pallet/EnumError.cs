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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_bucket.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NamespaceAlreadyExists
        /// The requested namespace already exists.
        /// </summary>
        NamespaceAlreadyExists = 0,
        
        /// <summary>
        /// >> UnknownNamespace
        /// The requested namespace does not exist.
        /// </summary>
        UnknownNamespace = 1,
        
        /// <summary>
        /// >> UnknownBucket
        /// The bucket does not exist.
        /// </summary>
        UnknownBucket = 2,
        
        /// <summary>
        /// >> BucketIsLocked
        /// The bucket is locked.
        /// </summary>
        BucketIsLocked = 3,
        
        /// <summary>
        /// >> UnknownMessage
        /// The requested message is unknown.
        /// </summary>
        UnknownMessage = 4,
        
        /// <summary>
        /// >> DanglingBuckets
        /// There are dangling buckets for the namespace.
        /// </summary>
        DanglingBuckets = 5,
        
        /// <summary>
        /// >> DanglingMessages
        /// There are dangling messages for the bucket.
        /// </summary>
        DanglingMessages = 6,
        
        /// <summary>
        /// >> NotManager
        /// The origin is not authorized to perform the manager action for the namespace.
        /// </summary>
        NotManager = 7,
        
        /// <summary>
        /// >> NotContributor
        /// The contributor does not exist for the requested bucket.
        /// </summary>
        NotContributor = 8,
        
        /// <summary>
        /// >> NotAdmin
        /// The origin is not authorized to perform the manager action for the bucket.
        /// </summary>
        NotAdmin = 9,
        
        /// <summary>
        /// >> UnknownTag
        /// The given tag does not exist.
        /// </summary>
        UnknownTag = 10,
        
        /// <summary>
        /// >> UnableToPayFees
        /// The account is unable to pay the fees.
        /// </summary>
        UnableToPayFees = 11,
        
        /// <summary>
        /// >> DanglingContributors
        /// There are dangling contributors
        /// </summary>
        DanglingContributors = 12,
        
        /// <summary>
        /// >> DanglingAdmins
        /// There are dangling admins
        /// </summary>
        DanglingAdmins = 13,
        
        /// <summary>
        /// >> DanglingManagers
        /// There are dangling managers
        /// </summary>
        DanglingManagers = 14,
    }
    
    /// <summary>
    /// >> 548 - Variant[pallet_bucket.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
