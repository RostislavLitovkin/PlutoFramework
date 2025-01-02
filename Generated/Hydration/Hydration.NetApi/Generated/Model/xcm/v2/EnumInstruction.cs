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


namespace Hydration.NetApi.Generated.Model.xcm.v2
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
        /// >> QueryHolding
        /// </summary>
        QueryHolding = 18,
        
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
    }
    
    /// <summary>
    /// >> 454 - Variant[xcm.v2.Instruction]
    /// </summary>
    public sealed class EnumInstruction : BaseEnumRust<Instruction>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumInstruction()
        {
				AddTypeDecoder<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets>(Instruction.WithdrawAsset);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets>(Instruction.ReserveAssetDeposited);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets>(Instruction.ReceiveTeleportedAsset);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Hydration.NetApi.Generated.Model.xcm.v2.EnumResponse, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>>(Instruction.QueryResponse);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation>>(Instruction.TransferAsset);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation, Hydration.NetApi.Generated.Model.xcm.v2.XcmT1>>(Instruction.TransferReserveAsset);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.EnumOriginKind, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Hydration.NetApi.Generated.Model.xcm.double_encoded.DoubleEncodedT2>>(Instruction.Transact);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpNewChannelOpenRequest);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(Instruction.HrmpChannelAccepted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(Instruction.HrmpChannelClosing);
				AddTypeDecoder<BaseVoid>(Instruction.ClearOrigin);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.xcm.v2.multilocation.EnumJunctions>(Instruction.DescendOrigin);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>>(Instruction.ReportError);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.EnumMultiAssetFilter, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation>>(Instruction.DepositAsset);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.EnumMultiAssetFilter, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation, Hydration.NetApi.Generated.Model.xcm.v2.XcmT1>>(Instruction.DepositReserveAsset);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.EnumMultiAssetFilter, Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets>>(Instruction.ExchangeAsset);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.EnumMultiAssetFilter, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation, Hydration.NetApi.Generated.Model.xcm.v2.XcmT1>>(Instruction.InitiateReserveWithdraw);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.EnumMultiAssetFilter, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation, Hydration.NetApi.Generated.Model.xcm.v2.XcmT1>>(Instruction.InitiateTeleport);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation, Hydration.NetApi.Generated.Model.xcm.v2.multiasset.EnumMultiAssetFilter, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>>(Instruction.QueryHolding);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAsset, Hydration.NetApi.Generated.Model.xcm.v2.EnumWeightLimit>>(Instruction.BuyExecution);
				AddTypeDecoder<BaseVoid>(Instruction.RefundSurplus);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.xcm.v2.XcmT2>(Instruction.SetErrorHandler);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.xcm.v2.XcmT2>(Instruction.SetAppendix);
				AddTypeDecoder<BaseVoid>(Instruction.ClearError);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets, Hydration.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation>>(Instruction.ClaimAsset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>(Instruction.Trap);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U64>>>(Instruction.SubscribeVersion);
				AddTypeDecoder<BaseVoid>(Instruction.UnsubscribeVersion);
        }
    }
}
