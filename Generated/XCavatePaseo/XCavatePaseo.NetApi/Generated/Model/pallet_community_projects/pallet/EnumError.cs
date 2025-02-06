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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_community_projects.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> TooManyListedNfts
        /// Max amount of listed nfts reached.
        /// </summary>
        TooManyListedNfts = 0,
        
        /// <summary>
        /// >> TooManyNfts
        /// Too many nfts for this collection.
        /// </summary>
        TooManyNfts = 1,
        
        /// <summary>
        /// >> NftNotFound
        /// The Nft has not been found.
        /// </summary>
        NftNotFound = 2,
        
        /// <summary>
        /// >> InvalidIndex
        /// This index is not taken.
        /// </summary>
        InvalidIndex = 3,
        
        /// <summary>
        /// >> NotEnoughFunds
        /// The buyer doesn't have enough funds.
        /// </summary>
        NotEnoughFunds = 4,
        
        /// <summary>
        /// >> UnknownCollection
        /// A collection is unknown.
        /// </summary>
        UnknownCollection = 5,
        
        /// <summary>
        /// >> ConversionError
        /// Error during type conversion.
        /// </summary>
        ConversionError = 6,
        
        /// <summary>
        /// >> TooManyProjects
        /// Maximum amount of projects already exist.
        /// </summary>
        TooManyProjects = 7,
        
        /// <summary>
        /// >> AlreadyVoted
        /// A user has already voted during a voting period.
        /// </summary>
        AlreadyVoted = 8,
        
        /// <summary>
        /// >> TooManyVoters
        /// Maximum amount of voters has been reached.
        /// </summary>
        TooManyVoters = 9,
        
        /// <summary>
        /// >> InsufficientPermission
        /// No permission.
        /// </summary>
        InsufficientPermission = 10,
        
        /// <summary>
        /// >> NoOngoingVotingPeriod
        /// No voting period ongoing.
        /// </summary>
        NoOngoingVotingPeriod = 11,
        
        /// <summary>
        /// >> NoFundsRemaining
        /// This account has no voting power.
        /// </summary>
        NoFundsRemaining = 12,
        
        /// <summary>
        /// >> WrongAmountOfMetadata
        /// Metadata is not the same amount as nft types.
        /// </summary>
        WrongAmountOfMetadata = 13,
        
        /// <summary>
        /// >> DurationMustBeHigherThanZero
        /// The Duration must be at least one.
        /// </summary>
        DurationMustBeHigherThanZero = 14,
        
        /// <summary>
        /// >> PriceCannotBeReached
        /// The target price is impossible to reach.
        /// </summary>
        PriceCannotBeReached = 15,
        
        /// <summary>
        /// >> UserNotWhitelisted
        /// User has not passed the kyc.
        /// </summary>
        UserNotWhitelisted = 16,
        
        /// <summary>
        /// >> ProjectOngoing
        /// Bonding not possible since project is ongoing.
        /// </summary>
        ProjectOngoing = 17,
        
        /// <summary>
        /// >> NotEnoughBondingFundsAvailable
        /// There are not enough funds available in the bonding pool.
        /// </summary>
        NotEnoughBondingFundsAvailable = 18,
        
        /// <summary>
        /// >> ProjectCanOnlyHave10PercentBonding
        /// A Project can only be financed by 10 percent bonding.
        /// </summary>
        ProjectCanOnlyHave10PercentBonding = 19,
        
        /// <summary>
        /// >> NftTypeNotFound
        /// The nft type does not exist.
        /// </summary>
        NftTypeNotFound = 20,
        
        /// <summary>
        /// >> NotEnoughNftsAvailable
        /// There are not enough nfts of this type available.
        /// </summary>
        NotEnoughNftsAvailable = 21,
        
        /// <summary>
        /// >> NoBondingYet
        /// The user did not bond any token yet.
        /// </summary>
        NoBondingYet = 22,
    }
    
    /// <summary>
    /// >> 529 - Variant[pallet_community_projects.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
