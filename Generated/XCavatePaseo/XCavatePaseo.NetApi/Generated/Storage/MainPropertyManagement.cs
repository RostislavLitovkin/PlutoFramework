//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace XcavatePaseo.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> PropertyManagementStorage
    /// </summary>
    public sealed class PropertyManagementStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> PropertyManagementStorage Constructor
        /// </summary>
        public PropertyManagementStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("PropertyManagement", "LettingStorage"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substrate.NetApi.Model.Types.Primitive.U32), typeof(XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("PropertyManagement", "StoredFunds"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32), typeof(Substrate.NetApi.Model.Types.Primitive.U128)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("PropertyManagement", "LettingInfo"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32), typeof(XcavatePaseo.NetApi.Generated.Model.pallet_property_management.pallet.LettingAgentInfo)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("PropertyManagement", "LettingAgentLocations"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT8>), typeof(XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT34)));
        }
        
        /// <summary>
        /// >> LettingStorageParams
        ///  Mapping from the real estate object to the letting agent.
        /// </summary>
        public static string LettingStorageParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("PropertyManagement", "LettingStorage", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> LettingStorageDefault
        /// Default value as hex string
        /// </summary>
        public static string LettingStorageDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> LettingStorage
        ///  Mapping from the real estate object to the letting agent.
        /// </summary>
        public async Task<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32> LettingStorage(Substrate.NetApi.Model.Types.Primitive.U32 key, string blockhash, CancellationToken token)
        {
            string parameters = PropertyManagementStorage.LettingStorageParams(key);
            var result = await _client.GetStorageAsync<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> StoredFundsParams
        ///  Mapping from account to currently stored balance.
        /// </summary>
        public static string StoredFundsParams(XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("PropertyManagement", "StoredFunds", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> StoredFundsDefault
        /// Default value as hex string
        /// </summary>
        public static string StoredFundsDefault()
        {
            return "0x00000000000000000000000000000000";
        }
        
        /// <summary>
        /// >> StoredFunds
        ///  Mapping from account to currently stored balance.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> StoredFunds(XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 key, string blockhash, CancellationToken token)
        {
            string parameters = PropertyManagementStorage.StoredFundsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> LettingInfoParams
        ///  Mapping from account to letting agent info
        /// </summary>
        public static string LettingInfoParams(XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("PropertyManagement", "LettingInfo", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> LettingInfoDefault
        /// Default value as hex string
        /// </summary>
        public static string LettingInfoDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> LettingInfo
        ///  Mapping from account to letting agent info
        /// </summary>
        public async Task<XcavatePaseo.NetApi.Generated.Model.pallet_property_management.pallet.LettingAgentInfo> LettingInfo(XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 key, string blockhash, CancellationToken token)
        {
            string parameters = PropertyManagementStorage.LettingInfoParams(key);
            var result = await _client.GetStorageAsync<XcavatePaseo.NetApi.Generated.Model.pallet_property_management.pallet.LettingAgentInfo>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> LettingAgentLocationsParams
        ///  Mapping from location to the letting agents of this location.
        /// </summary>
        public static string LettingAgentLocationsParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT8> key)
        {
            return RequestGenerator.GetStorage("PropertyManagement", "LettingAgentLocations", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, key.Value);
        }
        
        /// <summary>
        /// >> LettingAgentLocationsDefault
        /// Default value as hex string
        /// </summary>
        public static string LettingAgentLocationsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> LettingAgentLocations
        ///  Mapping from location to the letting agents of this location.
        /// </summary>
        public async Task<XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT34> LettingAgentLocations(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT8> key, string blockhash, CancellationToken token)
        {
            string parameters = PropertyManagementStorage.LettingAgentLocationsParams(key);
            var result = await _client.GetStorageAsync<XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT34>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> PropertyManagementCalls
    /// </summary>
    public sealed class PropertyManagementCalls
    {
        
        /// <summary>
        /// >> add_letting_agent
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method AddLettingAgent(Substrate.NetApi.Model.Types.Primitive.U32 region, XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT8 location, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 letting_agent)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(region.Encode());
            byteArray.AddRange(location.Encode());
            byteArray.AddRange(letting_agent.Encode());
            return new Method(119, "PropertyManagement", 0, "add_letting_agent", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> letting_agent_deposit
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method LettingAgentDeposit()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(119, "PropertyManagement", 1, "letting_agent_deposit", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_letting_agent_to_location
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method AddLettingAgentToLocation(XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT8 location, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 letting_agent)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(location.Encode());
            byteArray.AddRange(letting_agent.Encode());
            return new Method(119, "PropertyManagement", 2, "add_letting_agent_to_location", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_letting_agent
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SetLettingAgent(Substrate.NetApi.Model.Types.Primitive.U32 asset_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(asset_id.Encode());
            return new Method(119, "PropertyManagement", 3, "set_letting_agent", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> distribute_income
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method DistributeIncome(Substrate.NetApi.Model.Types.Primitive.U32 asset_id, Substrate.NetApi.Model.Types.Primitive.U128 amount)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(asset_id.Encode());
            byteArray.AddRange(amount.Encode());
            return new Method(119, "PropertyManagement", 4, "distribute_income", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> withdraw_funds
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method WithdrawFunds()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(119, "PropertyManagement", 5, "withdraw_funds", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> PropertyManagementConstants
    /// </summary>
    public sealed class PropertyManagementConstants
    {
        
        /// <summary>
        /// >> PalletId
        ///  The property management's pallet id, used for deriving its sovereign account ID.
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.frame_support.PalletId PalletId()
        {
            var result = new XcavatePaseo.NetApi.Generated.Model.frame_support.PalletId();
            result.Create("0x70792F70706D6D74");
            return result;
        }
        
        /// <summary>
        /// >> MaxProperties
        ///  The maximum amount of properties that can be assigned to a letting agent.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxProperties()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xE8030000");
            return result;
        }
        
        /// <summary>
        /// >> MaxLettingAgents
        ///  The maximum amount of letting agents in a location.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxLettingAgents()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxLocations
        ///  The maximum amount of locations a letting agent can be assigned to.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxLocations()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x64000000");
            return result;
        }
    }
    
    /// <summary>
    /// >> PropertyManagementErrors
    /// </summary>
    public enum PropertyManagementErrors
    {
        
        /// <summary>
        /// >> ConversionError
        /// Error by convertion to balance type.
        /// </summary>
        ConversionError,
        
        /// <summary>
        /// >> DivisionError
        /// Error by dividing a number.
        /// </summary>
        DivisionError,
        
        /// <summary>
        /// >> MultiplyError
        /// Error by multiplying a number.
        /// </summary>
        MultiplyError,
        
        /// <summary>
        /// >> ArithmeticOverflow
        /// </summary>
        ArithmeticOverflow,
        
        /// <summary>
        /// >> UserHasNoFundsStored
        /// The caller has no funds stored.
        /// </summary>
        UserHasNoFundsStored,
        
        /// <summary>
        /// >> NotEnoughFunds
        /// The pallet has not enough funds.
        /// </summary>
        NotEnoughFunds,
        
        /// <summary>
        /// >> TooManyAssignedProperties
        /// The letting agent already has too many assigned properties.
        /// </summary>
        TooManyAssignedProperties,
        
        /// <summary>
        /// >> NoLettingAgentFound
        /// No letting agent could be selected.
        /// </summary>
        NoLettingAgentFound,
        
        /// <summary>
        /// >> RegionUnknown
        /// The region is not registered.
        /// </summary>
        RegionUnknown,
        
        /// <summary>
        /// >> TooManyLettingAgents
        /// The location has already the maximum amount of letting agents.
        /// </summary>
        TooManyLettingAgents,
        
        /// <summary>
        /// >> TooManyLocations
        /// The letting agent is already active in too many locations.
        /// </summary>
        TooManyLocations,
        
        /// <summary>
        /// >> NoPermission
        /// The user is not a property owner and has no permission to deposit.
        /// </summary>
        NoPermission,
        
        /// <summary>
        /// >> LettingAgentAlreadySet
        /// The letting agent of this property is already set.
        /// </summary>
        LettingAgentAlreadySet,
        
        /// <summary>
        /// >> NoObjectFound
        /// The real estate object could not be found.
        /// </summary>
        NoObjectFound,
        
        /// <summary>
        /// >> AgentNotFound
        /// The account is not a letting agent of this location.
        /// </summary>
        AgentNotFound,
        
        /// <summary>
        /// >> AlreadyDeposited
        /// The letting already deposited the necessary amount.
        /// </summary>
        AlreadyDeposited,
        
        /// <summary>
        /// >> LocationUnknown
        /// The location is not registered.
        /// </summary>
        LocationUnknown,
        
        /// <summary>
        /// >> LettingAgentInLocation
        /// The letting agent is already assigned to this location.
        /// </summary>
        LettingAgentInLocation,
        
        /// <summary>
        /// >> NotDeposited
        /// The letting agent has no funds deposited.
        /// </summary>
        NotDeposited,
        
        /// <summary>
        /// >> LettingAgentExists
        /// The letting agent is already registered.
        /// </summary>
        LettingAgentExists,
    }
}
