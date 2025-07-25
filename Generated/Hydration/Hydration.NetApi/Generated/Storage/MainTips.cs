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


namespace Hydration.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> TipsStorage
    /// </summary>
    public sealed class TipsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> TipsStorage Constructor
        /// </summary>
        public TipsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Tips", "Tips"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Hydration.NetApi.Generated.Model.primitive_types.H256), typeof(Hydration.NetApi.Generated.Model.pallet_tips.OpenTip)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Tips", "Reasons"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Hydration.NetApi.Generated.Model.primitive_types.H256), typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>)));
        }
        
        /// <summary>
        /// >> TipsParams
        ///  TipsMap that are not yet completed. Keyed by the hash of `(reason, who)` from the value.
        ///  This has the insecure enumerable hash function since the key itself is already
        ///  guaranteed to be a secure hash.
        /// </summary>
        public static string TipsParams(Hydration.NetApi.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Tips", "Tips", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> TipsDefault
        /// Default value as hex string
        /// </summary>
        public static string TipsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Tips
        ///  TipsMap that are not yet completed. Keyed by the hash of `(reason, who)` from the value.
        ///  This has the insecure enumerable hash function since the key itself is already
        ///  guaranteed to be a secure hash.
        /// </summary>
        public async Task<Hydration.NetApi.Generated.Model.pallet_tips.OpenTip> Tips(Hydration.NetApi.Generated.Model.primitive_types.H256 key, string blockhash, CancellationToken token)
        {
            string parameters = TipsStorage.TipsParams(key);
            var result = await _client.GetStorageAsync<Hydration.NetApi.Generated.Model.pallet_tips.OpenTip>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> ReasonsParams
        ///  Simple preimage lookup from the reason's hash to the original data. Again, has an
        ///  insecure enumerable hash since the key is guaranteed to be the result of a secure hash.
        /// </summary>
        public static string ReasonsParams(Hydration.NetApi.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Tips", "Reasons", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ReasonsDefault
        /// Default value as hex string
        /// </summary>
        public static string ReasonsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Reasons
        ///  Simple preimage lookup from the reason's hash to the original data. Again, has an
        ///  insecure enumerable hash since the key is guaranteed to be the result of a secure hash.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> Reasons(Hydration.NetApi.Generated.Model.primitive_types.H256 key, string blockhash, CancellationToken token)
        {
            string parameters = TipsStorage.ReasonsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> TipsCalls
    /// </summary>
    public sealed class TipsCalls
    {
        
        /// <summary>
        /// >> report_awesome
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ReportAwesome(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> reason, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 who)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reason.Encode());
            byteArray.AddRange(who.Encode());
            return new Method(27, "Tips", 0, "report_awesome", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> retract_tip
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RetractTip(Hydration.NetApi.Generated.Model.primitive_types.H256 hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            return new Method(27, "Tips", 1, "retract_tip", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> tip_new
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method TipNew(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> reason, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 who, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> tip_value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reason.Encode());
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(tip_value.Encode());
            return new Method(27, "Tips", 2, "tip_new", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> tip
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Tip(Hydration.NetApi.Generated.Model.primitive_types.H256 hash, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> tip_value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            byteArray.AddRange(tip_value.Encode());
            return new Method(27, "Tips", 3, "tip", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> close_tip
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method CloseTip(Hydration.NetApi.Generated.Model.primitive_types.H256 hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            return new Method(27, "Tips", 4, "close_tip", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> slash_tip
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SlashTip(Hydration.NetApi.Generated.Model.primitive_types.H256 hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(hash.Encode());
            return new Method(27, "Tips", 5, "slash_tip", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> TipsConstants
    /// </summary>
    public sealed class TipsConstants
    {
        
        /// <summary>
        /// >> MaximumReasonLength
        ///  Maximum acceptable reason length.
        /// 
        ///  Benchmarks depend on this value, be sure to update weights file when changing this value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaximumReasonLength()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00040000");
            return result;
        }
        
        /// <summary>
        /// >> DataDepositPerByte
        ///  The amount held on deposit per byte within the tip report reason or bounty description.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 DataDepositPerByte()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0010A5D4E80000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> TipCountdown
        ///  The period for which a tip remains open after is has achieved threshold tippers.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TipCountdown()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x40380000");
            return result;
        }
        
        /// <summary>
        /// >> TipFindersFee
        ///  The percent of the final tip which goes to the original reporter of the tip.
        /// </summary>
        public Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Percent TipFindersFee()
        {
            var result = new Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Percent();
            result.Create("0x01");
            return result;
        }
        
        /// <summary>
        /// >> TipReportDepositBase
        ///  The non-zero amount held on deposit for placing a tip report.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TipReportDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0080C6A47E8D03000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxTipAmount
        ///  The maximum amount for a single tip.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 MaxTipAmount()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0000F444829163450000000000000000");
            return result;
        }
    }
    
    /// <summary>
    /// >> TipsErrors
    /// </summary>
    public enum TipsErrors
    {
        
        /// <summary>
        /// >> ReasonTooBig
        /// The reason given is just too big.
        /// </summary>
        ReasonTooBig,
        
        /// <summary>
        /// >> AlreadyKnown
        /// The tip was already found/started.
        /// </summary>
        AlreadyKnown,
        
        /// <summary>
        /// >> UnknownTip
        /// The tip hash is unknown.
        /// </summary>
        UnknownTip,
        
        /// <summary>
        /// >> MaxTipAmountExceeded
        /// The tip given was too generous.
        /// </summary>
        MaxTipAmountExceeded,
        
        /// <summary>
        /// >> NotFinder
        /// The account attempting to retract the tip is not the finder of the tip.
        /// </summary>
        NotFinder,
        
        /// <summary>
        /// >> StillOpen
        /// The tip cannot be claimed/closed because there are not enough tippers yet.
        /// </summary>
        StillOpen,
        
        /// <summary>
        /// >> Premature
        /// The tip cannot be claimed/closed because it's still in the countdown period.
        /// </summary>
        Premature,
    }
}
