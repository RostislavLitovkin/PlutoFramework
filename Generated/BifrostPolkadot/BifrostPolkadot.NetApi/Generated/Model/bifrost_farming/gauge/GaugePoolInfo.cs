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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_farming.gauge
{
    
    
    /// <summary>
    /// >> 930 - Composite[bifrost_farming.gauge.GaugePoolInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class GaugePoolInfo : BaseType
    {
        
        /// <summary>
        /// >> pid
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Pid { get; set; }
        /// <summary>
        /// >> token
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId Token { get; set; }
        /// <summary>
        /// >> keeper
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32 Keeper { get; set; }
        /// <summary>
        /// >> reward_issuer
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32 RewardIssuer { get; set; }
        /// <summary>
        /// >> rewards
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Types.Base.BTreeMapT14 Rewards { get; set; }
        /// <summary>
        /// >> gauge_basic_rewards
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Types.Base.BTreeMapT8 GaugeBasicRewards { get; set; }
        /// <summary>
        /// >> max_block
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxBlock { get; set; }
        /// <summary>
        /// >> gauge_amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 GaugeAmount { get; set; }
        /// <summary>
        /// >> total_time_factor
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TotalTimeFactor { get; set; }
        /// <summary>
        /// >> gauge_state
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.bifrost_farming.gauge.EnumGaugeState GaugeState { get; set; }
        /// <summary>
        /// >> gauge_last_block
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 GaugeLastBlock { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "GaugePoolInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Pid.Encode());
            result.AddRange(Token.Encode());
            result.AddRange(Keeper.Encode());
            result.AddRange(RewardIssuer.Encode());
            result.AddRange(Rewards.Encode());
            result.AddRange(GaugeBasicRewards.Encode());
            result.AddRange(MaxBlock.Encode());
            result.AddRange(GaugeAmount.Encode());
            result.AddRange(TotalTimeFactor.Encode());
            result.AddRange(GaugeState.Encode());
            result.AddRange(GaugeLastBlock.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Pid = new Substrate.NetApi.Model.Types.Primitive.U32();
            Pid.Decode(byteArray, ref p);
            Token = new BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId();
            Token.Decode(byteArray, ref p);
            Keeper = new BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Keeper.Decode(byteArray, ref p);
            RewardIssuer = new BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            RewardIssuer.Decode(byteArray, ref p);
            Rewards = new BifrostPolkadot.NetApi.Generated.Types.Base.BTreeMapT14();
            Rewards.Decode(byteArray, ref p);
            GaugeBasicRewards = new BifrostPolkadot.NetApi.Generated.Types.Base.BTreeMapT8();
            GaugeBasicRewards.Decode(byteArray, ref p);
            MaxBlock = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxBlock.Decode(byteArray, ref p);
            GaugeAmount = new Substrate.NetApi.Model.Types.Primitive.U128();
            GaugeAmount.Decode(byteArray, ref p);
            TotalTimeFactor = new Substrate.NetApi.Model.Types.Primitive.U128();
            TotalTimeFactor.Decode(byteArray, ref p);
            GaugeState = new BifrostPolkadot.NetApi.Generated.Model.bifrost_farming.gauge.EnumGaugeState();
            GaugeState.Decode(byteArray, ref p);
            GaugeLastBlock = new Substrate.NetApi.Model.Types.Primitive.U32();
            GaugeLastBlock.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
