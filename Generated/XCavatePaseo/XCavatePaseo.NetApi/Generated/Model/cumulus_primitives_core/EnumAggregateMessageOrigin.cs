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


namespace XCavatePaseo.NetApi.Generated.Model.cumulus_primitives_core
{
    
    
    /// <summary>
    /// >> AggregateMessageOrigin
    /// </summary>
    public enum AggregateMessageOrigin
    {
        
        /// <summary>
        /// >> Here
        /// </summary>
        Here = 0,
        
        /// <summary>
        /// >> Parent
        /// </summary>
        Parent = 1,
        
        /// <summary>
        /// >> Sibling
        /// </summary>
        Sibling = 2,
    }
    
    /// <summary>
    /// >> 134 - Variant[cumulus_primitives_core.AggregateMessageOrigin]
    /// </summary>
    public sealed class EnumAggregateMessageOrigin : BaseEnumRust<AggregateMessageOrigin>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAggregateMessageOrigin()
        {
				AddTypeDecoder<BaseVoid>(AggregateMessageOrigin.Here);
				AddTypeDecoder<BaseVoid>(AggregateMessageOrigin.Parent);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>(AggregateMessageOrigin.Sibling);
        }
    }
}
