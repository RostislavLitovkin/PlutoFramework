//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4
{
    
    
    /// <summary>
    /// >> Instruction
    /// </summary>
    public enum Instruction
    {
        
        /// <summary>
        /// >> WithdrawAsset
        /// </summary>
        WithdrawAsset = 0,
        
        /// <summary>
        /// >> ReserveAssetDeposited
        /// </summary>
        ReserveAssetDeposited = 1,
        
        /// <summary>
        /// >> ReceiveTeleportedAsset
        /// </summary>
        ReceiveTeleportedAsset = 2,
        
        /// <summary>
        /// >> QueryResponse
        /// </summary>
        QueryResponse = 3,
        
        /// <summary>
        /// >> TransferAsset
        /// </summary>
        TransferAsset = 4,
        
        /// <summary>
        /// >> TransferReserveAsset
        /// </summary>
        TransferReserveAsset = 5,
        
        /// <summary>
        /// >> Transact
        /// </summary>
        Transact = 6,
        
        /// <summary>
        /// >> HrmpNewChannelOpenRequest
        /// </summary>
        HrmpNewChannelOpenRequest = 7,
        
        /// <summary>
        /// >> HrmpChannelAccepted
        /// </summary>
        HrmpChannelAccepted = 8,
        
        /// <summary>
        /// >> HrmpChannelClosing
        /// </summary>
        HrmpChannelClosing = 9,
        
        /// <summary>
        /// >> ClearOrigin
        /// </summary>
        ClearOrigin = 10,
        
        /// <summary>
        /// >> DescendOrigin
        /// </summary>
        DescendOrigin = 11,
        
        /// <summary>
        /// >> ReportError
        /// </summary>
        ReportError = 12,
        
        /// <summary>
        /// >> DepositAsset
        /// </summary>
        DepositAsset = 13,
        
        /// <summary>
        /// >> DepositReserveAsset
        /// </summary>
        DepositReserveAsset = 14,
        
        /// <summary>
        /// >> ExchangeAsset
        /// </summary>
        ExchangeAsset = 15,
        
        /// <summary>
        /// >> InitiateReserveWithdraw
        /// </summary>
        InitiateReserveWithdraw = 16,
        
        /// <summary>
        /// >> InitiateTeleport
        /// </summary>
        InitiateTeleport = 17,
        
        /// <summary>
        /// >> ReportHolding
        /// </summary>
        ReportHolding = 18,
        
        /// <summary>
        /// >> BuyExecution
        /// </summary>
        BuyExecution = 19,
        
        /// <summary>
        /// >> RefundSurplus
        /// </summary>
        RefundSurplus = 20,
        
        /// <summary>
        /// >> SetErrorHandler
        /// </summary>
        SetErrorHandler = 21,
        
        /// <summary>
        /// >> SetAppendix
        /// </summary>
        SetAppendix = 22,
        
        /// <summary>
        /// >> ClearError
        /// </summary>
        ClearError = 23,
        
        /// <summary>
        /// >> ClaimAsset
        /// </summary>
        ClaimAsset = 24,
        
        /// <summary>
        /// >> Trap
        /// </summary>
        Trap = 25,
        
        /// <summary>
        /// >> SubscribeVersion
        /// </summary>
        SubscribeVersion = 26,
        
        /// <summary>
        /// >> UnsubscribeVersion
        /// </summary>
        UnsubscribeVersion = 27,
        
        /// <summary>
        /// >> BurnAsset
        /// </summary>
        BurnAsset = 28,
        
        /// <summary>
        /// >> ExpectAsset
        /// </summary>
        ExpectAsset = 29,
        
        /// <summary>
        /// >> ExpectOrigin
        /// </summary>
        ExpectOrigin = 30,
        
        /// <summary>
        /// >> ExpectError
        /// </summary>
        ExpectError = 31,
        
        /// <summary>
        /// >> ExpectTransactStatus
        /// </summary>
        ExpectTransactStatus = 32,
        
        /// <summary>
        /// >> QueryPallet
        /// </summary>
        QueryPallet = 33,
        
        /// <summary>
        /// >> ExpectPallet
        /// </summary>
        ExpectPallet = 34,
        
        /// <summary>
        /// >> ReportTransactStatus
        /// </summary>
        ReportTransactStatus = 35,
        
        /// <summary>
        /// >> ClearTransactStatus
        /// </summary>
        ClearTransactStatus = 36,
        
        /// <summary>
        /// >> UniversalOrigin
        /// </summary>
        UniversalOrigin = 37,
        
        /// <summary>
        /// >> ExportMessage
        /// </summary>
        ExportMessage = 38,
        
        /// <summary>
        /// >> LockAsset
        /// </summary>
        LockAsset = 39,
        
        /// <summary>
        /// >> UnlockAsset
        /// </summary>
        UnlockAsset = 40,
        
        /// <summary>
        /// >> NoteUnlockable
        /// </summary>
        NoteUnlockable = 41,
        
        /// <summary>
        /// >> RequestUnlock
        /// </summary>
        RequestUnlock = 42,
        
        /// <summary>
        /// >> SetFeesMode
        /// </summary>
        SetFeesMode = 43,
        
        /// <summary>
        /// >> SetTopic
        /// </summary>
        SetTopic = 44,
        
        /// <summary>
        /// >> ClearTopic
        /// </summary>
        ClearTopic = 45,
        
        /// <summary>
        /// >> AliasOrigin
        /// </summary>
        AliasOrigin = 46,
        
        /// <summary>
        /// >> UnpaidExecution
        /// </summary>
        UnpaidExecution = 47,
    }
    
    /// <summary>
    /// >> 335 - Variant[staging_xcm.v4.Instruction]
    /// </summary>
    public sealed class EnumInstruction : BaseEnumRust<Instruction>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumInstruction()
        {
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(Instruction.WithdrawAsset);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(Instruction.ReserveAssetDeposited);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(Instruction.ReceiveTeleportedAsset);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.EnumResponse, KusamaAssetHub.NetApi.Generated.Model.sp_weights.weight_v2.Weight, Substrate.NetApi.Model.Types.Base.BaseOpt<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>>(Instruction.QueryResponse);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.TransferAsset);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.XcmT1>>(Instruction.TransferReserveAsset);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.xcm.v3.EnumOriginKind, KusamaAssetHub.NetApi.Generated.Model.sp_weights.weight_v2.Weight, KusamaAssetHub.NetApi.Generated.Model.xcm.double_encoded.DoubleEncodedT2>>(Instruction.Transact);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpNewChannelOpenRequest);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(Instruction.HrmpChannelAccepted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpChannelClosing);
				AddTypeDecoder<BaseVoid>(Instruction.ClearOrigin);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.junctions.EnumJunctions>(Instruction.DescendOrigin);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.QueryResponseInfo>(Instruction.ReportError);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumAssetFilter, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.DepositAsset);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumAssetFilter, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.XcmT1>>(Instruction.DepositReserveAsset);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumAssetFilter, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets, Substrate.NetApi.Model.Types.Primitive.Bool>>(Instruction.ExchangeAsset);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumAssetFilter, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.XcmT1>>(Instruction.InitiateReserveWithdraw);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumAssetFilter, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.XcmT1>>(Instruction.InitiateTeleport);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.QueryResponseInfo, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumAssetFilter>>(Instruction.ReportHolding);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Asset, KusamaAssetHub.NetApi.Generated.Model.xcm.v3.EnumWeightLimit>>(Instruction.BuyExecution);
				AddTypeDecoder<BaseVoid>(Instruction.RefundSurplus);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.XcmT2>(Instruction.SetErrorHandler);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.XcmT2>(Instruction.SetAppendix);
				AddTypeDecoder<BaseVoid>(Instruction.ClearError);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.ClaimAsset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>(Instruction.Trap);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, KusamaAssetHub.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Instruction.SubscribeVersion);
				AddTypeDecoder<BaseVoid>(Instruction.UnsubscribeVersion);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(Instruction.BurnAsset);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(Instruction.ExpectAsset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.ExpectOrigin);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, KusamaAssetHub.NetApi.Generated.Model.xcm.v3.traits.EnumError>>>(Instruction.ExpectError);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.xcm.v3.EnumMaybeErrorCode>(Instruction.ExpectTransactStatus);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.QueryResponseInfo>>(Instruction.QueryPallet);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.ExpectPallet);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.QueryResponseInfo>(Instruction.ReportTransactStatus);
				AddTypeDecoder<BaseVoid>(Instruction.ClearTransactStatus);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumJunction>(Instruction.UniversalOrigin);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.EnumNetworkId, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.junctions.EnumJunctions, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.XcmT1>>(Instruction.ExportMessage);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Asset, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.LockAsset);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Asset, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.UnlockAsset);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Asset, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.NoteUnlockable);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.Asset, KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Instruction.RequestUnlock);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.Bool>(Instruction.SetFeesMode);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Types.Base.Arr32U8>(Instruction.SetTopic);
				AddTypeDecoder<BaseVoid>(Instruction.ClearTopic);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Instruction.AliasOrigin);
				AddTypeDecoder<BaseTuple<KusamaAssetHub.NetApi.Generated.Model.xcm.v3.EnumWeightLimit, Substrate.NetApi.Model.Types.Base.BaseOpt<KusamaAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>>(Instruction.UnpaidExecution);
        }
    }
}
