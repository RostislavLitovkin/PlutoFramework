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


namespace Polkadot.NetApi.Generated.Model.pallet_referenda.types
{
    
    
    /// <summary>
    /// >> 645 - Composite[pallet_referenda.types.DecidingStatus]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DecidingStatus : BaseType
    {
        
        /// <summary>
        /// >> since
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Since { get; set; }
        /// <summary>
        /// >> confirming
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> Confirming { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "DecidingStatus";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Since.Encode());
            result.AddRange(Confirming.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Since = new Substrate.NetApi.Model.Types.Primitive.U32();
            Since.Decode(byteArray, ref p);
            Confirming = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            Confirming.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
