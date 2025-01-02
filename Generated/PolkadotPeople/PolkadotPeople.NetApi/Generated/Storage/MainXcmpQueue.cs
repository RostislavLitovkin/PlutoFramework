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


namespace PolkadotPeople.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> XcmpQueueStorage
    /// </summary>
    public sealed class XcmpQueueStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> XcmpQueueStorage Constructor
        /// </summary>
        public XcmpQueueStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "InboundXcmpSuspended"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_btree_set.BoundedBTreeSet)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "OutboundXcmpStatus"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT11)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "OutboundXcmpMessages"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U16>), typeof(PolkadotPeople.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "SignalMessages"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id), typeof(PolkadotPeople.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "QueueConfig"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(PolkadotPeople.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.QueueConfigData)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "QueueSuspended"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.Bool)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmpQueue", "DeliveryFeeFactor"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id), typeof(PolkadotPeople.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128)));
        }
        
        /// <summary>
        /// >> InboundXcmpSuspendedParams
        ///  The suspended inbound XCMP channels. All others are not suspended.
        /// 
        ///  This is a `StorageValue` instead of a `StorageMap` since we expect multiple reads per block
        ///  to different keys with a one byte payload. The access to `BoundedBTreeSet` will be cached
        ///  within the block and therefore only included once in the proof size.
        /// 
        ///  NOTE: The PoV benchmarking cannot know this and will over-estimate, but the actual proof
        ///  will be smaller.
        /// </summary>
        public static string InboundXcmpSuspendedParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "InboundXcmpSuspended", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> InboundXcmpSuspendedDefault
        /// Default value as hex string
        /// </summary>
        public static string InboundXcmpSuspendedDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> InboundXcmpSuspended
        ///  The suspended inbound XCMP channels. All others are not suspended.
        /// 
        ///  This is a `StorageValue` instead of a `StorageMap` since we expect multiple reads per block
        ///  to different keys with a one byte payload. The access to `BoundedBTreeSet` will be cached
        ///  within the block and therefore only included once in the proof size.
        /// 
        ///  NOTE: The PoV benchmarking cannot know this and will over-estimate, but the actual proof
        ///  will be smaller.
        /// </summary>
        public async Task<PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_btree_set.BoundedBTreeSet> InboundXcmpSuspended(string blockhash, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.InboundXcmpSuspendedParams();
            var result = await _client.GetStorageAsync<PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_btree_set.BoundedBTreeSet>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> OutboundXcmpStatusParams
        ///  The non-empty XCMP channels in order of becoming non-empty, and the index of the first
        ///  and last outbound message. If the two indices are equal, then it indicates an empty
        ///  queue and there must be a non-`Ok` `OutboundStatus`. We assume queues grow no greater
        ///  than 65535 items. Queue indices for normal messages begin at one; zero is reserved in
        ///  case of the need to send a high-priority signal message this block.
        ///  The bool is true if there is a signal message waiting to be sent.
        /// </summary>
        public static string OutboundXcmpStatusParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "OutboundXcmpStatus", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> OutboundXcmpStatusDefault
        /// Default value as hex string
        /// </summary>
        public static string OutboundXcmpStatusDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> OutboundXcmpStatus
        ///  The non-empty XCMP channels in order of becoming non-empty, and the index of the first
        ///  and last outbound message. If the two indices are equal, then it indicates an empty
        ///  queue and there must be a non-`Ok` `OutboundStatus`. We assume queues grow no greater
        ///  than 65535 items. Queue indices for normal messages begin at one; zero is reserved in
        ///  case of the need to send a high-priority signal message this block.
        ///  The bool is true if there is a signal message waiting to be sent.
        /// </summary>
        public async Task<PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT11> OutboundXcmpStatus(string blockhash, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.OutboundXcmpStatusParams();
            var result = await _client.GetStorageAsync<PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT11>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> OutboundXcmpMessagesParams
        ///  The messages outbound in a given XCMP channel.
        /// </summary>
        public static string OutboundXcmpMessagesParams(Substrate.NetApi.Model.Types.Base.BaseTuple<PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U16> key)
        {
            return RequestGenerator.GetStorage("XcmpQueue", "OutboundXcmpMessages", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> OutboundXcmpMessagesDefault
        /// Default value as hex string
        /// </summary>
        public static string OutboundXcmpMessagesDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> OutboundXcmpMessages
        ///  The messages outbound in a given XCMP channel.
        /// </summary>
        public async Task<PolkadotPeople.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3> OutboundXcmpMessages(Substrate.NetApi.Model.Types.Base.BaseTuple<PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U16> key, string blockhash, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.OutboundXcmpMessagesParams(key);
            var result = await _client.GetStorageAsync<PolkadotPeople.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> SignalMessagesParams
        ///  Any signal messages waiting to be sent.
        /// </summary>
        public static string SignalMessagesParams(PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id key)
        {
            return RequestGenerator.GetStorage("XcmpQueue", "SignalMessages", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SignalMessagesDefault
        /// Default value as hex string
        /// </summary>
        public static string SignalMessagesDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> SignalMessages
        ///  Any signal messages waiting to be sent.
        /// </summary>
        public async Task<PolkadotPeople.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3> SignalMessages(PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id key, string blockhash, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.SignalMessagesParams(key);
            var result = await _client.GetStorageAsync<PolkadotPeople.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> QueueConfigParams
        ///  The configuration which controls the dynamics of the outbound queue.
        /// </summary>
        public static string QueueConfigParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "QueueConfig", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> QueueConfigDefault
        /// Default value as hex string
        /// </summary>
        public static string QueueConfigDefault()
        {
            return "0x200000003000000008000000";
        }
        
        /// <summary>
        /// >> QueueConfig
        ///  The configuration which controls the dynamics of the outbound queue.
        /// </summary>
        public async Task<PolkadotPeople.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.QueueConfigData> QueueConfig(string blockhash, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.QueueConfigParams();
            var result = await _client.GetStorageAsync<PolkadotPeople.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.QueueConfigData>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> QueueSuspendedParams
        ///  Whether or not the XCMP queue is suspended from executing incoming XCMs or not.
        /// </summary>
        public static string QueueSuspendedParams()
        {
            return RequestGenerator.GetStorage("XcmpQueue", "QueueSuspended", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> QueueSuspendedDefault
        /// Default value as hex string
        /// </summary>
        public static string QueueSuspendedDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> QueueSuspended
        ///  Whether or not the XCMP queue is suspended from executing incoming XCMs or not.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> QueueSuspended(string blockhash, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.QueueSuspendedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> DeliveryFeeFactorParams
        ///  The factor to multiply the base delivery fee by.
        /// </summary>
        public static string DeliveryFeeFactorParams(PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id key)
        {
            return RequestGenerator.GetStorage("XcmpQueue", "DeliveryFeeFactor", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> DeliveryFeeFactorDefault
        /// Default value as hex string
        /// </summary>
        public static string DeliveryFeeFactorDefault()
        {
            return "0x000064A7B3B6E00D0000000000000000";
        }
        
        /// <summary>
        /// >> DeliveryFeeFactor
        ///  The factor to multiply the base delivery fee by.
        /// </summary>
        public async Task<PolkadotPeople.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128> DeliveryFeeFactor(PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id key, string blockhash, CancellationToken token)
        {
            string parameters = XcmpQueueStorage.DeliveryFeeFactorParams(key);
            var result = await _client.GetStorageAsync<PolkadotPeople.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> XcmpQueueCalls
    /// </summary>
    public sealed class XcmpQueueCalls
    {
        
        /// <summary>
        /// >> suspend_xcm_execution
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SuspendXcmExecution()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(30, "XcmpQueue", 1, "suspend_xcm_execution", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> resume_xcm_execution
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ResumeXcmExecution()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(30, "XcmpQueue", 2, "resume_xcm_execution", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_suspend_threshold
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method UpdateSuspendThreshold(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 3, "update_suspend_threshold", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_drop_threshold
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method UpdateDropThreshold(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 4, "update_drop_threshold", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_resume_threshold
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method UpdateResumeThreshold(Substrate.NetApi.Model.Types.Primitive.U32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@new.Encode());
            return new Method(30, "XcmpQueue", 5, "update_resume_threshold", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> XcmpQueueConstants
    /// </summary>
    public sealed class XcmpQueueConstants
    {
        
        /// <summary>
        /// >> MaxInboundSuspended
        ///  The maximum number of inbound XCMP channels that can be suspended simultaneously.
        /// 
        ///  Any further channel suspensions will fail and messages may get dropped without further
        ///  notice. Choosing a high value (1000) is okay; the trade-off that is described in
        ///  [`InboundXcmpSuspended`] still applies at that scale.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxInboundSuspended()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xE8030000");
            return result;
        }
        
        /// <summary>
        /// >> MaxActiveOutboundChannels
        ///  Maximal number of outbound XCMP channels that can have messages queued at the same time.
        /// 
        ///  If this is reached, then no further messages can be sent to channels that do not yet
        ///  have a message queued. This should be set to the expected maximum of outbound channels
        ///  which is determined by [`Self::ChannelInfo`]. It is important to set this large enough,
        ///  since otherwise the congestion control protocol will not work as intended and messages
        ///  may be dropped. This value increases the PoV and should therefore not be picked too
        ///  high. Governance needs to pay attention to not open more channels than this value.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxActiveOutboundChannels()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x80000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxPageSize
        ///  The maximal page size for HRMP message pages.
        /// 
        ///  A lower limit can be set dynamically, but this is the hard-limit for the PoV worst case
        ///  benchmarking. The limit for the size of a message is slightly below this, since some
        ///  overhead is incurred for encoding the format.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxPageSize()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x009C0100");
            return result;
        }
    }
    
    /// <summary>
    /// >> XcmpQueueErrors
    /// </summary>
    public enum XcmpQueueErrors
    {
        
        /// <summary>
        /// >> BadQueueConfig
        /// Setting the queue config failed since one of its values was invalid.
        /// </summary>
        BadQueueConfig,
        
        /// <summary>
        /// >> AlreadySuspended
        /// The execution is already suspended.
        /// </summary>
        AlreadySuspended,
        
        /// <summary>
        /// >> AlreadyResumed
        /// The execution is already resumed.
        /// </summary>
        AlreadyResumed,
        
        /// <summary>
        /// >> TooManyActiveOutboundChannels
        /// There are too many active outbound channels.
        /// </summary>
        TooManyActiveOutboundChannels,
        
        /// <summary>
        /// >> TooBig
        /// The message is too big.
        /// </summary>
        TooBig,
    }
}
