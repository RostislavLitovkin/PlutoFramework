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


namespace Kilt.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> UtilityStorage
    /// </summary>
    public sealed class UtilityStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> UtilityStorage Constructor
        /// </summary>
        public UtilityStorage(SubstrateClientExt client)
        {
            this._client = client;
        }
    }
    
    /// <summary>
    /// >> UtilityCalls
    /// </summary>
    public sealed class UtilityCalls
    {
        
        /// <summary>
        /// >> batch
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Batch(Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall> calls)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(calls.Encode());
            return new Method(40, "Utility", 0, "batch", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> as_derivative
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method AsDerivative(Substrate.NetApi.Model.Types.Primitive.U16 index, Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(40, "Utility", 1, "as_derivative", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> batch_all
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method BatchAll(Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall> calls)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(calls.Encode());
            return new Method(40, "Utility", 2, "batch_all", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> dispatch_as
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method DispatchAs(Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumOriginCaller as_origin, Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(as_origin.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(40, "Utility", 3, "dispatch_as", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_batch
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ForceBatch(Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall> calls)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(calls.Encode());
            return new Method(40, "Utility", 4, "force_batch", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> with_weight
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method WithWeight(Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall call, Kilt.NetApi.Generated.Model.sp_weights.weight_v2.Weight weight)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(call.Encode());
            byteArray.AddRange(weight.Encode());
            return new Method(40, "Utility", 5, "with_weight", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> UtilityConstants
    /// </summary>
    public sealed class UtilityConstants
    {
        
        /// <summary>
        /// >> batched_calls_limit
        ///  The limit on the number of batched calls.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 batched_calls_limit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xAA2A0000");
            return result;
        }
    }
    
    /// <summary>
    /// >> UtilityErrors
    /// </summary>
    public enum UtilityErrors
    {
        
        /// <summary>
        /// >> TooManyCalls
        /// Too many calls batched.
        /// </summary>
        TooManyCalls,
    }
}
