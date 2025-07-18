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


namespace BifrostPolkadot.NetApi.Generated.Model.ismp.router
{
    
    
    /// <summary>
    /// >> 336 - Composite[ismp.router.GetRequest]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class GetRequest : BaseType
    {
        
        /// <summary>
        /// >> source
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.ismp.host.EnumStateMachine Source { get; set; }
        /// <summary>
        /// >> dest
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.ismp.host.EnumStateMachine Dest { get; set; }
        /// <summary>
        /// >> nonce
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Nonce { get; set; }
        /// <summary>
        /// >> from
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> From { get; set; }
        /// <summary>
        /// >> keys
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> Keys { get; set; }
        /// <summary>
        /// >> height
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Height { get; set; }
        /// <summary>
        /// >> context
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> Context { get; set; }
        /// <summary>
        /// >> timeout_timestamp
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 TimeoutTimestamp { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "GetRequest";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Source.Encode());
            result.AddRange(Dest.Encode());
            result.AddRange(Nonce.Encode());
            result.AddRange(From.Encode());
            result.AddRange(Keys.Encode());
            result.AddRange(Height.Encode());
            result.AddRange(Context.Encode());
            result.AddRange(TimeoutTimestamp.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Source = new BifrostPolkadot.NetApi.Generated.Model.ismp.host.EnumStateMachine();
            Source.Decode(byteArray, ref p);
            Dest = new BifrostPolkadot.NetApi.Generated.Model.ismp.host.EnumStateMachine();
            Dest.Decode(byteArray, ref p);
            Nonce = new Substrate.NetApi.Model.Types.Primitive.U64();
            Nonce.Decode(byteArray, ref p);
            From = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            From.Decode(byteArray, ref p);
            Keys = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>();
            Keys.Decode(byteArray, ref p);
            Height = new Substrate.NetApi.Model.Types.Primitive.U64();
            Height.Decode(byteArray, ref p);
            Context = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Context.Decode(byteArray, ref p);
            TimeoutTimestamp = new Substrate.NetApi.Model.Types.Primitive.U64();
            TimeoutTimestamp.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
