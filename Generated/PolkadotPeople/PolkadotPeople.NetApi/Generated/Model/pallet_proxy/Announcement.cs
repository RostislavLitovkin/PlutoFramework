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


namespace PolkadotPeople.NetApi.Generated.Model.pallet_proxy
{
    
    
    /// <summary>
    /// >> 410 - Composite[pallet_proxy.Announcement]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Announcement : BaseType
    {
        
        /// <summary>
        /// >> real
        /// </summary>
        public PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32 Real { get; set; }
        /// <summary>
        /// >> call_hash
        /// </summary>
        public PolkadotPeople.NetApi.Generated.Model.primitive_types.H256 CallHash { get; set; }
        /// <summary>
        /// >> height
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Height { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Announcement";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Real.Encode());
            result.AddRange(CallHash.Encode());
            result.AddRange(Height.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Real = new PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Real.Decode(byteArray, ref p);
            CallHash = new PolkadotPeople.NetApi.Generated.Model.primitive_types.H256();
            CallHash.Decode(byteArray, ref p);
            Height = new Substrate.NetApi.Model.Types.Primitive.U32();
            Height.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
