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


namespace BifrostPolkadot.NetApi.Generated.Model.lend_market.types
{
    
    
    /// <summary>
    /// >> 484 - Composite[lend_market.types.Market]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Market : BaseType
    {
        
        /// <summary>
        /// >> collateral_factor
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill CollateralFactor { get; set; }
        /// <summary>
        /// >> liquidation_threshold
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill LiquidationThreshold { get; set; }
        /// <summary>
        /// >> reserve_factor
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill ReserveFactor { get; set; }
        /// <summary>
        /// >> close_factor
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill CloseFactor { get; set; }
        /// <summary>
        /// >> liquidate_incentive
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128 LiquidateIncentive { get; set; }
        /// <summary>
        /// >> liquidate_incentive_reserved_factor
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill LiquidateIncentiveReservedFactor { get; set; }
        /// <summary>
        /// >> rate_model
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.lend_market.rate_model.EnumInterestRateModel RateModel { get; set; }
        /// <summary>
        /// >> state
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.lend_market.types.EnumMarketState State { get; set; }
        /// <summary>
        /// >> supply_cap
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 SupplyCap { get; set; }
        /// <summary>
        /// >> borrow_cap
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 BorrowCap { get; set; }
        /// <summary>
        /// >> lend_token_id
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId LendTokenId { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Market";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(CollateralFactor.Encode());
            result.AddRange(LiquidationThreshold.Encode());
            result.AddRange(ReserveFactor.Encode());
            result.AddRange(CloseFactor.Encode());
            result.AddRange(LiquidateIncentive.Encode());
            result.AddRange(LiquidateIncentiveReservedFactor.Encode());
            result.AddRange(RateModel.Encode());
            result.AddRange(State.Encode());
            result.AddRange(SupplyCap.Encode());
            result.AddRange(BorrowCap.Encode());
            result.AddRange(LendTokenId.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            CollateralFactor = new BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill();
            CollateralFactor.Decode(byteArray, ref p);
            LiquidationThreshold = new BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill();
            LiquidationThreshold.Decode(byteArray, ref p);
            ReserveFactor = new BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill();
            ReserveFactor.Decode(byteArray, ref p);
            CloseFactor = new BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill();
            CloseFactor.Decode(byteArray, ref p);
            LiquidateIncentive = new BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128();
            LiquidateIncentive.Decode(byteArray, ref p);
            LiquidateIncentiveReservedFactor = new BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Permill();
            LiquidateIncentiveReservedFactor.Decode(byteArray, ref p);
            RateModel = new BifrostPolkadot.NetApi.Generated.Model.lend_market.rate_model.EnumInterestRateModel();
            RateModel.Decode(byteArray, ref p);
            State = new BifrostPolkadot.NetApi.Generated.Model.lend_market.types.EnumMarketState();
            State.Decode(byteArray, ref p);
            SupplyCap = new Substrate.NetApi.Model.Types.Primitive.U128();
            SupplyCap.Decode(byteArray, ref p);
            BorrowCap = new Substrate.NetApi.Model.Types.Primitive.U128();
            BorrowCap.Decode(byteArray, ref p);
            LendTokenId = new BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId();
            LendTokenId.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
