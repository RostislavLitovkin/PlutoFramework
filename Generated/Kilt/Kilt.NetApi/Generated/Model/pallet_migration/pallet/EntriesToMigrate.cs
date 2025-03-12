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


namespace Kilt.NetApi.Generated.Model.pallet_migration.pallet
{
    
    
    /// <summary>
    /// >> 152 - Composite[pallet_migration.pallet.EntriesToMigrate]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EntriesToMigrate : BaseType
    {
        
        /// <summary>
        /// >> attestation
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6 Attestation { get; set; }
        /// <summary>
        /// >> delegation
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6 Delegation { get; set; }
        /// <summary>
        /// >> did
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT7 Did { get; set; }
        /// <summary>
        /// >> lookup
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT8 Lookup { get; set; }
        /// <summary>
        /// >> w3n
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9 W3n { get; set; }
        /// <summary>
        /// >> public_credentials
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT10 PublicCredentials { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "EntriesToMigrate";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Attestation.Encode());
            result.AddRange(Delegation.Encode());
            result.AddRange(Did.Encode());
            result.AddRange(Lookup.Encode());
            result.AddRange(W3n.Encode());
            result.AddRange(PublicCredentials.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Attestation = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6();
            Attestation.Decode(byteArray, ref p);
            Delegation = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT6();
            Delegation.Decode(byteArray, ref p);
            Did = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT7();
            Did.Decode(byteArray, ref p);
            Lookup = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT8();
            Lookup.Decode(byteArray, ref p);
            W3n = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9();
            W3n.Decode(byteArray, ref p);
            PublicCredentials = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT10();
            PublicCredentials.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
