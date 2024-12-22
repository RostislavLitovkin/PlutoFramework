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


namespace PolkadotAssetHub.NetApi.Generated.Model.frame_system
{
    
    
    /// <summary>
    /// >> 20 - Composite[frame_system.EventRecord]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EventRecord : BaseType
    {
        
        /// <summary>
        /// >> phase
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.frame_system.EnumPhase Phase { get; set; }
        /// <summary>
        /// >> event
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.asset_hub_polkadot_runtime.EnumRuntimeEvent Event { get; set; }
        /// <summary>
        /// >> topics
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotAssetHub.NetApi.Generated.Model.primitive_types.H256> Topics { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "EventRecord";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Phase.Encode());
            result.AddRange(Event.Encode());
            result.AddRange(Topics.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Phase = new PolkadotAssetHub.NetApi.Generated.Model.frame_system.EnumPhase();
            Phase.Decode(byteArray, ref p);
            Event = new PolkadotAssetHub.NetApi.Generated.Model.asset_hub_polkadot_runtime.EnumRuntimeEvent();
            Event.Decode(byteArray, ref p);
            Topics = new Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotAssetHub.NetApi.Generated.Model.primitive_types.H256>();
            Topics.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
