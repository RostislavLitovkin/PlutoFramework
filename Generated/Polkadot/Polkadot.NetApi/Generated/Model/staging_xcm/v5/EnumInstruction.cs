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


namespace Polkadot.NetApi.Generated.Model.staging_xcm.v5
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
        
        /// <summary>
        /// >> PayFees
        /// </summary>
        PayFees = 48,
        
        /// <summary>
        /// >> InitiateTransfer
        /// </summary>
        InitiateTransfer = 49,
        
        /// <summary>
        /// >> ExecuteWithOrigin
        /// </summary>
        ExecuteWithOrigin = 50,
        
        /// <summary>
        /// >> SetHints
        /// </summary>
        SetHints = 51,
    }
    
    /// <summary>
    /// >> 437 - Variant[staging_xcm.v5.Instruction]
    /// </summary>
    public sealed class EnumInstruction : BaseEnumRust<Instruction>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumInstruction()
        {
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets>(Instruction.WithdrawAsset);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets>(Instruction.ReserveAssetDeposited);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets>(Instruction.ReceiveTeleportedAsset);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Polkadot.NetApi.Generated.Model.staging_xcm.v5.EnumResponse, Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>>(Instruction.QueryResponse);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.TransferAsset);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location, Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT1>>(Instruction.TransferReserveAsset);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.xcm.v3.EnumOriginKind, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight>, Polkadot.NetApi.Generated.Model.xcm.double_encoded.DoubleEncodedT2>>(Instruction.Transact);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpNewChannelOpenRequest);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(Instruction.HrmpChannelAccepted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpChannelClosing);
				AddTypeDecoder<BaseVoid>(Instruction.ClearOrigin);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.junctions.EnumJunctions>(Instruction.DescendOrigin);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.QueryResponseInfo>(Instruction.ReportError);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.EnumAssetFilter, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.DepositAsset);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.EnumAssetFilter, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location, Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT1>>(Instruction.DepositReserveAsset);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.EnumAssetFilter, Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets, Substrate.NetApi.Model.Types.Primitive.Bool>>(Instruction.ExchangeAsset);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.EnumAssetFilter, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location, Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT1>>(Instruction.InitiateReserveWithdraw);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.EnumAssetFilter, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location, Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT1>>(Instruction.InitiateTeleport);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.QueryResponseInfo, Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.EnumAssetFilter>>(Instruction.ReportHolding);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Asset, Polkadot.NetApi.Generated.Model.xcm.v3.EnumWeightLimit>>(Instruction.BuyExecution);
				AddTypeDecoder<BaseVoid>(Instruction.RefundSurplus);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT2>(Instruction.SetErrorHandler);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT2>(Instruction.SetAppendix);
				AddTypeDecoder<BaseVoid>(Instruction.ClearError);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.ClaimAsset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>(Instruction.Trap);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Instruction.SubscribeVersion);
				AddTypeDecoder<BaseVoid>(Instruction.UnsubscribeVersion);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets>(Instruction.BurnAsset);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Assets>(Instruction.ExpectAsset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.ExpectOrigin);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkadot.NetApi.Generated.Model.xcm.v5.traits.EnumError>>>(Instruction.ExpectError);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.xcm.v3.EnumMaybeErrorCode>(Instruction.ExpectTransactStatus);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Polkadot.NetApi.Generated.Model.staging_xcm.v5.QueryResponseInfo>>(Instruction.QueryPallet);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.ExpectPallet);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.QueryResponseInfo>(Instruction.ReportTransactStatus);
				AddTypeDecoder<BaseVoid>(Instruction.ClearTransactStatus);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.junction.EnumJunction>(Instruction.UniversalOrigin);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.junction.EnumNetworkId, Polkadot.NetApi.Generated.Model.staging_xcm.v5.junctions.EnumJunctions, Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT1>>(Instruction.ExportMessage);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Asset, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.LockAsset);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Asset, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.UnlockAsset);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Asset, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.NoteUnlockable);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Asset, Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Instruction.RequestUnlock);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.Bool>(Instruction.SetFeesMode);
				AddTypeDecoder<Polkadot.NetApi.Generated.Types.Base.Arr32U8>(Instruction.SetTopic);
				AddTypeDecoder<BaseVoid>(Instruction.ClearTopic);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>(Instruction.AliasOrigin);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.xcm.v3.EnumWeightLimit, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location>>>(Instruction.UnpaidExecution);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.Asset>(Instruction.PayFees);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.staging_xcm.v5.location.Location, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.staging_xcm.v5.asset.EnumAssetTransferFilter>, Substrate.NetApi.Model.Types.Primitive.Bool, Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT13, Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT1>>(Instruction.InitiateTransfer);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.staging_xcm.v5.junctions.EnumJunctions>, Polkadot.NetApi.Generated.Model.staging_xcm.v5.XcmT2>>(Instruction.ExecuteWithOrigin);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT14>(Instruction.SetHints);
        }
    }
}
