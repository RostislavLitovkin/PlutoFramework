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


namespace Polkadot.NetApi.Generated.Model.pallet_broker.coretime_interface
{
    
    
    /// <summary>
    /// >> CoreAssignment
    /// </summary>
    public enum CoreAssignment
    {
        
        /// <summary>
        /// >> Idle
        /// </summary>
        Idle = 0,
        
        /// <summary>
        /// >> Pool
        /// </summary>
        Pool = 1,
        
        /// <summary>
        /// >> Task
        /// </summary>
        Task = 2,
    }
    
    /// <summary>
    /// >> 341 - Variant[pallet_broker.coretime_interface.CoreAssignment]
    /// </summary>
    public sealed class EnumCoreAssignment : BaseEnumRust<CoreAssignment>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCoreAssignment()
        {
				AddTypeDecoder<BaseVoid>(CoreAssignment.Idle);
				AddTypeDecoder<BaseVoid>(CoreAssignment.Pool);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(CoreAssignment.Task);
        }
    }
}
