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


namespace Hydration.NetApi.Generated.Model.pallet_evm_accounts.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Bound
        /// Binding was created.
        /// </summary>
        Bound = 0,
        
        /// <summary>
        /// >> DeployerAdded
        /// Deployer was added.
        /// </summary>
        DeployerAdded = 1,
        
        /// <summary>
        /// >> DeployerRemoved
        /// Deployer was removed.
        /// </summary>
        DeployerRemoved = 2,
        
        /// <summary>
        /// >> ContractApproved
        /// Contract was approved.
        /// </summary>
        ContractApproved = 3,
        
        /// <summary>
        /// >> ContractDisapproved
        /// Contract was disapproved.
        /// </summary>
        ContractDisapproved = 4,
    }
    
    /// <summary>
    /// >> 463 - Variant[pallet_evm_accounts.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Hydration.NetApi.Generated.Model.primitive_types.H160>>(Event.Bound);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H160>(Event.DeployerAdded);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H160>(Event.DeployerRemoved);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H160>(Event.ContractApproved);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H160>(Event.ContractDisapproved);
        }
    }
}
