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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.configuration
{
    
    
    /// <summary>
    /// >> 724 - Composite[polkadot_runtime_parachains.configuration.HostConfiguration]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class HostConfiguration : BaseType
    {
        
        /// <summary>
        /// >> max_code_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxCodeSize { get; set; }
        /// <summary>
        /// >> max_head_data_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxHeadDataSize { get; set; }
        /// <summary>
        /// >> max_upward_queue_count
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxUpwardQueueCount { get; set; }
        /// <summary>
        /// >> max_upward_queue_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxUpwardQueueSize { get; set; }
        /// <summary>
        /// >> max_upward_message_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxUpwardMessageSize { get; set; }
        /// <summary>
        /// >> max_upward_message_num_per_candidate
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxUpwardMessageNumPerCandidate { get; set; }
        /// <summary>
        /// >> hrmp_max_message_num_per_candidate
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HrmpMaxMessageNumPerCandidate { get; set; }
        /// <summary>
        /// >> validation_upgrade_cooldown
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ValidationUpgradeCooldown { get; set; }
        /// <summary>
        /// >> validation_upgrade_delay
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ValidationUpgradeDelay { get; set; }
        /// <summary>
        /// >> async_backing_params
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.async_backing.AsyncBackingParams AsyncBackingParams { get; set; }
        /// <summary>
        /// >> max_pov_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxPovSize { get; set; }
        /// <summary>
        /// >> max_downward_message_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxDownwardMessageSize { get; set; }
        /// <summary>
        /// >> hrmp_max_parachain_outbound_channels
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HrmpMaxParachainOutboundChannels { get; set; }
        /// <summary>
        /// >> hrmp_sender_deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 HrmpSenderDeposit { get; set; }
        /// <summary>
        /// >> hrmp_recipient_deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 HrmpRecipientDeposit { get; set; }
        /// <summary>
        /// >> hrmp_channel_max_capacity
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HrmpChannelMaxCapacity { get; set; }
        /// <summary>
        /// >> hrmp_channel_max_total_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HrmpChannelMaxTotalSize { get; set; }
        /// <summary>
        /// >> hrmp_max_parachain_inbound_channels
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HrmpMaxParachainInboundChannels { get; set; }
        /// <summary>
        /// >> hrmp_channel_max_message_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HrmpChannelMaxMessageSize { get; set; }
        /// <summary>
        /// >> executor_params
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.executor_params.ExecutorParams ExecutorParams { get; set; }
        /// <summary>
        /// >> code_retention_period
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 CodeRetentionPeriod { get; set; }
        /// <summary>
        /// >> max_validators
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> MaxValidators { get; set; }
        /// <summary>
        /// >> dispute_period
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 DisputePeriod { get; set; }
        /// <summary>
        /// >> dispute_post_conclusion_acceptance_period
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 DisputePostConclusionAcceptancePeriod { get; set; }
        /// <summary>
        /// >> no_show_slots
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 NoShowSlots { get; set; }
        /// <summary>
        /// >> n_delay_tranches
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 NDelayTranches { get; set; }
        /// <summary>
        /// >> zeroth_delay_tranche_width
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ZerothDelayTrancheWidth { get; set; }
        /// <summary>
        /// >> needed_approvals
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 NeededApprovals { get; set; }
        /// <summary>
        /// >> relay_vrf_modulo_samples
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 RelayVrfModuloSamples { get; set; }
        /// <summary>
        /// >> pvf_voting_ttl
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 PvfVotingTtl { get; set; }
        /// <summary>
        /// >> minimum_validation_upgrade_delay
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MinimumValidationUpgradeDelay { get; set; }
        /// <summary>
        /// >> minimum_backing_votes
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MinimumBackingVotes { get; set; }
        /// <summary>
        /// >> node_features
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkadot.NetApi.Generated.Model.bitvec.order.Lsb0> NodeFeatures { get; set; }
        /// <summary>
        /// >> approval_voting_params
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.ApprovalVotingParams ApprovalVotingParams { get; set; }
        /// <summary>
        /// >> scheduler_params
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.SchedulerParams SchedulerParams { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "HostConfiguration";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaxCodeSize.Encode());
            result.AddRange(MaxHeadDataSize.Encode());
            result.AddRange(MaxUpwardQueueCount.Encode());
            result.AddRange(MaxUpwardQueueSize.Encode());
            result.AddRange(MaxUpwardMessageSize.Encode());
            result.AddRange(MaxUpwardMessageNumPerCandidate.Encode());
            result.AddRange(HrmpMaxMessageNumPerCandidate.Encode());
            result.AddRange(ValidationUpgradeCooldown.Encode());
            result.AddRange(ValidationUpgradeDelay.Encode());
            result.AddRange(AsyncBackingParams.Encode());
            result.AddRange(MaxPovSize.Encode());
            result.AddRange(MaxDownwardMessageSize.Encode());
            result.AddRange(HrmpMaxParachainOutboundChannels.Encode());
            result.AddRange(HrmpSenderDeposit.Encode());
            result.AddRange(HrmpRecipientDeposit.Encode());
            result.AddRange(HrmpChannelMaxCapacity.Encode());
            result.AddRange(HrmpChannelMaxTotalSize.Encode());
            result.AddRange(HrmpMaxParachainInboundChannels.Encode());
            result.AddRange(HrmpChannelMaxMessageSize.Encode());
            result.AddRange(ExecutorParams.Encode());
            result.AddRange(CodeRetentionPeriod.Encode());
            result.AddRange(MaxValidators.Encode());
            result.AddRange(DisputePeriod.Encode());
            result.AddRange(DisputePostConclusionAcceptancePeriod.Encode());
            result.AddRange(NoShowSlots.Encode());
            result.AddRange(NDelayTranches.Encode());
            result.AddRange(ZerothDelayTrancheWidth.Encode());
            result.AddRange(NeededApprovals.Encode());
            result.AddRange(RelayVrfModuloSamples.Encode());
            result.AddRange(PvfVotingTtl.Encode());
            result.AddRange(MinimumValidationUpgradeDelay.Encode());
            result.AddRange(MinimumBackingVotes.Encode());
            result.AddRange(NodeFeatures.Encode());
            result.AddRange(ApprovalVotingParams.Encode());
            result.AddRange(SchedulerParams.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaxCodeSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxCodeSize.Decode(byteArray, ref p);
            MaxHeadDataSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxHeadDataSize.Decode(byteArray, ref p);
            MaxUpwardQueueCount = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardQueueCount.Decode(byteArray, ref p);
            MaxUpwardQueueSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardQueueSize.Decode(byteArray, ref p);
            MaxUpwardMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardMessageSize.Decode(byteArray, ref p);
            MaxUpwardMessageNumPerCandidate = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardMessageNumPerCandidate.Decode(byteArray, ref p);
            HrmpMaxMessageNumPerCandidate = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxMessageNumPerCandidate.Decode(byteArray, ref p);
            ValidationUpgradeCooldown = new Substrate.NetApi.Model.Types.Primitive.U32();
            ValidationUpgradeCooldown.Decode(byteArray, ref p);
            ValidationUpgradeDelay = new Substrate.NetApi.Model.Types.Primitive.U32();
            ValidationUpgradeDelay.Decode(byteArray, ref p);
            AsyncBackingParams = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.async_backing.AsyncBackingParams();
            AsyncBackingParams.Decode(byteArray, ref p);
            MaxPovSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxPovSize.Decode(byteArray, ref p);
            MaxDownwardMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxDownwardMessageSize.Decode(byteArray, ref p);
            HrmpMaxParachainOutboundChannels = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxParachainOutboundChannels.Decode(byteArray, ref p);
            HrmpSenderDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            HrmpSenderDeposit.Decode(byteArray, ref p);
            HrmpRecipientDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            HrmpRecipientDeposit.Decode(byteArray, ref p);
            HrmpChannelMaxCapacity = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpChannelMaxCapacity.Decode(byteArray, ref p);
            HrmpChannelMaxTotalSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpChannelMaxTotalSize.Decode(byteArray, ref p);
            HrmpMaxParachainInboundChannels = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxParachainInboundChannels.Decode(byteArray, ref p);
            HrmpChannelMaxMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpChannelMaxMessageSize.Decode(byteArray, ref p);
            ExecutorParams = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.executor_params.ExecutorParams();
            ExecutorParams.Decode(byteArray, ref p);
            CodeRetentionPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            CodeRetentionPeriod.Decode(byteArray, ref p);
            MaxValidators = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            MaxValidators.Decode(byteArray, ref p);
            DisputePeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputePeriod.Decode(byteArray, ref p);
            DisputePostConclusionAcceptancePeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputePostConclusionAcceptancePeriod.Decode(byteArray, ref p);
            NoShowSlots = new Substrate.NetApi.Model.Types.Primitive.U32();
            NoShowSlots.Decode(byteArray, ref p);
            NDelayTranches = new Substrate.NetApi.Model.Types.Primitive.U32();
            NDelayTranches.Decode(byteArray, ref p);
            ZerothDelayTrancheWidth = new Substrate.NetApi.Model.Types.Primitive.U32();
            ZerothDelayTrancheWidth.Decode(byteArray, ref p);
            NeededApprovals = new Substrate.NetApi.Model.Types.Primitive.U32();
            NeededApprovals.Decode(byteArray, ref p);
            RelayVrfModuloSamples = new Substrate.NetApi.Model.Types.Primitive.U32();
            RelayVrfModuloSamples.Decode(byteArray, ref p);
            PvfVotingTtl = new Substrate.NetApi.Model.Types.Primitive.U32();
            PvfVotingTtl.Decode(byteArray, ref p);
            MinimumValidationUpgradeDelay = new Substrate.NetApi.Model.Types.Primitive.U32();
            MinimumValidationUpgradeDelay.Decode(byteArray, ref p);
            MinimumBackingVotes = new Substrate.NetApi.Model.Types.Primitive.U32();
            MinimumBackingVotes.Decode(byteArray, ref p);
            NodeFeatures = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkadot.NetApi.Generated.Model.bitvec.order.Lsb0>();
            NodeFeatures.Decode(byteArray, ref p);
            ApprovalVotingParams = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.ApprovalVotingParams();
            ApprovalVotingParams.Decode(byteArray, ref p);
            SchedulerParams = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.SchedulerParams();
            SchedulerParams.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
