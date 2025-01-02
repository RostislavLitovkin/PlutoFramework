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


namespace Polkadot.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> MessageQueueStorage
    /// </summary>
    public sealed class MessageQueueStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> MessageQueueStorage Constructor
        /// </summary>
        public MessageQueueStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MessageQueue", "BookStateFor"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin), typeof(Polkadot.NetApi.Generated.Model.pallet_message_queue.BookState)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MessageQueue", "ServiceHead"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("MessageQueue", "Pages"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin, Substrate.NetApi.Model.Types.Primitive.U32>), typeof(Polkadot.NetApi.Generated.Model.pallet_message_queue.Page)));
        }
        
        /// <summary>
        /// >> BookStateForParams
        ///  The index of the first and last (non-empty) pages.
        /// </summary>
        public static string BookStateForParams(Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin key)
        {
            return RequestGenerator.GetStorage("MessageQueue", "BookStateFor", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> BookStateForDefault
        /// Default value as hex string
        /// </summary>
        public static string BookStateForDefault()
        {
            return "0x0000000000000000000000000000000000000000000000000000000000";
        }
        
        /// <summary>
        /// >> BookStateFor
        ///  The index of the first and last (non-empty) pages.
        /// </summary>
        public async Task<Polkadot.NetApi.Generated.Model.pallet_message_queue.BookState> BookStateFor(Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin key, string blockhash, CancellationToken token)
        {
            string parameters = MessageQueueStorage.BookStateForParams(key);
            var result = await _client.GetStorageAsync<Polkadot.NetApi.Generated.Model.pallet_message_queue.BookState>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> ServiceHeadParams
        ///  The origin at which we should begin servicing.
        /// </summary>
        public static string ServiceHeadParams()
        {
            return RequestGenerator.GetStorage("MessageQueue", "ServiceHead", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ServiceHeadDefault
        /// Default value as hex string
        /// </summary>
        public static string ServiceHeadDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ServiceHead
        ///  The origin at which we should begin servicing.
        /// </summary>
        public async Task<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin> ServiceHead(string blockhash, CancellationToken token)
        {
            string parameters = MessageQueueStorage.ServiceHeadParams();
            var result = await _client.GetStorageAsync<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> PagesParams
        ///  The map of page indices to pages.
        /// </summary>
        public static string PagesParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin, Substrate.NetApi.Model.Types.Primitive.U32> key)
        {
            return RequestGenerator.GetStorage("MessageQueue", "Pages", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> PagesDefault
        /// Default value as hex string
        /// </summary>
        public static string PagesDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Pages
        ///  The map of page indices to pages.
        /// </summary>
        public async Task<Polkadot.NetApi.Generated.Model.pallet_message_queue.Page> Pages(Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin, Substrate.NetApi.Model.Types.Primitive.U32> key, string blockhash, CancellationToken token)
        {
            string parameters = MessageQueueStorage.PagesParams(key);
            var result = await _client.GetStorageAsync<Polkadot.NetApi.Generated.Model.pallet_message_queue.Page>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> MessageQueueCalls
    /// </summary>
    public sealed class MessageQueueCalls
    {
        
        /// <summary>
        /// >> reap_page
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ReapPage(Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin message_origin, Substrate.NetApi.Model.Types.Primitive.U32 page_index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(message_origin.Encode());
            byteArray.AddRange(page_index.Encode());
            return new Method(100, "MessageQueue", 0, "reap_page", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> execute_overweight
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ExecuteOverweight(Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion.EnumAggregateMessageOrigin message_origin, Substrate.NetApi.Model.Types.Primitive.U32 page, Substrate.NetApi.Model.Types.Primitive.U32 index, Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight weight_limit)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(message_origin.Encode());
            byteArray.AddRange(page.Encode());
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(weight_limit.Encode());
            return new Method(100, "MessageQueue", 1, "execute_overweight", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> MessageQueueConstants
    /// </summary>
    public sealed class MessageQueueConstants
    {
        
        /// <summary>
        /// >> HeapSize
        ///  The size of the page; this implies the maximum message size which can be sent.
        /// 
        ///  A good value depends on the expected message sizes, their weights, the weight that is
        ///  available for processing them and the maximal needed message size. The maximal message
        ///  size is slightly lower than this as defined by [`MaxMessageLenOf`].
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 HeapSize()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00000100");
            return result;
        }
        
        /// <summary>
        /// >> MaxStale
        ///  The maximum number of stale pages (i.e. of overweight messages) allowed before culling
        ///  can happen. Once there are more stale pages than this, then historical pages may be
        ///  dropped, even if they contain unprocessed overweight messages.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxStale()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x08000000");
            return result;
        }
        
        /// <summary>
        /// >> ServiceWeight
        ///  The amount of weight (if any) which should be provided to the message queue for
        ///  servicing enqueued items `on_initialize`.
        /// 
        ///  This may be legitimately `None` in the case that you will call
        ///  `ServiceQueues::service_queues` manually or set [`Self::IdleMaxServiceWeight`] to have
        ///  it run in `on_idle`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight> ServiceWeight()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight>();
            result.Create("0x010700A0DB215D133333333333333333");
            return result;
        }
        
        /// <summary>
        /// >> IdleMaxServiceWeight
        ///  The maximum amount of weight (if any) to be used from remaining weight `on_idle` which
        ///  should be provided to the message queue for servicing enqueued items `on_idle`.
        ///  Useful for parachains to process messages at the same block they are received.
        /// 
        ///  If `None`, it will not call `ServiceQueues::service_queues` in `on_idle`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight> IdleMaxServiceWeight()
        {
            var result = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight>();
            result.Create("0x010700A0DB215D133333333333333333");
            return result;
        }
    }
    
    /// <summary>
    /// >> MessageQueueErrors
    /// </summary>
    public enum MessageQueueErrors
    {
        
        /// <summary>
        /// >> NotReapable
        /// Page is not reapable because it has items remaining to be processed and is not old
        /// enough.
        /// </summary>
        NotReapable,
        
        /// <summary>
        /// >> NoPage
        /// Page to be reaped does not exist.
        /// </summary>
        NoPage,
        
        /// <summary>
        /// >> NoMessage
        /// The referenced message could not be found.
        /// </summary>
        NoMessage,
        
        /// <summary>
        /// >> AlreadyProcessed
        /// The message was already processed and cannot be processed again.
        /// </summary>
        AlreadyProcessed,
        
        /// <summary>
        /// >> Queued
        /// The message is queued for future execution.
        /// </summary>
        Queued,
        
        /// <summary>
        /// >> InsufficientWeight
        /// There is temporarily not enough weight to continue servicing messages.
        /// </summary>
        InsufficientWeight,
        
        /// <summary>
        /// >> TemporarilyUnprocessable
        /// This message is temporarily unprocessable.
        /// 
        /// Such errors are expected, but not guaranteed, to resolve themselves eventually through
        /// retrying.
        /// </summary>
        TemporarilyUnprocessable,
        
        /// <summary>
        /// >> QueuePaused
        /// The queue is paused and no message can be executed from it.
        /// 
        /// This can change at any time and may resolve in the future by re-trying.
        /// </summary>
        QueuePaused,
        
        /// <summary>
        /// >> RecursiveDisallowed
        /// Another call is in progress and needs to finish before this call can happen.
        /// </summary>
        RecursiveDisallowed,
    }
}
