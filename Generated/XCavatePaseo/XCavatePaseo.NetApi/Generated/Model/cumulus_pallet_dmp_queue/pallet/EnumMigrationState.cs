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


namespace XCavatePaseo.NetApi.Generated.Model.cumulus_pallet_dmp_queue.pallet
{
    
    
    /// <summary>
    /// >> MigrationState
    /// </summary>
    public enum MigrationState
    {
        
        /// <summary>
        /// >> NotStarted
        /// </summary>
        NotStarted = 0,
        
        /// <summary>
        /// >> StartedExport
        /// </summary>
        StartedExport = 1,
        
        /// <summary>
        /// >> CompletedExport
        /// </summary>
        CompletedExport = 2,
        
        /// <summary>
        /// >> StartedOverweightExport
        /// </summary>
        StartedOverweightExport = 3,
        
        /// <summary>
        /// >> CompletedOverweightExport
        /// </summary>
        CompletedOverweightExport = 4,
        
        /// <summary>
        /// >> StartedCleanup
        /// </summary>
        StartedCleanup = 5,
        
        /// <summary>
        /// >> Completed
        /// </summary>
        Completed = 6,
    }
    
    /// <summary>
    /// >> 403 - Variant[cumulus_pallet_dmp_queue.pallet.MigrationState]
    /// </summary>
    public sealed class EnumMigrationState : BaseEnumRust<MigrationState>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumMigrationState()
        {
				AddTypeDecoder<BaseVoid>(MigrationState.NotStarted);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(MigrationState.StartedExport);
				AddTypeDecoder<BaseVoid>(MigrationState.CompletedExport);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U64>(MigrationState.StartedOverweightExport);
				AddTypeDecoder<BaseVoid>(MigrationState.CompletedOverweightExport);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT22>>(MigrationState.StartedCleanup);
				AddTypeDecoder<BaseVoid>(MigrationState.Completed);
        }
    }
}
