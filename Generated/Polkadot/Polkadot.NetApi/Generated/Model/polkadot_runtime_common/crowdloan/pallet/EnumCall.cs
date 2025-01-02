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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_common.crowdloan.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> create
        /// Create a new crowdloaning campaign for a parachain slot with the given lease period
        /// range.
        /// 
        /// This applies a lock to your parachain configuration, ensuring that it cannot be changed
        /// by the parachain manager.
        /// </summary>
        create = 0,
        
        /// <summary>
        /// >> contribute
        /// Contribute to a crowd sale. This will transfer some balance over to fund a parachain
        /// slot. It will be withdrawable when the crowdloan has ended and the funds are unused.
        /// </summary>
        contribute = 1,
        
        /// <summary>
        /// >> withdraw
        /// Withdraw full balance of a specific contributor.
        /// 
        /// Origin must be signed, but can come from anyone.
        /// 
        /// The fund must be either in, or ready for, retirement. For a fund to be *in* retirement,
        /// then the retirement flag must be set. For a fund to be ready for retirement, then:
        /// - it must not already be in retirement;
        /// - the amount of raised funds must be bigger than the _free_ balance of the account;
        /// - and either:
        ///   - the block number must be at least `end`; or
        ///   - the current lease period must be greater than the fund's `last_period`.
        /// 
        /// In this case, the fund's retirement flag is set and its `end` is reset to the current
        /// block number.
        /// 
        /// - `who`: The account whose contribution should be withdrawn.
        /// - `index`: The parachain to whose crowdloan the contribution was made.
        /// </summary>
        withdraw = 2,
        
        /// <summary>
        /// >> refund
        /// Automatically refund contributors of an ended crowdloan.
        /// Due to weight restrictions, this function may need to be called multiple
        /// times to fully refund all users. We will refund `RemoveKeysLimit` users at a time.
        /// 
        /// Origin must be signed, but can come from anyone.
        /// </summary>
        refund = 3,
        
        /// <summary>
        /// >> dissolve
        /// Remove a fund after the retirement period has ended and all funds have been returned.
        /// </summary>
        dissolve = 4,
        
        /// <summary>
        /// >> edit
        /// Edit the configuration for an in-progress crowdloan.
        /// 
        /// Can only be called by Root origin.
        /// </summary>
        edit = 5,
        
        /// <summary>
        /// >> add_memo
        /// Add an optional memo to an existing crowdloan contribution.
        /// 
        /// Origin must be Signed, and the user must have contributed to the crowdloan.
        /// </summary>
        add_memo = 6,
        
        /// <summary>
        /// >> poke
        /// Poke the fund into `NewRaise`
        /// 
        /// Origin must be Signed, and the fund has non-zero raise.
        /// </summary>
        poke = 7,
        
        /// <summary>
        /// >> contribute_all
        /// Contribute your entire balance to a crowd sale. This will transfer the entire balance of
        /// a user over to fund a parachain slot. It will be withdrawable when the crowdloan has
        /// ended and the funds are unused.
        /// </summary>
        contribute_all = 8,
    }
    
    /// <summary>
    /// >> 337 - Variant[polkadot_runtime_common.crowdloan.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_runtime.EnumMultiSigner>>>(Call.create);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_runtime.EnumMultiSignature>>>(Call.contribute);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseCom<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>>>(Call.withdraw);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>>(Call.refund);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>>(Call.dissolve);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_runtime.EnumMultiSigner>>>(Call.edit);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>(Call.add_memo);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>(Call.poke);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_runtime.EnumMultiSignature>>>(Call.contribute_all);
        }
    }
}
