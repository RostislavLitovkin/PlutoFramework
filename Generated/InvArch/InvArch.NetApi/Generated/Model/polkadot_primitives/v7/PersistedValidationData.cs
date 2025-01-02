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


namespace InvArch.NetApi.Generated.Model.polkadot_primitives.v7
{
    
    
    /// <summary>
    /// >> 167 - Composite[polkadot_primitives.v7.PersistedValidationData]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PersistedValidationData : BaseType
    {
        
        /// <summary>
        /// >> parent_head
        /// </summary>
        public InvArch.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.HeadData ParentHead { get; set; }
        /// <summary>
        /// >> relay_parent_number
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 RelayParentNumber { get; set; }
        /// <summary>
        /// >> relay_parent_storage_root
        /// </summary>
        public InvArch.NetApi.Generated.Model.primitive_types.H256 RelayParentStorageRoot { get; set; }
        /// <summary>
        /// >> max_pov_size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxPovSize { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PersistedValidationData";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParentHead.Encode());
            result.AddRange(RelayParentNumber.Encode());
            result.AddRange(RelayParentStorageRoot.Encode());
            result.AddRange(MaxPovSize.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParentHead = new InvArch.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.HeadData();
            ParentHead.Decode(byteArray, ref p);
            RelayParentNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            RelayParentNumber.Decode(byteArray, ref p);
            RelayParentStorageRoot = new InvArch.NetApi.Generated.Model.primitive_types.H256();
            RelayParentStorageRoot.Decode(byteArray, ref p);
            MaxPovSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxPovSize.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
