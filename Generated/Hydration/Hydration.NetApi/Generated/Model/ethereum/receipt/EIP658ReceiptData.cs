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


namespace Hydration.NetApi.Generated.Model.ethereum.receipt
{
    
    
    /// <summary>
    /// >> 643 - Composite[ethereum.receipt.EIP658ReceiptData]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EIP658ReceiptData : BaseType
    {
        
        /// <summary>
        /// >> status_code
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U8 StatusCode { get; set; }
        /// <summary>
        /// >> used_gas
        /// </summary>
        public Hydration.NetApi.Generated.Model.primitive_types.U256 UsedGas { get; set; }
        /// <summary>
        /// >> logs_bloom
        /// </summary>
        public Hydration.NetApi.Generated.Model.ethbloom.Bloom LogsBloom { get; set; }
        /// <summary>
        /// >> logs
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.ethereum.log.Log> Logs { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "EIP658ReceiptData";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(StatusCode.Encode());
            result.AddRange(UsedGas.Encode());
            result.AddRange(LogsBloom.Encode());
            result.AddRange(Logs.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            StatusCode = new Substrate.NetApi.Model.Types.Primitive.U8();
            StatusCode.Decode(byteArray, ref p);
            UsedGas = new Hydration.NetApi.Generated.Model.primitive_types.U256();
            UsedGas.Decode(byteArray, ref p);
            LogsBloom = new Hydration.NetApi.Generated.Model.ethbloom.Bloom();
            LogsBloom.Decode(byteArray, ref p);
            Logs = new Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.ethereum.log.Log>();
            Logs.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
