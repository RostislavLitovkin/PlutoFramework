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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_balances.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> transfer_allow_death
        /// Transfer some liquid free balance to another account.
        /// 
        /// `transfer_allow_death` will set the `FreeBalance` of the sender and receiver.
        /// If the sender's account is below the existential deposit as a result
        /// of the transfer, the account will be reaped.
        /// 
        /// The dispatch origin for this call must be `Signed` by the transactor.
        /// </summary>
        transfer_allow_death = 0,
        
        /// <summary>
        /// >> force_transfer
        /// Exactly as `transfer_allow_death`, except the origin must be root and the source account
        /// may be specified.
        /// </summary>
        force_transfer = 2,
        
        /// <summary>
        /// >> transfer_keep_alive
        /// Same as the [`transfer_allow_death`] call, but with a check that the transfer will not
        /// kill the origin account.
        /// 
        /// 99% of the time you want [`transfer_allow_death`] instead.
        /// 
        /// [`transfer_allow_death`]: struct.Pallet.html#method.transfer
        /// </summary>
        transfer_keep_alive = 3,
        
        /// <summary>
        /// >> transfer_all
        /// Transfer the entire transferable balance from the caller account.
        /// 
        /// NOTE: This function only attempts to transfer _transferable_ balances. This means that
        /// any locked, reserved, or existential deposits (when `keep_alive` is `true`), will not be
        /// transferred by this function. To ensure that this function results in a killed account,
        /// you might need to prepare the account by removing any reference counters, storage
        /// deposits, etc...
        /// 
        /// The dispatch origin of this call must be Signed.
        /// 
        /// - `dest`: The recipient of the transfer.
        /// - `keep_alive`: A boolean to determine if the `transfer_all` operation should send all
        ///   of the funds the account has, causing the sender account to be killed (false), or
        ///   transfer everything except at least the existential deposit, which will guarantee to
        ///   keep the sender account alive (true).
        /// </summary>
        transfer_all = 4,
        
        /// <summary>
        /// >> force_unreserve
        /// Unreserve some balance from a user by force.
        /// 
        /// Can only be called by ROOT.
        /// </summary>
        force_unreserve = 5,
        
        /// <summary>
        /// >> upgrade_accounts
        /// Upgrade a specified account.
        /// 
        /// - `origin`: Must be `Signed`.
        /// - `who`: The account to be upgraded.
        /// 
        /// This will waive the transaction fee if at least all but 10% of the accounts needed to
        /// be upgraded. (We let some not have to be upgraded just in order to allow for the
        /// possibility of churn).
        /// </summary>
        upgrade_accounts = 6,
        
        /// <summary>
        /// >> force_set_balance
        /// Set the regular balance of a given account.
        /// 
        /// The dispatch origin for this call is `root`.
        /// </summary>
        force_set_balance = 8,
        
        /// <summary>
        /// >> force_adjust_total_issuance
        /// Adjust the total issuance in a saturating way.
        /// 
        /// Can only be called by root and always needs a positive `delta`.
        /// 
        /// # Example
        /// </summary>
        force_adjust_total_issuance = 9,
    }
    
    /// <summary>
    /// >> 252 - Variant[pallet_balances.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.transfer_allow_death);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.force_transfer);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.transfer_keep_alive);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.transfer_all);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.force_unreserve);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Call.upgrade_accounts);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.force_set_balance);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.pallet_balances.types.EnumAdjustmentDirection, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.force_adjust_total_issuance);
        }
    }
}
