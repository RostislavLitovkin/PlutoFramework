//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System.Collections.Generic;


namespace Polkadot.NetApi.Generated.Model.pallet_delegated_staking.types
{
    
    
    /// <summary>
    /// >> 722 - Composite[pallet_delegated_staking.types.AgentLedger]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AgentLedger : BaseType
    {
        
        /// <summary>
        /// >> payee
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32 Payee { get; set; }
        /// <summary>
        /// >> total_delegated
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> TotalDelegated { get; set; }
        /// <summary>
        /// >> unclaimed_withdrawals
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> UnclaimedWithdrawals { get; set; }
        /// <summary>
        /// >> pending_slash
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128> PendingSlash { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AgentLedger";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Payee.Encode());
            result.AddRange(TotalDelegated.Encode());
            result.AddRange(UnclaimedWithdrawals.Encode());
            result.AddRange(PendingSlash.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Payee = new Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Payee.Decode(byteArray, ref p);
            TotalDelegated = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            TotalDelegated.Decode(byteArray, ref p);
            UnclaimedWithdrawals = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            UnclaimedWithdrawals.Decode(byteArray, ref p);
            PendingSlash = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            PendingSlash.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
