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


namespace Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives
{
    
    
    /// <summary>
    /// >> 322 - Composite[polkadot_parachain_primitives.primitives.HrmpChannelId]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class HrmpChannelId : BaseType
    {
        
        /// <summary>
        /// >> sender
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id Sender { get; set; }
        /// <summary>
        /// >> recipient
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id Recipient { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "HrmpChannelId";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Sender.Encode());
            result.AddRange(Recipient.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Sender = new Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id();
            Sender.Decode(byteArray, ref p);
            Recipient = new Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id();
            Recipient.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
