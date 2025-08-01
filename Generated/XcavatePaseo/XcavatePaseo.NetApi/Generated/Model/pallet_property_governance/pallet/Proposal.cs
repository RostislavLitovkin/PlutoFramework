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
    /// >> 530 - Composite[pallet_property_governance.pallet.Proposal]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Proposal : BaseType
    {
        
        /// <summary>
        /// >> proposer
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 Proposer { get; set; }
        /// <summary>
        /// >> asset_id
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 AssetId { get; set; }
        /// <summary>
        /// >> amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Amount { get; set; }
        /// <summary>
        /// >> created_at
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 CreatedAt { get; set; }
        /// <summary>
        /// >> metadata
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT2 Metadata { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Proposal";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Proposer.Encode());
            result.AddRange(AssetId.Encode());
            result.AddRange(Amount.Encode());
            result.AddRange(CreatedAt.Encode());
            result.AddRange(Metadata.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Proposer = new XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Proposer.Decode(byteArray, ref p);
            AssetId = new Substrate.NetApi.Model.Types.Primitive.U32();
            AssetId.Decode(byteArray, ref p);
            Amount = new Substrate.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            CreatedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            CreatedAt.Decode(byteArray, ref p);
            Metadata = new XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT2();
            Metadata.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
