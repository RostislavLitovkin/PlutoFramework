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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_community_loan_pool.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> propose
        /// Creates a proposal for a loan. A deposit amount is reserved
        /// and slashed if the proposal is rejected. It is returned once the proposal is awarded.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `amount`: The amount of token that the real estate developer wants to lend.
        /// - `beneficiary`: The account that should be able to receive the funds.
        /// - `developer_experience`: Amout of years that the real estate developer has in experience.
        /// - `loan_term`: Estimated duration of the loan in months.
        /// 
        /// Emits `Proposed` event when succesfful
        /// </summary>
        propose = 0,
        
        /// <summary>
        /// >> propose_milestone
        /// Creates a proposal for the next milestone in the loan.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `loan_id`: The index of the loan.
        /// 
        /// Emits `MilestoneProposed` event when succesfful
        /// </summary>
        propose_milestone = 1,
        
        /// <summary>
        /// >> propose_deletion
        /// Creates a proposal for loan deletion.
        /// 
        /// The origin must be the borrower of the loan, Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `loan_id`: The index of the loan.
        /// 
        /// Emits `DeletionProposed` event when succesfful
        /// </summary>
        propose_deletion = 2,
        
        /// <summary>
        /// >> withdraw
        /// Lets the real estate developer withdraw the funds from the loan.
        /// 
        /// The origin must be the borrower of the loan, Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `loan_id`: The index of the loan.
        /// - `amount`: The amount of token the real estate developer wants to withdraw.
        /// 
        /// Emits `Withdraw` event when succesfful
        /// </summary>
        withdraw = 3,
        
        /// <summary>
        /// >> repay
        /// Lets the real estate developer repay the borrowed funds from the loan
        /// 
        /// The origin must be signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `loan_id`: The index of the loan.
        /// - `amount`: The amount of token the real estate developer wants to repay
        /// 
        /// Emits `LoanUpdated` event when succesfful
        /// </summary>
        repay = 4,
        
        /// <summary>
        /// >> set_milestones
        /// Lets the committee set the milestones for a loan.
        /// 	The caller automaticly votes yes for the proposal by calling this function.
        /// 
        /// The origin must be a member of the committee, signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `proposal_index`: The index of the proposal.
        /// - `proposed_milestones`: A vector with the different milestone percentages, it must be 100 in sum.
        /// 
        /// Emits `MilestonesSet` event when succesfful
        /// </summary>
        set_milestones = 5,
        
        /// <summary>
        /// >> vote_on_proposal
        /// Let committee members vote for a proposal.
        /// 
        /// The origin must be a member of the committee, signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `proposal_index`: The index of the proposal.
        /// - `vote`: Must be either a Yes vote or a No vote.
        /// 
        /// Emits `VotedOnProposal` event when succesfful.
        /// </summary>
        vote_on_proposal = 6,
        
        /// <summary>
        /// >> vote_on_milestone_proposal
        /// Let committee vote on milestone proposal.
        /// 
        /// The origin must be a member of the committee, signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `proposal_index`: The index of the proposal.
        /// - `vote`: Must be either a Yes vote or a No vote.
        /// 
        /// Emits `VotedOnMilestone` event when succesfful.
        /// </summary>
        vote_on_milestone_proposal = 7,
        
        /// <summary>
        /// >> vote_on_deletion_proposal
        /// Let committee vote on deletion proposal.
        /// 
        /// The origin must be a member of the committee, signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `proposal_index`: The index of the proposal.
        /// - `vote`: Must be either a Yes vote or a No vote.
        /// 
        /// Emits `VotedOnDeletion` event when succesfful.
        /// </summary>
        vote_on_deletion_proposal = 8,
        
        /// <summary>
        /// >> add_committee_member
        /// Adding a new address to the vote committee.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `member`: The address of the new committee member.
        /// 
        /// Emits `CommiteeMemberAdded` event when succesfful.
        /// </summary>
        add_committee_member = 9,
    }
    
    /// <summary>
    /// >> 345 - Variant[pallet_community_loan_pool.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, XCavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>>(Call.propose);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.propose_milestone);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.propose_deletion);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.withdraw);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.repay);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT13>>(Call.set_milestones);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.pallet_community_loan_pool.pallet.EnumVote>>(Call.vote_on_proposal);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.pallet_community_loan_pool.pallet.EnumVote>>(Call.vote_on_milestone_proposal);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.pallet_community_loan_pool.pallet.EnumVote>>(Call.vote_on_deletion_proposal);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.add_committee_member);
        }
    }
}
