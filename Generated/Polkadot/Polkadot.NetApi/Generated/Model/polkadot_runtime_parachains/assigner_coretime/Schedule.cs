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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime
{
    
    
    /// <summary>
    /// >> 810 - Composite[polkadot_runtime_parachains.assigner_coretime.Schedule]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Schedule : BaseType
    {
        
        /// <summary>
        /// >> assignments
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.pallet_broker.coretime_interface.EnumCoreAssignment, Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime.PartsOf57600>> Assignments { get; set; }
        /// <summary>
        /// >> end_hint
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> EndHint { get; set; }
        /// <summary>
        /// >> next_schedule
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> NextSchedule { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Schedule";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Assignments.Encode());
            result.AddRange(EndHint.Encode());
            result.AddRange(NextSchedule.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Assignments = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.pallet_broker.coretime_interface.EnumCoreAssignment, Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime.PartsOf57600>>();
            Assignments.Decode(byteArray, ref p);
            EndHint = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            EndHint.Decode(byteArray, ref p);
            NextSchedule = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            NextSchedule.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
