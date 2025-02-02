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


namespace Kilt.NetApi.Generated.Model.frame_system
{
    
    
    /// <summary>
    /// >> 3 - Composite[frame_system.AccountInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AccountInfo : BaseType
    {
        
        /// <summary>
        /// >> nonce
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Nonce { get; set; }
        /// <summary>
        /// >> consumers
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Consumers { get; set; }
        /// <summary>
        /// >> providers
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Providers { get; set; }
        /// <summary>
        /// >> sufficients
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Sufficients { get; set; }
        /// <summary>
        /// >> data
        /// </summary>
        public Kilt.NetApi.Generated.Model.pallet_balances.types.AccountData Data { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AccountInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Nonce.Encode());
            result.AddRange(Consumers.Encode());
            result.AddRange(Providers.Encode());
            result.AddRange(Sufficients.Encode());
            result.AddRange(Data.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Nonce = new Substrate.NetApi.Model.Types.Primitive.U64();
            Nonce.Decode(byteArray, ref p);
            Consumers = new Substrate.NetApi.Model.Types.Primitive.U32();
            Consumers.Decode(byteArray, ref p);
            Providers = new Substrate.NetApi.Model.Types.Primitive.U32();
            Providers.Decode(byteArray, ref p);
            Sufficients = new Substrate.NetApi.Model.Types.Primitive.U32();
            Sufficients.Decode(byteArray, ref p);
            Data = new Kilt.NetApi.Generated.Model.pallet_balances.types.AccountData();
            Data.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
