//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System.Collections.Generic;


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_farming.rewards
{
    
    
    /// <summary>
    /// >> 937 - Composite[bifrost_farming.rewards.ShareInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ShareInfo : BaseType
    {
        
        /// <summary>
        /// >> who
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32 Who { get; set; }
        /// <summary>
        /// >> share
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Share { get; set; }
        /// <summary>
        /// >> withdrawn_rewards
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Types.Base.BTreeMapT8 WithdrawnRewards { get; set; }
        /// <summary>
        /// >> claim_last_block
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ClaimLastBlock { get; set; }
        /// <summary>
        /// >> withdraw_list
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>> WithdrawList { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ShareInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Share.Encode());
            result.AddRange(WithdrawnRewards.Encode());
            result.AddRange(ClaimLastBlock.Encode());
            result.AddRange(WithdrawList.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Share = new Substrate.NetApi.Model.Types.Primitive.U128();
            Share.Decode(byteArray, ref p);
            WithdrawnRewards = new BifrostPolkadot.NetApi.Generated.Types.Base.BTreeMapT8();
            WithdrawnRewards.Decode(byteArray, ref p);
            ClaimLastBlock = new Substrate.NetApi.Model.Types.Primitive.U32();
            ClaimLastBlock.Decode(byteArray, ref p);
            WithdrawList = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>();
            WithdrawList.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
