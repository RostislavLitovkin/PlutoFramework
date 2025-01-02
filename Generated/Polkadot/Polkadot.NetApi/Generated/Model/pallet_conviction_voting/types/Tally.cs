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


namespace Polkadot.NetApi.Generated.Model.pallet_conviction_voting.types
{
    
    
    /// <summary>
    /// >> 448 - Composite[pallet_conviction_voting.types.Tally]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Tally : BaseType
    {
        
        /// <summary>
        /// >> ayes
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Ayes { get; set; }
        /// <summary>
        /// >> nays
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Nays { get; set; }
        /// <summary>
        /// >> support
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Support { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Tally";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(Support.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Ayes = new Substrate.NetApi.Model.Types.Primitive.U128();
            Ayes.Decode(byteArray, ref p);
            Nays = new Substrate.NetApi.Model.Types.Primitive.U128();
            Nays.Decode(byteArray, ref p);
            Support = new Substrate.NetApi.Model.Types.Primitive.U128();
            Support.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
