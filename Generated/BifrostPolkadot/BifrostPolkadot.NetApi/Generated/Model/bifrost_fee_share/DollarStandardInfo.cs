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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_fee_share
{
    
    
    /// <summary>
    /// >> 595 - Composite[bifrost_fee_share.DollarStandardInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DollarStandardInfo : BaseType
    {
        
        /// <summary>
        /// >> target_value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TargetValue { get; set; }
        /// <summary>
        /// >> cumulative
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Cumulative { get; set; }
        /// <summary>
        /// >> target_account_id
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32 TargetAccountId { get; set; }
        /// <summary>
        /// >> target_block
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TargetBlock { get; set; }
        /// <summary>
        /// >> interval
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Interval { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "DollarStandardInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TargetValue.Encode());
            result.AddRange(Cumulative.Encode());
            result.AddRange(TargetAccountId.Encode());
            result.AddRange(TargetBlock.Encode());
            result.AddRange(Interval.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TargetValue = new Substrate.NetApi.Model.Types.Primitive.U128();
            TargetValue.Decode(byteArray, ref p);
            Cumulative = new Substrate.NetApi.Model.Types.Primitive.U128();
            Cumulative.Decode(byteArray, ref p);
            TargetAccountId = new BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            TargetAccountId.Decode(byteArray, ref p);
            TargetBlock = new Substrate.NetApi.Model.Types.Primitive.U32();
            TargetBlock.Decode(byteArray, ref p);
            Interval = new Substrate.NetApi.Model.Types.Primitive.U32();
            Interval.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
