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


namespace InvArch.NetApi.Generated.Model.xcm.v3
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
    /// >> 251 - Variant[xcm.v3.Instruction]
    /// </summary>
    public sealed class EnumInstruction : BaseEnumRust<Instruction>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumInstruction()
        {
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets>(Instruction.WithdrawAsset);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets>(Instruction.ReserveAssetDeposited);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets>(Instruction.ReceiveTeleportedAsset);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, InvArch.NetApi.Generated.Model.xcm.v3.EnumResponse, InvArch.NetApi.Generated.Model.sp_weights.weight_v2.Weight, Substrate.NetApi.Model.Types.Base.BaseOpt<InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>>(Instruction.QueryResponse);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.TransferAsset);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation, InvArch.NetApi.Generated.Model.xcm.v3.XcmT1>>(Instruction.TransferReserveAsset);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.EnumOriginKind, InvArch.NetApi.Generated.Model.sp_weights.weight_v2.Weight, InvArch.NetApi.Generated.Model.xcm.double_encoded.DoubleEncodedT2>>(Instruction.Transact);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpNewChannelOpenRequest);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(Instruction.HrmpChannelAccepted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpChannelClosing);
				AddTypeDecoder<BaseVoid>(Instruction.ClearOrigin);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.junctions.EnumJunctions>(Instruction.DescendOrigin);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.QueryResponseInfo>(Instruction.ReportError);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.EnumMultiAssetFilter, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.DepositAsset);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.EnumMultiAssetFilter, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation, InvArch.NetApi.Generated.Model.xcm.v3.XcmT1>>(Instruction.DepositReserveAsset);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.EnumMultiAssetFilter, InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets, Substrate.NetApi.Model.Types.Primitive.Bool>>(Instruction.ExchangeAsset);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.EnumMultiAssetFilter, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation, InvArch.NetApi.Generated.Model.xcm.v3.XcmT1>>(Instruction.InitiateReserveWithdraw);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.EnumMultiAssetFilter, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation, InvArch.NetApi.Generated.Model.xcm.v3.XcmT1>>(Instruction.InitiateTeleport);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.QueryResponseInfo, InvArch.NetApi.Generated.Model.xcm.v3.multiasset.EnumMultiAssetFilter>>(Instruction.ReportHolding);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset, InvArch.NetApi.Generated.Model.xcm.v3.EnumWeightLimit>>(Instruction.BuyExecution);
				AddTypeDecoder<BaseVoid>(Instruction.RefundSurplus);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.XcmT2>(Instruction.SetErrorHandler);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.XcmT2>(Instruction.SetAppendix);
				AddTypeDecoder<BaseVoid>(Instruction.ClearError);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.ClaimAsset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>(Instruction.Trap);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, InvArch.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Instruction.SubscribeVersion);
				AddTypeDecoder<BaseVoid>(Instruction.UnsubscribeVersion);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets>(Instruction.BurnAsset);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets>(Instruction.ExpectAsset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.ExpectOrigin);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, InvArch.NetApi.Generated.Model.xcm.v3.traits.EnumError>>>(Instruction.ExpectError);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.EnumMaybeErrorCode>(Instruction.ExpectTransactStatus);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, InvArch.NetApi.Generated.Model.xcm.v3.QueryResponseInfo>>(Instruction.QueryPallet);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.ExpectPallet);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.QueryResponseInfo>(Instruction.ReportTransactStatus);
				AddTypeDecoder<BaseVoid>(Instruction.ClearTransactStatus);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.junction.EnumJunction>(Instruction.UniversalOrigin);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.junction.EnumNetworkId, InvArch.NetApi.Generated.Model.xcm.v3.junctions.EnumJunctions, InvArch.NetApi.Generated.Model.xcm.v3.XcmT1>>(Instruction.ExportMessage);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.LockAsset);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.UnlockAsset);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.NoteUnlockable);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset, InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Instruction.RequestUnlock);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.Bool>(Instruction.SetFeesMode);
				AddTypeDecoder<InvArch.NetApi.Generated.Types.Base.Arr32U8>(Instruction.SetTopic);
				AddTypeDecoder<BaseVoid>(Instruction.ClearTopic);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>(Instruction.AliasOrigin);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.v3.EnumWeightLimit, Substrate.NetApi.Model.Types.Base.BaseOpt<InvArch.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>>(Instruction.UnpaidExecution);
        }
    }
}
