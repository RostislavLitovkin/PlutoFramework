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


namespace BifrostPolkadot.NetApi.Generated.Model.ethereum.header
{
    
    
    /// <summary>
    /// >> 852 - Composite[ethereum.header.Header]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Header : BaseType
    {
        
        /// <summary>
        /// >> parent_hash
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256 ParentHash { get; set; }
        /// <summary>
        /// >> ommers_hash
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256 OmmersHash { get; set; }
        /// <summary>
        /// >> beneficiary
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160 Beneficiary { get; set; }
        /// <summary>
        /// >> state_root
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256 StateRoot { get; set; }
        /// <summary>
        /// >> transactions_root
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256 TransactionsRoot { get; set; }
        /// <summary>
        /// >> receipts_root
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256 ReceiptsRoot { get; set; }
        /// <summary>
        /// >> logs_bloom
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.ethbloom.Bloom LogsBloom { get; set; }
        /// <summary>
        /// >> difficulty
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256 Difficulty { get; set; }
        /// <summary>
        /// >> number
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256 Number { get; set; }
        /// <summary>
        /// >> gas_limit
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256 GasLimit { get; set; }
        /// <summary>
        /// >> gas_used
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256 GasUsed { get; set; }
        /// <summary>
        /// >> timestamp
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Timestamp { get; set; }
        /// <summary>
        /// >> extra_data
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> ExtraData { get; set; }
        /// <summary>
        /// >> mix_hash
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256 MixHash { get; set; }
        /// <summary>
        /// >> nonce
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.ethereum_types.hash.H64 Nonce { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Header";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParentHash.Encode());
            result.AddRange(OmmersHash.Encode());
            result.AddRange(Beneficiary.Encode());
            result.AddRange(StateRoot.Encode());
            result.AddRange(TransactionsRoot.Encode());
            result.AddRange(ReceiptsRoot.Encode());
            result.AddRange(LogsBloom.Encode());
            result.AddRange(Difficulty.Encode());
            result.AddRange(Number.Encode());
            result.AddRange(GasLimit.Encode());
            result.AddRange(GasUsed.Encode());
            result.AddRange(Timestamp.Encode());
            result.AddRange(ExtraData.Encode());
            result.AddRange(MixHash.Encode());
            result.AddRange(Nonce.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParentHash = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256();
            ParentHash.Decode(byteArray, ref p);
            OmmersHash = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256();
            OmmersHash.Decode(byteArray, ref p);
            Beneficiary = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160();
            Beneficiary.Decode(byteArray, ref p);
            StateRoot = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256();
            StateRoot.Decode(byteArray, ref p);
            TransactionsRoot = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256();
            TransactionsRoot.Decode(byteArray, ref p);
            ReceiptsRoot = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256();
            ReceiptsRoot.Decode(byteArray, ref p);
            LogsBloom = new BifrostPolkadot.NetApi.Generated.Model.ethbloom.Bloom();
            LogsBloom.Decode(byteArray, ref p);
            Difficulty = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256();
            Difficulty.Decode(byteArray, ref p);
            Number = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256();
            Number.Decode(byteArray, ref p);
            GasLimit = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256();
            GasLimit.Decode(byteArray, ref p);
            GasUsed = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.U256();
            GasUsed.Decode(byteArray, ref p);
            Timestamp = new Substrate.NetApi.Model.Types.Primitive.U64();
            Timestamp.Decode(byteArray, ref p);
            ExtraData = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            ExtraData.Decode(byteArray, ref p);
            MixHash = new BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256();
            MixHash.Decode(byteArray, ref p);
            Nonce = new BifrostPolkadot.NetApi.Generated.Model.ethereum_types.hash.H64();
            Nonce.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
