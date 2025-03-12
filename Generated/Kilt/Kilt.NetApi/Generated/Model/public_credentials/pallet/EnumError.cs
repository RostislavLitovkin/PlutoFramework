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


namespace Kilt.NetApi.Generated.Model.public_credentials.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> AlreadyAttested
        /// A credential with the same root hash has already issued to the
        /// specified subject.
        /// </summary>
        AlreadyAttested = 0,
        
        /// <summary>
        /// >> NotFound
        /// No credential with the specified root hash has been issued to the
        /// specified subject.
        /// </summary>
        NotFound = 1,
        
        /// <summary>
        /// >> UnableToPayFees
        /// Not enough tokens to pay for the fees or the deposit.
        /// </summary>
        UnableToPayFees = 2,
        
        /// <summary>
        /// >> InvalidInput
        /// The credential input is invalid.
        /// </summary>
        InvalidInput = 3,
        
        /// <summary>
        /// >> NotAuthorized
        /// The caller is not authorized to performed the operation.
        /// </summary>
        NotAuthorized = 4,
        
        /// <summary>
        /// >> Internal
        /// Catch-all for any other errors that should not happen, yet it
        /// happened.
        /// </summary>
        Internal = 5,
    }
    
    /// <summary>
    /// >> 549 - Variant[public_credentials.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
