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


namespace Polkadot.NetApi.Generated.Model.pallet_staking.slashing
{
    
    
    /// <summary>
    /// >> 601 - Composite[pallet_staking.slashing.SpanRecord]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SpanRecord : BaseType
    {
        
        /// <summary>
        /// >> slashed
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Slashed { get; set; }
        /// <summary>
        /// >> paid_out
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 PaidOut { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "SpanRecord";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Slashed.Encode());
            result.AddRange(PaidOut.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Slashed = new Substrate.NetApi.Model.Types.Primitive.U128();
            Slashed.Decode(byteArray, ref p);
            PaidOut = new Substrate.NetApi.Model.Types.Primitive.U128();
            PaidOut.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
