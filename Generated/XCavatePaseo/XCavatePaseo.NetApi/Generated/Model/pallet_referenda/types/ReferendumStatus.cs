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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types
{
    
    
    /// <summary>
    /// >> 429 - Composite[pallet_referenda.types.ReferendumStatus]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReferendumStatus : BaseType
    {
        
        /// <summary>
        /// >> track
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U16 Track { get; set; }
        /// <summary>
        /// >> origin
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.generic_runtime_template.EnumOriginCaller Origin { get; set; }
        /// <summary>
        /// >> proposal
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.frame_support.traits.preimages.EnumBounded Proposal { get; set; }
        /// <summary>
        /// >> enactment
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.frame_support.traits.schedule.EnumDispatchTime Enactment { get; set; }
        /// <summary>
        /// >> submitted
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Submitted { get; set; }
        /// <summary>
        /// >> submission_deposit
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit SubmissionDeposit { get; set; }
        /// <summary>
        /// >> decision_deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit> DecisionDeposit { get; set; }
        /// <summary>
        /// >> deciding
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.DecidingStatus> Deciding { get; set; }
        /// <summary>
        /// >> tally
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.pallet_conviction_voting.types.Tally Tally { get; set; }
        /// <summary>
        /// >> in_queue
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool InQueue { get; set; }
        /// <summary>
        /// >> alarm
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>> Alarm { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ReferendumStatus";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Track.Encode());
            result.AddRange(Origin.Encode());
            result.AddRange(Proposal.Encode());
            result.AddRange(Enactment.Encode());
            result.AddRange(Submitted.Encode());
            result.AddRange(SubmissionDeposit.Encode());
            result.AddRange(DecisionDeposit.Encode());
            result.AddRange(Deciding.Encode());
            result.AddRange(Tally.Encode());
            result.AddRange(InQueue.Encode());
            result.AddRange(Alarm.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Track = new Substrate.NetApi.Model.Types.Primitive.U16();
            Track.Decode(byteArray, ref p);
            Origin = new XCavatePaseo.NetApi.Generated.Model.generic_runtime_template.EnumOriginCaller();
            Origin.Decode(byteArray, ref p);
            Proposal = new XCavatePaseo.NetApi.Generated.Model.frame_support.traits.preimages.EnumBounded();
            Proposal.Decode(byteArray, ref p);
            Enactment = new XCavatePaseo.NetApi.Generated.Model.frame_support.traits.schedule.EnumDispatchTime();
            Enactment.Decode(byteArray, ref p);
            Submitted = new Substrate.NetApi.Model.Types.Primitive.U32();
            Submitted.Decode(byteArray, ref p);
            SubmissionDeposit = new XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit();
            SubmissionDeposit.Decode(byteArray, ref p);
            DecisionDeposit = new Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.Deposit>();
            DecisionDeposit.Decode(byteArray, ref p);
            Deciding = new Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.pallet_referenda.types.DecidingStatus>();
            Deciding.Decode(byteArray, ref p);
            Tally = new XCavatePaseo.NetApi.Generated.Model.pallet_conviction_voting.types.Tally();
            Tally.Decode(byteArray, ref p);
            InQueue = new Substrate.NetApi.Model.Types.Primitive.Bool();
            InQueue.Decode(byteArray, ref p);
            Alarm = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>();
            Alarm.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
