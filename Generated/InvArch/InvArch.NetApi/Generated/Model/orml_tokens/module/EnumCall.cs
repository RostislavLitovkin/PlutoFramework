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


namespace InvArch.NetApi.Generated.Model.orml_tokens.module
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> transfer
        /// Transfer some liquid free balance to another account.
        /// 
        /// `transfer` will set the `FreeBalance` of the sender and receiver.
        /// It will decrease the total issuance of the system by the
        /// `TransferFee`. If the sender's account is below the existential
        /// deposit as a result of the transfer, the account will be reaped.
        /// 
        /// The dispatch origin for this call must be `Signed` by the
        /// transactor.
        /// 
        /// - `dest`: The recipient of the transfer.
        /// - `currency_id`: currency type.
        /// - `amount`: free balance amount to tranfer.
        /// </summary>
        transfer = 0,
        
        /// <summary>
        /// >> transfer_all
        /// Transfer all remaining balance to the given account.
        /// 
        /// NOTE: This function only attempts to transfer _transferable_
        /// balances. This means that any locked, reserved, or existential
        /// deposits (when `keep_alive` is `true`), will not be transferred by
        /// this function. To ensure that this function results in a killed
        /// account, you might need to prepare the account by removing any
        /// reference counters, storage deposits, etc...
        /// 
        /// The dispatch origin for this call must be `Signed` by the
        /// transactor.
        /// 
        /// - `dest`: The recipient of the transfer.
        /// - `currency_id`: currency type.
        /// - `keep_alive`: A boolean to determine if the `transfer_all`
        ///   operation should send all of the funds the account has, causing
        ///   the sender account to be killed (false), or transfer everything
        ///   except at least the existential deposit, which will guarantee to
        ///   keep the sender account alive (true).
        /// </summary>
        transfer_all = 1,
        
        /// <summary>
        /// >> transfer_keep_alive
        /// Same as the [`transfer`] call, but with a check that the transfer
        /// will not kill the origin account.
        /// 
        /// 99% of the time you want [`transfer`] instead.
        /// 
        /// The dispatch origin for this call must be `Signed` by the
        /// transactor.
        /// 
        /// - `dest`: The recipient of the transfer.
        /// - `currency_id`: currency type.
        /// - `amount`: free balance amount to tranfer.
        /// </summary>
        transfer_keep_alive = 2,
        
        /// <summary>
        /// >> force_transfer
        /// Exactly as `transfer`, except the origin must be root and the source
        /// account may be specified.
        /// 
        /// The dispatch origin for this call must be _Root_.
        /// 
        /// - `source`: The sender of the transfer.
        /// - `dest`: The recipient of the transfer.
        /// - `currency_id`: currency type.
        /// - `amount`: free balance amount to tranfer.
        /// </summary>
        force_transfer = 3,
        
        /// <summary>
        /// >> set_balance
        /// Set the balances of a given account.
        /// 
        /// This will alter `FreeBalance` and `ReservedBalance` in storage. it
        /// will also decrease the total issuance of the system
        /// (`TotalIssuance`). If the new free or reserved balance is below the
        /// existential deposit, it will reap the `AccountInfo`.
        /// 
        /// The dispatch origin for this call is `root`.
        /// </summary>
        set_balance = 4,
    }
    
    /// <summary>
    /// >> 313 - Variant[orml_tokens.module.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.transfer);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.transfer_all);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.transfer_keep_alive);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, InvArch.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.force_transfer);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.set_balance);
        }
    }
}
