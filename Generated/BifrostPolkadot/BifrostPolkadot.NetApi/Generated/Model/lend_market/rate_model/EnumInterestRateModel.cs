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


namespace BifrostPolkadot.NetApi.Generated.Model.lend_market.rate_model
{
    
    
    /// <summary>
    /// >> InterestRateModel
    /// </summary>
    public enum InterestRateModel
    {
        
        /// <summary>
        /// >> Jump
        /// </summary>
        Jump = 0,
        
        /// <summary>
        /// >> Curve
        /// </summary>
        Curve = 1,
    }
    
    /// <summary>
    /// >> 485 - Variant[lend_market.rate_model.InterestRateModel]
    /// </summary>
    public sealed class EnumInterestRateModel : BaseEnumRust<InterestRateModel>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumInterestRateModel()
        {
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.lend_market.rate_model.JumpModel>(InterestRateModel.Jump);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.lend_market.rate_model.CurveModel>(InterestRateModel.Curve);
        }
    }
}
