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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_community_loan_pool
{
    
    
    /// <summary>
    /// >> 347 - Composite[pallet_community_loan_pool.ProposedMilestone]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ProposedMilestone : BaseType
    {
        
        /// <summary>
        /// >> percentage_to_unlock
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.sp_arithmetic.per_things.Percent PercentageToUnlock { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ProposedMilestone";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PercentageToUnlock.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PercentageToUnlock = new XcavatePaseo.NetApi.Generated.Model.sp_arithmetic.per_things.Percent();
            PercentageToUnlock.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
