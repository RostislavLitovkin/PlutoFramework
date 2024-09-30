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


namespace KusamaAssetHub.NetApi.Generated.Model.asset_hub_kusama_runtime
{
    
    
    /// <summary>
    /// >> ProxyType
    /// </summary>
    public enum ProxyType
    {
        
        /// <summary>
        /// >> Any
        /// </summary>
        Any = 0,
        
        /// <summary>
        /// >> NonTransfer
        /// </summary>
        NonTransfer = 1,
        
        /// <summary>
        /// >> CancelProxy
        /// </summary>
        CancelProxy = 2,
        
        /// <summary>
        /// >> Assets
        /// </summary>
        Assets = 3,
        
        /// <summary>
        /// >> AssetOwner
        /// </summary>
        AssetOwner = 4,
        
        /// <summary>
        /// >> AssetManager
        /// </summary>
        AssetManager = 5,
        
        /// <summary>
        /// >> Collator
        /// </summary>
        Collator = 6,
    }
    
    /// <summary>
    /// >> 128 - Variant[asset_hub_kusama_runtime.ProxyType]
    /// </summary>
    public sealed class EnumProxyType : BaseEnum<ProxyType>
    {
    }
}
