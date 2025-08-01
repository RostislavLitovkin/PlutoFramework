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


namespace BifrostPolkadot.NetApi.Generated.Model.pallet_evm_accounts.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> bind_evm_address
        /// Binds a Substrate address to EVM address.
        /// After binding, the EVM is able to convert an EVM address to the original Substrate
        /// address. Without binding, the EVM converts an EVM address to a truncated Substrate
        /// address, which doesn't correspond to the origin address.
        /// 
        /// Binding an address is not necessary for interacting with the EVM.
        /// 
        /// Parameters:
        /// - `origin`: Substrate account binding an address
        /// 
        /// Emits `EvmAccountBound` event when successful.
        /// </summary>
        bind_evm_address = 0,
        
        /// <summary>
        /// >> add_contract_deployer
        /// Adds an EVM address to the list of addresses that are allowed to deploy smart contracts.
        /// 
        /// Parameters:
        /// - `origin`: Substrate account whitelisting an address. Must be `ControllerOrigin`.
        /// - `address`: EVM address that is whitelisted
        /// 
        /// Emits `DeployerAdded` event when successful.
        /// </summary>
        add_contract_deployer = 1,
        
        /// <summary>
        /// >> remove_contract_deployer
        /// Removes an EVM address from the list of addresses that are allowed to deploy smart
        /// contracts.
        /// 
        /// Parameters:
        /// - `origin`: Substrate account removing the EVM address from the whitelist. Must be
        ///   `ControllerOrigin`.
        /// - `address`: EVM address that is removed from the whitelist
        /// 
        /// Emits `DeployerRemoved` event when successful.
        /// </summary>
        remove_contract_deployer = 2,
        
        /// <summary>
        /// >> renounce_contract_deployer
        /// Removes the account's EVM address from the list of addresses that are allowed to deploy
        /// smart contracts. Based on the best practices, this extrinsic can be called by any
        /// whitelisted account to renounce their own permission.
        /// 
        /// Parameters:
        /// - `origin`: Substrate account removing their EVM address from the whitelist.
        /// 
        /// Emits `DeployerRemoved` event when successful.
        /// </summary>
        renounce_contract_deployer = 3,
    }
    
    /// <summary>
    /// >> 305 - Variant[pallet_evm_accounts.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseVoid>(Call.bind_evm_address);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>(Call.add_contract_deployer);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>(Call.remove_contract_deployer);
				AddTypeDecoder<BaseVoid>(Call.renounce_contract_deployer);
        }
    }
}
