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


namespace Kilt.NetApi.Generated.Model.sp_runtime
{
    
    
    /// <summary>
    /// >> TokenError
    /// </summary>
    public enum TokenError
    {
        
        /// <summary>
        /// >> FundsUnavailable
        /// </summary>
        FundsUnavailable = 0,
        
        /// <summary>
        /// >> OnlyProvider
        /// </summary>
        OnlyProvider = 1,
        
        /// <summary>
        /// >> BelowMinimum
        /// </summary>
        BelowMinimum = 2,
        
        /// <summary>
        /// >> CannotCreate
        /// </summary>
        CannotCreate = 3,
        
        /// <summary>
        /// >> UnknownAsset
        /// </summary>
        UnknownAsset = 4,
        
        /// <summary>
        /// >> Frozen
        /// </summary>
        Frozen = 5,
        
        /// <summary>
        /// >> Unsupported
        /// </summary>
        Unsupported = 6,
        
        /// <summary>
        /// >> CannotCreateHold
        /// </summary>
        CannotCreateHold = 7,
        
        /// <summary>
        /// >> NotExpendable
        /// </summary>
        NotExpendable = 8,
        
        /// <summary>
        /// >> Blocked
        /// </summary>
        Blocked = 9,
    }
    
    /// <summary>
    /// >> 27 - Variant[sp_runtime.TokenError]
    /// </summary>
    public sealed class EnumTokenError : BaseEnum<TokenError>
    {
    }
}
