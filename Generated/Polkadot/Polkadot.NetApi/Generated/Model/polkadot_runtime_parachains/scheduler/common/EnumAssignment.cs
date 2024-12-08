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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.scheduler.common
{
    
    
    /// <summary>
    /// >> Assignment
    /// </summary>
    public enum Assignment
    {
        
        /// <summary>
        /// >> Pool
        /// </summary>
        Pool = 0,
        
        /// <summary>
        /// >> Bulk
        /// </summary>
        Bulk = 1,
    }
    
    /// <summary>
    /// >> 727 - Variant[polkadot_runtime_parachains.scheduler.common.Assignment]
    /// </summary>
    public sealed class EnumAssignment : BaseEnumRust<Assignment>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAssignment()
        {
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Polkadot.NetApi.Generated.Model.polkadot_primitives.v7.CoreIndex>>(Assignment.Pool);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>(Assignment.Bulk);
        }
    }
}
