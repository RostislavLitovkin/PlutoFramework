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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_game.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> setup_game
        /// Creates the setup for a new game.
        /// 
        /// The origin must be the sudo.
        /// </summary>
        setup_game = 0,
        
        /// <summary>
        /// >> register_user
        /// Registers a player and gives him initialy 50 points.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `player`: The AccountId of the user who gets registered.
        /// 
        /// Emits `NewPlayerRegistered` event when succesfful.
        /// </summary>
        register_user = 1,
        
        /// <summary>
        /// >> give_points
        /// Gives points to a user.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `receiver`: The AccountId of the user who gets points.
        /// 
        /// Emits `LocationCreated` event when succesfful.
        /// </summary>
        give_points = 2,
        
        /// <summary>
        /// >> play_game
        /// Starts a game for the player.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `game_type`: The difficulty level of the game.
        /// 
        /// Emits `GameStarted` event when succesfful.
        /// </summary>
        play_game = 3,
        
        /// <summary>
        /// >> submit_answer
        /// Checks the answer of the player and handles rewards accordingly.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `guess`: The answer of the player.
        /// - `game_id`: The id of the game that the player wants to answer to.
        /// 
        /// Emits `AnswerSubmitted` event when succesfful.
        /// </summary>
        submit_answer = 4,
        
        /// <summary>
        /// >> check_result
        /// Checks the answer of the player and handles rewards accordingly.
        /// 
        /// The origin must be root.
        /// 
        /// Parameters:
        /// - `guess`: The answer of the player.
        /// - `game_id`: The id of the game that the result should be compared to.
        /// - `price`: The price of the property.
        /// - `secret`: The secret to decrypt the price and property data.
        /// 
        /// Emits `ResultChecked` event when succesfful.
        /// </summary>
        check_result = 5,
        
        /// <summary>
        /// >> list_nft
        /// Lists a nft from the user.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `collection_id`: The collection id of the nft that will be listed.
        /// - `item_id`: The item id of the nft that will be listed.
        /// 
        /// Emits `NftListed` event when succesfful.
        /// </summary>
        list_nft = 6,
        
        /// <summary>
        /// >> delist_nft
        /// Delists a nft from the user.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `listing_id`: The listing id of the listing.
        /// 
        /// Emits `NftDelisted` event when succesfful.
        /// </summary>
        delist_nft = 7,
        
        /// <summary>
        /// >> make_offer
        /// Makes an offer for a nft listing.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `listing_id`: The listing id of the listing.
        /// - `collection_id`: The collection id of the nft that will be offered.
        /// - `item_id`: The item id of the nft that will be offered.
        /// 
        /// Emits `OfferMade` event when succesfful.
        /// </summary>
        make_offer = 8,
        
        /// <summary>
        /// >> withdraw_offer
        /// Withdraw an offer.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `offer_id`: The id of the offer.
        /// 
        /// Emits `OfferWithdrawn` event when succesfful.
        /// </summary>
        withdraw_offer = 9,
        
        /// <summary>
        /// >> handle_offer
        /// Handles an offer for a nft listing.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Parameters:
        /// - `offer_id`: The id of the offer.
        /// - `offer`: Must be either Accept or Reject.
        /// 
        /// Emits `OfferHandeld` event when succesfful.
        /// </summary>
        handle_offer = 10,
        
        /// <summary>
        /// >> add_property
        /// Add a new property and the price.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `property`: The new property that will be added.
        /// - `price`: The price of the property that will be added.
        /// </summary>
        add_property = 11,
        
        /// <summary>
        /// >> remove_property
        /// Remove a new property and the price.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `id`: The id of the property that should be removed.
        /// </summary>
        remove_property = 12,
        
        /// <summary>
        /// >> add_to_admins
        /// Adds an account to the admins.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `new_admin`: The address of the new account added to the list.
        /// 
        /// Emits `NewAdminAdded` event when succesfful
        /// </summary>
        add_to_admins = 13,
        
        /// <summary>
        /// >> remove_from_admins
        /// Removes an account from the admins.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `admin`: The address of the admin removed from the admins.
        /// 
        /// Emits `UserRemoved` event when succesfful
        /// </summary>
        remove_from_admins = 14,
        
        /// <summary>
        /// >> request_token
        /// Lets the player request token to play.
        /// 
        /// The origin must be Signed and the sender must have sufficient funds free.
        /// 
        /// Emits `TokenReceived` event when succesfful.
        /// </summary>
        request_token = 15,
    }
    
    /// <summary>
    /// >> 273 - Variant[pallet_game.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseVoid>(Call.setup_game);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.register_user);
				AddTypeDecoder<BaseTuple<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.give_points);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.pallet_game.types.EnumDifficultyLevel>(Call.play_game);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.submit_answer);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U64, XCavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT12>>(Call.check_result);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.list_nft);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.delist_nft);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.make_offer);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.withdraw_offer);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.pallet_game.types.EnumOffer>>(Call.handle_offer);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.pallet_game.types.PropertyInfoData>(Call.add_property);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.remove_property);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.add_to_admins);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.remove_from_admins);
				AddTypeDecoder<BaseVoid>(Call.request_token);
        }
    }
}
