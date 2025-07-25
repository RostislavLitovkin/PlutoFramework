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


namespace Hydration.NetApi.Generated.Model.pallet_broadcast.types
{
    
    
    /// <summary>
    /// >> ExecutionType
    /// </summary>
    public enum ExecutionType
    {
        
        /// <summary>
        /// >> Router
        /// </summary>
        Router = 0,
        
        /// <summary>
        /// >> DCA
        /// </summary>
        DCA = 1,
        
        /// <summary>
        /// >> Batch
        /// </summary>
        Batch = 2,
        
        /// <summary>
        /// >> Omnipool
        /// </summary>
        Omnipool = 3,
        
        /// <summary>
        /// >> XcmExchange
        /// </summary>
        XcmExchange = 4,
        
        /// <summary>
        /// >> Xcm
        /// </summary>
        Xcm = 5,
    }
    
    /// <summary>
    /// >> 492 - Variant[pallet_broadcast.types.ExecutionType]
    /// </summary>
    public sealed class EnumExecutionType : BaseEnumRust<ExecutionType>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumExecutionType()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(ExecutionType.Router);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(ExecutionType.DCA);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(ExecutionType.Batch);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(ExecutionType.Omnipool);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(ExecutionType.XcmExchange);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Types.Base.Arr32U8, Substrate.NetApi.Model.Types.Primitive.U32>>(ExecutionType.Xcm);
        }
    }
}
