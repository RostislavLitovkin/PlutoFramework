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


namespace Polkadot.NetApi.Generated.Model.pallet_grandpa
{
    
    
    /// <summary>
    /// >> 615 - Composite[pallet_grandpa.StoredPendingChange]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class StoredPendingChange : BaseType
    {
        
        /// <summary>
        /// >> scheduled_at
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ScheduledAt { get; set; }
        /// <summary>
        /// >> delay
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Delay { get; set; }
        /// <summary>
        /// >> next_authorities
        /// </summary>
        public Polkadot.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3 NextAuthorities { get; set; }
        /// <summary>
        /// >> forced
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32> Forced { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "StoredPendingChange";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ScheduledAt.Encode());
            result.AddRange(Delay.Encode());
            result.AddRange(NextAuthorities.Encode());
            result.AddRange(Forced.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ScheduledAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            ScheduledAt.Decode(byteArray, ref p);
            Delay = new Substrate.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);
            NextAuthorities = new Polkadot.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3();
            NextAuthorities.Decode(byteArray, ref p);
            Forced = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            Forced.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
