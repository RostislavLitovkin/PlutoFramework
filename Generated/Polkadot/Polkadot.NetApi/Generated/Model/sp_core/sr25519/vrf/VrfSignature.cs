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


namespace Polkadot.NetApi.Generated.Model.sp_core.sr25519.vrf
{
    
    
    /// <summary>
    /// >> 536 - Composite[sp_core.sr25519.vrf.VrfSignature]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class VrfSignature : BaseType
    {
        
        /// <summary>
        /// >> pre_output
        /// </summary>
        public Polkadot.NetApi.Generated.Types.Base.Arr32U8 PreOutput { get; set; }
        /// <summary>
        /// >> proof
        /// </summary>
        public Polkadot.NetApi.Generated.Types.Base.Arr64U8 Proof { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "VrfSignature";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PreOutput.Encode());
            result.AddRange(Proof.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PreOutput = new Polkadot.NetApi.Generated.Types.Base.Arr32U8();
            PreOutput.Decode(byteArray, ref p);
            Proof = new Polkadot.NetApi.Generated.Types.Base.Arr64U8();
            Proof.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
