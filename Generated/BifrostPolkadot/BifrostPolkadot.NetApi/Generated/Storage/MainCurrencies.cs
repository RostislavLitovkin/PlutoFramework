//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace BifrostPolkadot.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> CurrenciesStorage
    /// </summary>
    public sealed class CurrenciesStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> CurrenciesStorage Constructor
        /// </summary>
        public CurrenciesStorage(SubstrateClientExt client)
        {
            this._client = client;
        }
    }
    
    /// <summary>
    /// >> CurrenciesCalls
    /// </summary>
    public sealed class CurrenciesCalls
    {
    }
    
    /// <summary>
    /// >> CurrenciesConstants
    /// </summary>
    public sealed class CurrenciesConstants
    {
        
        /// <summary>
        /// >> GetNativeCurrencyId
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId GetNativeCurrencyId()
        {
            var result = new BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId();
            result.Create("0x0001");
            return result;
        }
    }
    
    /// <summary>
    /// >> CurrenciesErrors
    /// </summary>
    public enum CurrenciesErrors
    {
        
        /// <summary>
        /// >> AmountIntoBalanceFailed
        /// Unable to convert the Amount type into Balance.
        /// </summary>
        AmountIntoBalanceFailed,
        
        /// <summary>
        /// >> BalanceTooLow
        /// Balance is too low.
        /// </summary>
        BalanceTooLow,
        
        /// <summary>
        /// >> DepositFailed
        /// Deposit result is not expected
        /// </summary>
        DepositFailed,
    }
}
