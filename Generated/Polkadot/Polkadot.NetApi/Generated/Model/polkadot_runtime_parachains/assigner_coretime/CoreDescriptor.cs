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
    /// >> 787 - Composite[polkadot_runtime_parachains.assigner_coretime.CoreDescriptor]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CoreDescriptor : BaseType
    {
        
        /// <summary>
        /// >> queue
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime.QueueDescriptor> Queue { get; set; }
        /// <summary>
        /// >> current_work
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime.WorkState> CurrentWork { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CoreDescriptor";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Queue.Encode());
            result.AddRange(CurrentWork.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Queue = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime.QueueDescriptor>();
            Queue.Decode(byteArray, ref p);
            CurrentWork = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime.WorkState>();
            CurrentWork.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
