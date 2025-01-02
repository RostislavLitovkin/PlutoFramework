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


namespace Hydration.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> BalancesStorage
    /// </summary>
    public sealed class BalancesStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> BalancesStorage Constructor
        /// </summary>
        public BalancesStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Balances", "TotalIssuance"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Balances", "InactiveIssuance"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Balances", "Account"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32), typeof(Hydration.NetApi.Generated.Model.pallet_balances.types.AccountData)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Balances", "Locks"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32), typeof(Hydration.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT2)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Balances", "Reserves"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32), typeof(Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT11)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Balances", "Holds"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32), typeof(Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT12)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Balances", "Freezes"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32), typeof(Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT13)));
        }
        
        /// <summary>
        /// >> TotalIssuanceParams
        ///  The total units issued in the system.
        /// </summary>
        public static string TotalIssuanceParams()
        {
            return RequestGenerator.GetStorage("Balances", "TotalIssuance", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> TotalIssuanceDefault
        /// Default value as hex string
        /// </summary>
        public static string TotalIssuanceDefault()
        {
            return "0x00000000000000000000000000000000";
        }
        
        /// <summary>
        /// >> TotalIssuance
        ///  The total units issued in the system.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> TotalIssuance(string blockhash, CancellationToken token)
        {
            string parameters = BalancesStorage.TotalIssuanceParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> InactiveIssuanceParams
        ///  The total units of outstanding deactivated balance in the system.
        /// </summary>
        public static string InactiveIssuanceParams()
        {
            return RequestGenerator.GetStorage("Balances", "InactiveIssuance", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> InactiveIssuanceDefault
        /// Default value as hex string
        /// </summary>
        public static string InactiveIssuanceDefault()
        {
            return "0x00000000000000000000000000000000";
        }
        
        /// <summary>
        /// >> InactiveIssuance
        ///  The total units of outstanding deactivated balance in the system.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> InactiveIssuance(string blockhash, CancellationToken token)
        {
            string parameters = BalancesStorage.InactiveIssuanceParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> AccountParams
        ///  The Balances pallet example of storing the balance of an account.
        /// 
        ///  # Example
        /// 
        ///  ```nocompile
        ///   impl pallet_balances::Config for Runtime {
        ///     type AccountStore = StorageMapShim<Self::Account<Runtime>, frame_system::Provider<Runtime>, AccountId, Self::AccountData<Balance>>
        ///   }
        ///  ```
        /// 
        ///  You can also store the balance of an account in the `System` pallet.
        /// 
        ///  # Example
        /// 
        ///  ```nocompile
        ///   impl pallet_balances::Config for Runtime {
        ///    type AccountStore = System
        ///   }
        ///  ```
        /// 
        ///  But this comes with tradeoffs, storing account balances in the system pallet stores
        ///  `frame_system` data alongside the account data contrary to storing account balances in the
        ///  `Balances` pallet, which uses a `StorageMap` to store balances data only.
        ///  NOTE: This is only used in the case that this pallet is used to store balances.
        /// </summary>
        public static string AccountParams(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Balances", "Account", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> AccountDefault
        /// Default value as hex string
        /// </summary>
        public static string AccountDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "0000000000000000000000000000000000000000000000080";
        }
        
        /// <summary>
        /// >> Account
        ///  The Balances pallet example of storing the balance of an account.
        /// 
        ///  # Example
        /// 
        ///  ```nocompile
        ///   impl pallet_balances::Config for Runtime {
        ///     type AccountStore = StorageMapShim<Self::Account<Runtime>, frame_system::Provider<Runtime>, AccountId, Self::AccountData<Balance>>
        ///   }
        ///  ```
        /// 
        ///  You can also store the balance of an account in the `System` pallet.
        /// 
        ///  # Example
        /// 
        ///  ```nocompile
        ///   impl pallet_balances::Config for Runtime {
        ///    type AccountStore = System
        ///   }
        ///  ```
        /// 
        ///  But this comes with tradeoffs, storing account balances in the system pallet stores
        ///  `frame_system` data alongside the account data contrary to storing account balances in the
        ///  `Balances` pallet, which uses a `StorageMap` to store balances data only.
        ///  NOTE: This is only used in the case that this pallet is used to store balances.
        /// </summary>
        public async Task<Hydration.NetApi.Generated.Model.pallet_balances.types.AccountData> Account(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key, string blockhash, CancellationToken token)
        {
            string parameters = BalancesStorage.AccountParams(key);
            var result = await _client.GetStorageAsync<Hydration.NetApi.Generated.Model.pallet_balances.types.AccountData>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> LocksParams
        ///  Any liquidity locks on some account balances.
        ///  NOTE: Should only be accessed when setting, changing and freeing a lock.
        /// 
        ///  Use of locks is deprecated in favour of freezes. See `https://github.com/paritytech/substrate/pull/12951/`
        /// </summary>
        public static string LocksParams(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Balances", "Locks", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> LocksDefault
        /// Default value as hex string
        /// </summary>
        public static string LocksDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Locks
        ///  Any liquidity locks on some account balances.
        ///  NOTE: Should only be accessed when setting, changing and freeing a lock.
        /// 
        ///  Use of locks is deprecated in favour of freezes. See `https://github.com/paritytech/substrate/pull/12951/`
        /// </summary>
        public async Task<Hydration.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT2> Locks(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key, string blockhash, CancellationToken token)
        {
            string parameters = BalancesStorage.LocksParams(key);
            var result = await _client.GetStorageAsync<Hydration.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT2>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> ReservesParams
        ///  Named reserves on some account balances.
        /// 
        ///  Use of reserves is deprecated in favour of holds. See `https://github.com/paritytech/substrate/pull/12951/`
        /// </summary>
        public static string ReservesParams(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Balances", "Reserves", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ReservesDefault
        /// Default value as hex string
        /// </summary>
        public static string ReservesDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Reserves
        ///  Named reserves on some account balances.
        /// 
        ///  Use of reserves is deprecated in favour of holds. See `https://github.com/paritytech/substrate/pull/12951/`
        /// </summary>
        public async Task<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT11> Reserves(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key, string blockhash, CancellationToken token)
        {
            string parameters = BalancesStorage.ReservesParams(key);
            var result = await _client.GetStorageAsync<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT11>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> HoldsParams
        ///  Holds on account balances.
        /// </summary>
        public static string HoldsParams(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Balances", "Holds", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> HoldsDefault
        /// Default value as hex string
        /// </summary>
        public static string HoldsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Holds
        ///  Holds on account balances.
        /// </summary>
        public async Task<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT12> Holds(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key, string blockhash, CancellationToken token)
        {
            string parameters = BalancesStorage.HoldsParams(key);
            var result = await _client.GetStorageAsync<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT12>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> FreezesParams
        ///  Freeze locks on account balances.
        /// </summary>
        public static string FreezesParams(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Balances", "Freezes", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> FreezesDefault
        /// Default value as hex string
        /// </summary>
        public static string FreezesDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Freezes
        ///  Freeze locks on account balances.
        /// </summary>
        public async Task<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT13> Freezes(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 key, string blockhash, CancellationToken token)
        {
            string parameters = BalancesStorage.FreezesParams(key);
            var result = await _client.GetStorageAsync<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT13>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> BalancesCalls
    /// </summary>
    public sealed class BalancesCalls
    {
        
        /// <summary>
        /// >> transfer_allow_death
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method TransferAllowDeath(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 dest, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(value.Encode());
            return new Method(7, "Balances", 0, "transfer_allow_death", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_transfer
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ForceTransfer(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 source, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 dest, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(source.Encode());
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(value.Encode());
            return new Method(7, "Balances", 2, "force_transfer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> transfer_keep_alive
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method TransferKeepAlive(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 dest, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(value.Encode());
            return new Method(7, "Balances", 3, "transfer_keep_alive", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> transfer_all
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method TransferAll(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 dest, Substrate.NetApi.Model.Types.Primitive.Bool keep_alive)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(keep_alive.Encode());
            return new Method(7, "Balances", 4, "transfer_all", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_unreserve
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ForceUnreserve(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 who, Substrate.NetApi.Model.Types.Primitive.U128 amount)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(amount.Encode());
            return new Method(7, "Balances", 5, "force_unreserve", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> upgrade_accounts
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method UpgradeAccounts(Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32> who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            return new Method(7, "Balances", 6, "upgrade_accounts", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_set_balance
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ForceSetBalance(Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 who, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> new_free)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(new_free.Encode());
            return new Method(7, "Balances", 8, "force_set_balance", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_adjust_total_issuance
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ForceAdjustTotalIssuance(Hydration.NetApi.Generated.Model.pallet_balances.types.EnumAdjustmentDirection direction, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> delta)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(direction.Encode());
            byteArray.AddRange(delta.Encode());
            return new Method(7, "Balances", 9, "force_adjust_total_issuance", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> BalancesConstants
    /// </summary>
    public sealed class BalancesConstants
    {
        
        /// <summary>
        /// >> ExistentialDeposit
        ///  The minimum amount required to keep an account open. MUST BE GREATER THAN ZERO!
        /// 
        ///  If you *really* need it to be zero, you can enable the feature `insecure_zero_ed` for
        ///  this pallet. However, you do so at your own risk: this will open up a major DoS vector.
        ///  In case you have multiple sources of provider references, you may also get unexpected
        ///  behaviour if you set this to zero.
        /// 
        ///  Bottom line: Do yourself a favour and make it at least one!
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ExistentialDeposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0010A5D4E80000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxLocks
        ///  The maximum number of locks that should exist on an account.
        ///  Not strictly enforced, but used for weight estimation.
        /// 
        ///  Use of locks is deprecated in favour of freezes. See `https://github.com/paritytech/substrate/pull/12951/`
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxLocks()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x32000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxReserves
        ///  The maximum number of named reserves that can exist on an account.
        /// 
        ///  Use of reserves is deprecated in favour of holds. See `https://github.com/paritytech/substrate/pull/12951/`
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxReserves()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x32000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxFreezes
        ///  The maximum number of individual freeze locks that can exist on an account at any time.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxFreezes()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00000000");
            return result;
        }
    }
    
    /// <summary>
    /// >> BalancesErrors
    /// </summary>
    public enum BalancesErrors
    {
        
        /// <summary>
        /// >> VestingBalance
        /// Vesting balance too high to send value.
        /// </summary>
        VestingBalance,
        
        /// <summary>
        /// >> LiquidityRestrictions
        /// Account liquidity restrictions prevent withdrawal.
        /// </summary>
        LiquidityRestrictions,
        
        /// <summary>
        /// >> InsufficientBalance
        /// Balance too low to send value.
        /// </summary>
        InsufficientBalance,
        
        /// <summary>
        /// >> ExistentialDeposit
        /// Value too low to create account due to existential deposit.
        /// </summary>
        ExistentialDeposit,
        
        /// <summary>
        /// >> Expendability
        /// Transfer/payment would kill account.
        /// </summary>
        Expendability,
        
        /// <summary>
        /// >> ExistingVestingSchedule
        /// A vesting schedule already exists for this account.
        /// </summary>
        ExistingVestingSchedule,
        
        /// <summary>
        /// >> DeadAccount
        /// Beneficiary account must pre-exist.
        /// </summary>
        DeadAccount,
        
        /// <summary>
        /// >> TooManyReserves
        /// Number of named reserves exceed `MaxReserves`.
        /// </summary>
        TooManyReserves,
        
        /// <summary>
        /// >> TooManyHolds
        /// Number of holds exceed `VariantCountOf<T::RuntimeHoldReason>`.
        /// </summary>
        TooManyHolds,
        
        /// <summary>
        /// >> TooManyFreezes
        /// Number of freezes exceed `MaxFreezes`.
        /// </summary>
        TooManyFreezes,
        
        /// <summary>
        /// >> IssuanceDeactivated
        /// The issuance cannot be modified since it is already deactivated.
        /// </summary>
        IssuanceDeactivated,
        
        /// <summary>
        /// >> DeltaZero
        /// The delta cannot be zero.
        /// </summary>
        DeltaZero,
    }
}
