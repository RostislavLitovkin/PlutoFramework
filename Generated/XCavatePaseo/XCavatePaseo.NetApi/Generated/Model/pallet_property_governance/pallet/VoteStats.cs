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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_property_governance.pallet
{
    
    
    /// <summary>
    /// >> 505 - Composite[pallet_property_governance.pallet.VoteStats]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class VoteStats : BaseType
    {
        
        /// <summary>
        /// >> yes_votes
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 YesVotes { get; set; }
        /// <summary>
        /// >> no_votes
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 NoVotes { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "VoteStats";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(YesVotes.Encode());
            result.AddRange(NoVotes.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            YesVotes = new Substrate.NetApi.Model.Types.Primitive.U32();
            YesVotes.Decode(byteArray, ref p);
            NoVotes = new Substrate.NetApi.Model.Types.Primitive.U32();
            NoVotes.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
