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


namespace InvArch.NetApi.Generated.Model.pallet_dao_manager.multisig
{
    
    
    /// <summary>
    /// >> 514 - Composite[pallet_dao_manager.multisig.MultisigOperation]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class MultisigOperation : BaseType
    {
        
        /// <summary>
        /// >> tally
        /// </summary>
        public InvArch.NetApi.Generated.Model.pallet_dao_manager.voting.Tally Tally { get; set; }
        /// <summary>
        /// >> original_caller
        /// </summary>
        public InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32 OriginalCaller { get; set; }
        /// <summary>
        /// >> actual_call
        /// </summary>
        public InvArch.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT36 ActualCall { get; set; }
        /// <summary>
        /// >> metadata
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<InvArch.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT12> Metadata { get; set; }
        /// <summary>
        /// >> fee_asset
        /// </summary>
        public InvArch.NetApi.Generated.Model.pallet_dao_manager.fee_handling.EnumFeeAsset FeeAsset { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "MultisigOperation";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Tally.Encode());
            result.AddRange(OriginalCaller.Encode());
            result.AddRange(ActualCall.Encode());
            result.AddRange(Metadata.Encode());
            result.AddRange(FeeAsset.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Tally = new InvArch.NetApi.Generated.Model.pallet_dao_manager.voting.Tally();
            Tally.Decode(byteArray, ref p);
            OriginalCaller = new InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            OriginalCaller.Decode(byteArray, ref p);
            ActualCall = new InvArch.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT36();
            ActualCall.Decode(byteArray, ref p);
            Metadata = new Substrate.NetApi.Model.Types.Base.BaseOpt<InvArch.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT12>();
            Metadata.Decode(byteArray, ref p);
            FeeAsset = new InvArch.NetApi.Generated.Model.pallet_dao_manager.fee_handling.EnumFeeAsset();
            FeeAsset.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
