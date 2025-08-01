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
    /// >> TransactionPaymentStorage
    /// </summary>
    public sealed class TransactionPaymentStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> TransactionPaymentStorage Constructor
        /// </summary>
        public TransactionPaymentStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("TransactionPayment", "NextFeeMultiplier"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("TransactionPayment", "StorageVersion"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(BifrostPolkadot.NetApi.Generated.Model.pallet_transaction_payment.EnumReleases)));
        }
        
        /// <summary>
        /// >> NextFeeMultiplierParams
        /// </summary>
        public static string NextFeeMultiplierParams()
        {
            return RequestGenerator.GetStorage("TransactionPayment", "NextFeeMultiplier", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NextFeeMultiplierDefault
        /// Default value as hex string
        /// </summary>
        public static string NextFeeMultiplierDefault()
        {
            return "0x000064A7B3B6E00D0000000000000000";
        }
        
        /// <summary>
        /// >> NextFeeMultiplier
        /// </summary>
        public async Task<BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128> NextFeeMultiplier(string blockhash, CancellationToken token)
        {
            string parameters = TransactionPaymentStorage.NextFeeMultiplierParams();
            var result = await _client.GetStorageAsync<BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> StorageVersionParams
        /// </summary>
        public static string StorageVersionParams()
        {
            return RequestGenerator.GetStorage("TransactionPayment", "StorageVersion", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> StorageVersionDefault
        /// Default value as hex string
        /// </summary>
        public static string StorageVersionDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> StorageVersion
        /// </summary>
        public async Task<BifrostPolkadot.NetApi.Generated.Model.pallet_transaction_payment.EnumReleases> StorageVersion(string blockhash, CancellationToken token)
        {
            string parameters = TransactionPaymentStorage.StorageVersionParams();
            var result = await _client.GetStorageAsync<BifrostPolkadot.NetApi.Generated.Model.pallet_transaction_payment.EnumReleases>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> TransactionPaymentCalls
    /// </summary>
    public sealed class TransactionPaymentCalls
    {
    }
    
    /// <summary>
    /// >> TransactionPaymentConstants
    /// </summary>
    public sealed class TransactionPaymentConstants
    {
        
        /// <summary>
        /// >> OperationalFeeMultiplier
        ///  A fee multiplier for `Operational` extrinsics to compute "virtual tip" to boost their
        ///  `priority`
        /// 
        ///  This value is multiplied by the `final_fee` to obtain a "virtual tip" that is later
        ///  added to a tip component in regular `priority` calculations.
        ///  It means that a `Normal` transaction can front-run a similarly-sized `Operational`
        ///  extrinsic (with no tip), by including a tip value greater than the virtual tip.
        /// 
        ///  ```rust,ignore
        ///  // For `Normal`
        ///  let priority = priority_calc(tip);
        /// 
        ///  // For `Operational`
        ///  let virtual_tip = (inclusion_fee + tip) * OperationalFeeMultiplier;
        ///  let priority = priority_calc(tip + virtual_tip);
        ///  ```
        /// 
        ///  Note that since we use `final_fee` the multiplier applies also to the regular `tip`
        ///  sent with the transaction. So, not only does the transaction get a priority bump based
        ///  on the `inclusion_fee`, but we also amplify the impact of tips applied to `Operational`
        ///  transactions.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U8 OperationalFeeMultiplier()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U8();
            result.Create("0x05");
            return result;
        }
    }
}
