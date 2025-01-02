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


namespace Polkadot.NetApi.Generated.Model.polkadot_primitives.v7.slashing
{
    
    
    /// <summary>
    /// >> 768 - Composite[polkadot_primitives.v7.slashing.PendingSlashes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PendingSlashes : BaseType
    {
        
        /// <summary>
        /// >> keys
        /// </summary>
        public Polkadot.NetApi.Generated.Types.Base.BTreeMapT5 Keys { get; set; }
        /// <summary>
        /// >> kind
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v7.slashing.EnumSlashingOffenceKind Kind { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PendingSlashes";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Keys.Encode());
            result.AddRange(Kind.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Keys = new Polkadot.NetApi.Generated.Types.Base.BTreeMapT5();
            Keys.Decode(byteArray, ref p);
            Kind = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v7.slashing.EnumSlashingOffenceKind();
            Kind.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
