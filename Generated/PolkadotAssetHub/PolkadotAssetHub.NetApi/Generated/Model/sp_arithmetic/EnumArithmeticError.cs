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


namespace PolkadotAssetHub.NetApi.Generated.Model.sp_arithmetic
{
    
    
    /// <summary>
    /// >> ArithmeticError
    /// </summary>
    public enum ArithmeticError
    {
        
        /// <summary>
        /// >> Underflow
        /// </summary>
        Underflow = 0,
        
        /// <summary>
        /// >> Overflow
        /// </summary>
        Overflow = 1,
        
        /// <summary>
        /// >> DivisionByZero
        /// </summary>
        DivisionByZero = 2,
    }
    
    /// <summary>
    /// >> 29 - Variant[sp_arithmetic.ArithmeticError]
    /// </summary>
    public sealed class EnumArithmeticError : BaseEnum<ArithmeticError>
    {
    }
}
