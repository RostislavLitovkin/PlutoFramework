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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.shared
{
    
    
    /// <summary>
    /// >> 732 - Composite[polkadot_runtime_parachains.shared.RelayParentInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RelayParentInfo : BaseType
    {
        
        /// <summary>
        /// >> relay_parent
        /// </summary>
        public Polkadot.NetApi.Generated.Model.primitive_types.H256 RelayParent { get; set; }
        /// <summary>
        /// >> state_root
        /// </summary>
        public Polkadot.NetApi.Generated.Model.primitive_types.H256 StateRoot { get; set; }
        /// <summary>
        /// >> claim_queue
        /// </summary>
        public Polkadot.NetApi.Generated.Types.Base.BTreeMapT4 ClaimQueue { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "RelayParentInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RelayParent.Encode());
            result.AddRange(StateRoot.Encode());
            result.AddRange(ClaimQueue.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            RelayParent = new Polkadot.NetApi.Generated.Model.primitive_types.H256();
            RelayParent.Decode(byteArray, ref p);
            StateRoot = new Polkadot.NetApi.Generated.Model.primitive_types.H256();
            StateRoot.Decode(byteArray, ref p);
            ClaimQueue = new Polkadot.NetApi.Generated.Types.Base.BTreeMapT4();
            ClaimQueue.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
