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


namespace KusamaAssetHub.NetApi.Generated.Model.xcm.v3
{
    
    
    /// <summary>
    /// >> WeightLimit
    /// </summary>
    public enum WeightLimit
    {
        
        /// <summary>
        /// >> Unlimited
        /// </summary>
        Unlimited = 0,
        
        /// <summary>
        /// >> Limited
        /// </summary>
        Limited = 1,
    }
    
    /// <summary>
    /// >> 95 - Variant[xcm.v3.WeightLimit]
    /// </summary>
    public sealed class EnumWeightLimit : BaseEnumRust<WeightLimit>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumWeightLimit()
        {
				AddTypeDecoder<BaseVoid>(WeightLimit.Unlimited);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.sp_weights.weight_v2.Weight>(WeightLimit.Limited);
        }
    }
}
