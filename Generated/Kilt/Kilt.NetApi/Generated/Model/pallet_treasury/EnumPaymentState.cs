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


namespace Kilt.NetApi.Generated.Model.pallet_treasury
{
    
    
    /// <summary>
    /// >> PaymentState
    /// </summary>
    public enum PaymentState
    {
        
        /// <summary>
        /// >> Pending
        /// </summary>
        Pending = 0,
        
        /// <summary>
        /// >> Attempted
        /// </summary>
        Attempted = 1,
        
        /// <summary>
        /// >> Failed
        /// </summary>
        Failed = 2,
    }
    
    /// <summary>
    /// >> 462 - Variant[pallet_treasury.PaymentState]
    /// </summary>
    public sealed class EnumPaymentState : BaseEnumRust<PaymentState>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumPaymentState()
        {
				AddTypeDecoder<BaseVoid>(PaymentState.Pending);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseTuple>(PaymentState.Attempted);
				AddTypeDecoder<BaseVoid>(PaymentState.Failed);
        }
    }
}
