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


namespace Kilt.NetApi.Generated.Model.pallet_asset_switch.@switch
{
    
    
    /// <summary>
    /// >> 506 - Composite[pallet_asset_switch.switch.SwitchPairInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SwitchPairInfo : BaseType
    {
        
        /// <summary>
        /// >> pool_account
        /// </summary>
        public Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32 PoolAccount { get; set; }
        /// <summary>
        /// >> remote_asset_circulating_supply
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 RemoteAssetCirculatingSupply { get; set; }
        /// <summary>
        /// >> remote_asset_ed
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 RemoteAssetEd { get; set; }
        /// <summary>
        /// >> remote_asset_id
        /// </summary>
        public Kilt.NetApi.Generated.Model.xcm.EnumVersionedAssetId RemoteAssetId { get; set; }
        /// <summary>
        /// >> remote_asset_total_supply
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 RemoteAssetTotalSupply { get; set; }
        /// <summary>
        /// >> remote_reserve_location
        /// </summary>
        public Kilt.NetApi.Generated.Model.xcm.EnumVersionedLocation RemoteReserveLocation { get; set; }
        /// <summary>
        /// >> remote_xcm_fee
        /// </summary>
        public Kilt.NetApi.Generated.Model.xcm.EnumVersionedAsset RemoteXcmFee { get; set; }
        /// <summary>
        /// >> status
        /// </summary>
        public Kilt.NetApi.Generated.Model.pallet_asset_switch.@switch.EnumSwitchPairStatus Status { get; set; }
        /// <summary>
        /// >> remote_asset_sovereign_total_balance
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 RemoteAssetSovereignTotalBalance { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "SwitchPairInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PoolAccount.Encode());
            result.AddRange(RemoteAssetCirculatingSupply.Encode());
            result.AddRange(RemoteAssetEd.Encode());
            result.AddRange(RemoteAssetId.Encode());
            result.AddRange(RemoteAssetTotalSupply.Encode());
            result.AddRange(RemoteReserveLocation.Encode());
            result.AddRange(RemoteXcmFee.Encode());
            result.AddRange(Status.Encode());
            result.AddRange(RemoteAssetSovereignTotalBalance.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PoolAccount = new Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            PoolAccount.Decode(byteArray, ref p);
            RemoteAssetCirculatingSupply = new Substrate.NetApi.Model.Types.Primitive.U128();
            RemoteAssetCirculatingSupply.Decode(byteArray, ref p);
            RemoteAssetEd = new Substrate.NetApi.Model.Types.Primitive.U128();
            RemoteAssetEd.Decode(byteArray, ref p);
            RemoteAssetId = new Kilt.NetApi.Generated.Model.xcm.EnumVersionedAssetId();
            RemoteAssetId.Decode(byteArray, ref p);
            RemoteAssetTotalSupply = new Substrate.NetApi.Model.Types.Primitive.U128();
            RemoteAssetTotalSupply.Decode(byteArray, ref p);
            RemoteReserveLocation = new Kilt.NetApi.Generated.Model.xcm.EnumVersionedLocation();
            RemoteReserveLocation.Decode(byteArray, ref p);
            RemoteXcmFee = new Kilt.NetApi.Generated.Model.xcm.EnumVersionedAsset();
            RemoteXcmFee.Decode(byteArray, ref p);
            Status = new Kilt.NetApi.Generated.Model.pallet_asset_switch.@switch.EnumSwitchPairStatus();
            Status.Decode(byteArray, ref p);
            RemoteAssetSovereignTotalBalance = new Substrate.NetApi.Model.Types.Primitive.U128();
            RemoteAssetSovereignTotalBalance.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
