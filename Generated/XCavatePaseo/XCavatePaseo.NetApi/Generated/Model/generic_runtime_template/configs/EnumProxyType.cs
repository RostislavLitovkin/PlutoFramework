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


namespace XCavatePaseo.NetApi.Generated.Model.generic_runtime_template.configs
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
        /// >> Collator
        /// </summary>
        Collator = 3,
    }
    
    /// <summary>
    /// >> 36 - Variant[generic_runtime_template.configs.ProxyType]
    /// </summary>
    public sealed class EnumProxyType : BaseEnum<ProxyType>
    {
    }
}
