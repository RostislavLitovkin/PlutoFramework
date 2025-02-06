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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_community_loan_pool.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> InsufficientProposersBalance
        /// Proposer's balance is too low.
        /// </summary>
        InsufficientProposersBalance = 0,
        
        /// <summary>
        /// >> InsufficientLoanPoolBalance
        /// Loan pool's balance is too low.
        /// </summary>
        InsufficientLoanPoolBalance = 1,
        
        /// <summary>
        /// >> InvalidIndex
        /// No proposal index.
        /// </summary>
        InvalidIndex = 2,
        
        /// <summary>
        /// >> InsufficientPermission
        /// The caller doesn't have enough permission.
        /// </summary>
        InsufficientPermission = 3,
        
        /// <summary>
        /// >> TooManyLoans
        /// Max amount of ongoing loan reached.
        /// </summary>
        TooManyLoans = 4,
        
        /// <summary>
        /// >> AlreadyVoted
        /// User has already voted.
        /// </summary>
        AlreadyVoted = 5,
        
        /// <summary>
        /// >> NotApproved
        /// Loan got not approved.
        /// </summary>
        NotApproved = 6,
        
        /// <summary>
        /// >> AlreadyMember
        /// The account is already a member in the voting committee.
        /// </summary>
        AlreadyMember = 7,
        
        /// <summary>
        /// >> TooManyMembers
        /// There are already enough committee members.
        /// </summary>
        TooManyMembers = 8,
        
        /// <summary>
        /// >> NotEnoughFundsToWithdraw
        /// There are not enough funds available in the loan.
        /// </summary>
        NotEnoughFundsToWithdraw = 9,
        
        /// <summary>
        /// >> LoanStillOngoing
        /// The loan is still ongoing.
        /// </summary>
        LoanStillOngoing = 10,
        
        /// <summary>
        /// >> NoMilestonesLeft
        /// All milestones have been accomplished.
        /// </summary>
        NoMilestonesLeft = 11,
        
        /// <summary>
        /// >> MilestonesHaveToCoverLoan
        /// Milestones of the loan have to be 100 % in sum
        /// </summary>
        MilestonesHaveToCoverLoan = 12,
        
        /// <summary>
        /// >> DeletionVotingOngoing
        /// Withdrawl is locked during ongoing voting for deletion.
        /// </summary>
        DeletionVotingOngoing = 13,
        
        /// <summary>
        /// >> WantsToRepayTooMuch
        /// The beneficiary didn't borrow that much funds.
        /// </summary>
        WantsToRepayTooMuch = 14,
        
        /// <summary>
        /// >> NotEnoughLoanFundsAvailable
        /// There are not enough funds available in the loan pallet.
        /// </summary>
        NotEnoughLoanFundsAvailable = 15,
        
        /// <summary>
        /// >> MilestonesAlreadySet
        /// The Milestones for the proposal have already been set.
        /// </summary>
        MilestonesAlreadySet = 16,
        
        /// <summary>
        /// >> NoMilestones
        /// There has been no milestones set in the proposal.
        /// </summary>
        NoMilestones = 17,
        
        /// <summary>
        /// >> UnknownCollection
        /// There is an issue by calling the next collection id.
        /// </summary>
        UnknownCollection = 18,
        
        /// <summary>
        /// >> ConversionError
        /// Error by convertion to balance type.
        /// </summary>
        ConversionError = 19,
        
        /// <summary>
        /// >> ArithmeticUnderflow
        /// </summary>
        ArithmeticUnderflow = 20,
        
        /// <summary>
        /// >> DivisionError
        /// Error by dividing a number.
        /// </summary>
        DivisionError = 21,
        
        /// <summary>
        /// >> NoLoanFound
        /// This loan does not exist
        /// </summary>
        NoLoanFound = 22,
        
        /// <summary>
        /// >> UserNotWhitelisted
        /// User has not passed the kyc.
        /// </summary>
        UserNotWhitelisted = 23,
    }
    
    /// <summary>
    /// >> 521 - Variant[pallet_community_loan_pool.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
