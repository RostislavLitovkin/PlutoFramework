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


namespace Opal.NetApi.Generated.Model.pallet_unique.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Type alias to Pallet, to be used by construct_runtime.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> create_collection
        /// Create a collection of tokens.
        /// 
        /// Each Token may have multiple properties encoded as an array of bytes
        /// of certain length. The initial owner of the collection is set
        /// to the address that signed the transaction and can be changed later.
        /// 
        /// Prefer the more advanced [`create_collection_ex`][`Pallet::create_collection_ex`] instead.
        /// 
        /// # Permissions
        /// 
        /// * Anyone - becomes the owner of the new collection.
        /// 
        /// # Arguments
        /// 
        /// * `collection_name`: Wide-character string with collection name
        /// (limit [`MAX_COLLECTION_NAME_LENGTH`]).
        /// * `collection_description`: Wide-character string with collection description
        /// (limit [`MAX_COLLECTION_DESCRIPTION_LENGTH`]).
        /// * `token_prefix`: Byte string containing the token prefix to mark a collection
        /// to which a token belongs (limit [`MAX_TOKEN_PREFIX_LENGTH`]).
        /// * `mode`: Type of items stored in the collection and type dependent data.
        /// 
        /// returns collection ID
        /// 
        /// Deprecated: `create_collection_ex` is more up-to-date and advanced, prefer it instead.
        /// </summary>
        create_collection = 0,
        
        /// <summary>
        /// >> create_collection_ex
        /// Create a collection with explicit parameters.
        /// 
        /// Prefer it to the deprecated [`create_collection`][`Pallet::create_collection`] method.
        /// 
        /// # Permissions
        /// 
        /// * Anyone - becomes the owner of the new collection.
        /// 
        /// # Arguments
        /// 
        /// * `data`: Explicit data of a collection used for its creation.
        /// </summary>
        create_collection_ex = 1,
        
        /// <summary>
        /// >> destroy_collection
        /// Destroy a collection if no tokens exist within.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: Collection to destroy.
        /// </summary>
        destroy_collection = 2,
        
        /// <summary>
        /// >> add_to_allow_list
        /// Add an address to allow list.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `address`: ID of the address to be added to the allowlist.
        /// </summary>
        add_to_allow_list = 3,
        
        /// <summary>
        /// >> remove_from_allow_list
        /// Remove an address from allow list.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `address`: ID of the address to be removed from the allowlist.
        /// </summary>
        remove_from_allow_list = 4,
        
        /// <summary>
        /// >> change_collection_owner
        /// Change the owner of the collection.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `new_owner`: ID of the account that will become the owner.
        /// </summary>
        change_collection_owner = 5,
        
        /// <summary>
        /// >> add_collection_admin
        /// Add an admin to a collection.
        /// 
        /// NFT Collection can be controlled by multiple admin addresses
        /// (some which can also be servers, for example). Admins can issue
        /// and burn NFTs, as well as add and remove other admins,
        /// but cannot change NFT or Collection ownership.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the Collection to add an admin for.
        /// * `new_admin`: Address of new admin to add.
        /// </summary>
        add_collection_admin = 6,
        
        /// <summary>
        /// >> remove_collection_admin
        /// Remove admin of a collection.
        /// 
        /// An admin address can remove itself. List of admins may become empty,
        /// in which case only Collection Owner will be able to add an Admin.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection to remove the admin for.
        /// * `account_id`: Address of the admin to remove.
        /// </summary>
        remove_collection_admin = 7,
        
        /// <summary>
        /// >> set_collection_sponsor
        /// Set (invite) a new collection sponsor.
        /// 
        /// If successful, confirmation from the sponsor-to-be will be pending.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `new_sponsor`: ID of the account of the sponsor-to-be.
        /// </summary>
        set_collection_sponsor = 8,
        
        /// <summary>
        /// >> confirm_sponsorship
        /// Confirm own sponsorship of a collection, becoming the sponsor.
        /// 
        /// An invitation must be pending, see [`set_collection_sponsor`][`Pallet::set_collection_sponsor`].
        /// Sponsor can pay the fees of a transaction instead of the sender,
        /// but only within specified limits.
        /// 
        /// # Permissions
        /// 
        /// * Sponsor-to-be
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection with the pending sponsor.
        /// </summary>
        confirm_sponsorship = 9,
        
        /// <summary>
        /// >> remove_collection_sponsor
        /// Remove a collection's a sponsor, making everyone pay for their own transactions.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection with the sponsor to remove.
        /// </summary>
        remove_collection_sponsor = 10,
        
        /// <summary>
        /// >> create_item
        /// Mint an item within a collection.
        /// 
        /// A collection must exist first, see [`create_collection_ex`][`Pallet::create_collection_ex`].
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Anyone if
        ///     * Allow List is enabled, and
        ///     * Address is added to allow list, and
        ///     * MintPermission is enabled (see [`set_collection_permissions`][`Pallet::set_collection_permissions`])
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection to which an item would belong.
        /// * `owner`: Address of the initial owner of the item.
        /// * `data`: Token data describing the item to store on chain.
        /// </summary>
        create_item = 11,
        
        /// <summary>
        /// >> create_multiple_items
        /// Create multiple items within a collection.
        /// 
        /// A collection must exist first, see [`create_collection_ex`][`Pallet::create_collection_ex`].
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Anyone if
        ///     * Allow List is enabled, and
        ///     * Address is added to the allow list, and
        ///     * MintPermission is enabled (see [`set_collection_permissions`][`Pallet::set_collection_permissions`])
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection to which the tokens would belong.
        /// * `owner`: Address of the initial owner of the tokens.
        /// * `items_data`: Vector of data describing each item to be created.
        /// </summary>
        create_multiple_items = 12,
        
        /// <summary>
        /// >> set_collection_properties
        /// Add or change collection properties.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `properties`: Vector of key-value pairs stored as the collection's metadata.
        /// Keys support Latin letters, `-`, `_`, and `.` as symbols.
        /// </summary>
        set_collection_properties = 13,
        
        /// <summary>
        /// >> delete_collection_properties
        /// Delete specified collection properties.
        /// 
        /// # Permissions
        /// 
        /// * Collection Owner
        /// * Collection Admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `property_keys`: Vector of keys of the properties to be deleted.
        /// Keys support Latin letters, `-`, `_`, and `.` as symbols.
        /// </summary>
        delete_collection_properties = 14,
        
        /// <summary>
        /// >> set_token_properties
        /// Add or change token properties according to collection's permissions.
        /// Currently properties only work with NFTs.
        /// 
        /// # Permissions
        /// 
        /// * Depends on collection's token property permissions and specified property mutability:
        /// 	* Collection owner
        /// 	* Collection admin
        /// 	* Token owner
        /// 
        /// See [`set_token_property_permissions`][`Pallet::set_token_property_permissions`].
        /// 
        /// # Arguments
        /// 
        /// * `collection_id: ID of the collection to which the token belongs.
        /// * `token_id`: ID of the modified token.
        /// * `properties`: Vector of key-value pairs stored as the token's metadata.
        /// Keys support Latin letters, `-`, `_`, and `.` as symbols.
        /// </summary>
        set_token_properties = 15,
        
        /// <summary>
        /// >> delete_token_properties
        /// Delete specified token properties. Currently properties only work with NFTs.
        /// 
        /// # Permissions
        /// 
        /// * Depends on collection's token property permissions and specified property mutability:
        /// 	* Collection owner
        /// 	* Collection admin
        /// 	* Token owner
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection to which the token belongs.
        /// * `token_id`: ID of the modified token.
        /// * `property_keys`: Vector of keys of the properties to be deleted.
        /// Keys support Latin letters, `-`, `_`, and `.` as symbols.
        /// </summary>
        delete_token_properties = 16,
        
        /// <summary>
        /// >> set_token_property_permissions
        /// Add or change token property permissions of a collection.
        /// 
        /// Without a permission for a particular key, a property with that key
        /// cannot be created in a token.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `property_permissions`: Vector of permissions for property keys.
        /// Keys support Latin letters, `-`, `_`, and `.` as symbols.
        /// </summary>
        set_token_property_permissions = 17,
        
        /// <summary>
        /// >> create_multiple_items_ex
        /// Create multiple items within a collection with explicitly specified initial parameters.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Anyone if
        ///     * Allow List is enabled, and
        ///     * Address is added to allow list, and
        ///     * MintPermission is enabled (see [`set_collection_permissions`][`Pallet::set_collection_permissions`])
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection to which the tokens would belong.
        /// * `data`: Explicit item creation data.
        /// </summary>
        create_multiple_items_ex = 18,
        
        /// <summary>
        /// >> set_transfers_enabled_flag
        /// Completely allow or disallow transfers for a particular collection.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection.
        /// * `value`: New value of the flag, are transfers allowed?
        /// </summary>
        set_transfers_enabled_flag = 19,
        
        /// <summary>
        /// >> burn_item
        /// Destroy an item.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Current item owner
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection to which the item belongs.
        /// * `item_id`: ID of item to burn.
        /// * `value`: Number of pieces of the item to destroy.
        /// 	* Non-Fungible Mode: An NFT is indivisible, there is always 1 corresponding to an ID.
        ///     * Fungible Mode: The desired number of pieces to burn.
        ///     * Re-Fungible Mode: The desired number of pieces to burn.
        /// </summary>
        burn_item = 20,
        
        /// <summary>
        /// >> burn_from
        /// Destroy a token on behalf of the owner as a non-owner account.
        /// 
        /// See also: [`approve`][`Pallet::approve`].
        /// 
        /// After this method executes, one approval is removed from the total so that
        /// the approved address will not be able to transfer this item again from this owner.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Current token owner
        /// * Address approved by current item owner
        /// 
        /// # Arguments
        /// 
        /// * `from`: The owner of the burning item.
        /// * `collection_id`: ID of the collection to which the item belongs.
        /// * `item_id`: ID of item to burn.
        /// * `value`: Number of pieces to burn.
        /// 	* Non-Fungible Mode: An NFT is indivisible, there is always 1 corresponding to an ID.
        ///     * Fungible Mode: The desired number of pieces to burn.
        ///     * Re-Fungible Mode: The desired number of pieces to burn.
        /// </summary>
        burn_from = 21,
        
        /// <summary>
        /// >> transfer
        /// Change ownership of the token.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Current token owner
        /// 
        /// # Arguments
        /// 
        /// * `recipient`: Address of token recipient.
        /// * `collection_id`: ID of the collection the item belongs to.
        /// * `item_id`: ID of the item.
        ///     * Non-Fungible Mode: Required.
        ///     * Fungible Mode: Ignored.
        ///     * Re-Fungible Mode: Required.
        /// 
        /// * `value`: Amount to transfer.
        /// 	* Non-Fungible Mode: An NFT is indivisible, there is always 1 corresponding to an ID.
        ///     * Fungible Mode: The desired number of pieces to transfer.
        ///     * Re-Fungible Mode: The desired number of pieces to transfer.
        /// </summary>
        transfer = 22,
        
        /// <summary>
        /// >> approve
        /// Allow a non-permissioned address to transfer or burn an item.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Current item owner
        /// 
        /// # Arguments
        /// 
        /// * `spender`: Account to be approved to make specific transactions on non-owned tokens.
        /// * `collection_id`: ID of the collection the item belongs to.
        /// * `item_id`: ID of the item transactions on which are now approved.
        /// * `amount`: Number of pieces of the item approved for a transaction (maximum of 1 for NFTs).
        /// Set to 0 to revoke the approval.
        /// </summary>
        approve = 23,
        
        /// <summary>
        /// >> approve_from
        /// Allow a non-permissioned address to transfer or burn an item from owner's eth mirror.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Current item owner
        /// 
        /// # Arguments
        /// 
        /// * `from`: Owner's account eth mirror
        /// * `to`: Account to be approved to make specific transactions on non-owned tokens.
        /// * `collection_id`: ID of the collection the item belongs to.
        /// * `item_id`: ID of the item transactions on which are now approved.
        /// * `amount`: Number of pieces of the item approved for a transaction (maximum of 1 for NFTs).
        /// Set to 0 to revoke the approval.
        /// </summary>
        approve_from = 24,
        
        /// <summary>
        /// >> transfer_from
        /// Change ownership of an item on behalf of the owner as a non-owner account.
        /// 
        /// See the [`approve`][`Pallet::approve`] method for additional information.
        /// 
        /// After this method executes, one approval is removed from the total so that
        /// the approved address will not be able to transfer this item again from this owner.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// * Current item owner
        /// * Address approved by current item owner
        /// 
        /// # Arguments
        /// 
        /// * `from`: Address that currently owns the token.
        /// * `recipient`: Address of the new token-owner-to-be.
        /// * `collection_id`: ID of the collection the item.
        /// * `item_id`: ID of the item to be transferred.
        /// * `value`: Amount to transfer.
        /// 	* Non-Fungible Mode: An NFT is indivisible, there is always 1 corresponding to an ID.
        ///     * Fungible Mode: The desired number of pieces to transfer.
        ///     * Re-Fungible Mode: The desired number of pieces to transfer.
        /// </summary>
        transfer_from = 25,
        
        /// <summary>
        /// >> set_collection_limits
        /// Set specific limits of a collection. Empty, or None fields mean chain default.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `new_limit`: New limits of the collection. Fields that are not set (None)
        /// will not overwrite the old ones.
        /// </summary>
        set_collection_limits = 26,
        
        /// <summary>
        /// >> set_collection_permissions
        /// Set specific permissions of a collection. Empty, or None fields mean chain default.
        /// 
        /// # Permissions
        /// 
        /// * Collection owner
        /// * Collection admin
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the modified collection.
        /// * `new_permission`: New permissions of the collection. Fields that are not set (None)
        /// will not overwrite the old ones.
        /// </summary>
        set_collection_permissions = 27,
        
        /// <summary>
        /// >> repartition
        /// Re-partition a refungible token, while owning all of its parts/pieces.
        /// 
        /// # Permissions
        /// 
        /// * Token owner (must own every part)
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection the RFT belongs to.
        /// * `token_id`: ID of the RFT.
        /// * `amount`: New number of parts/pieces into which the token shall be partitioned.
        /// </summary>
        repartition = 28,
        
        /// <summary>
        /// >> set_allowance_for_all
        /// Sets or unsets the approval of a given operator.
        /// 
        /// The `operator` is allowed to transfer all tokens of the `owner` on their behalf.
        /// 
        /// # Arguments
        /// 
        /// * `owner`: Token owner
        /// * `operator`: Operator
        /// * `approve`: Should operator status be granted or revoked?
        /// </summary>
        set_allowance_for_all = 29,
        
        /// <summary>
        /// >> force_repair_collection
        /// Repairs a collection if the data was somehow corrupted.
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection to repair.
        /// </summary>
        force_repair_collection = 30,
        
        /// <summary>
        /// >> force_repair_item
        /// Repairs a token if the data was somehow corrupted.
        /// 
        /// # Arguments
        /// 
        /// * `collection_id`: ID of the collection the item belongs to.
        /// * `item_id`: ID of the item.
        /// </summary>
        force_repair_item = 31,
    }
    
    /// <summary>
    /// >> 327 - Variant[pallet_unique.pallet.Call]
    /// Type alias to Pallet, to be used by construct_runtime.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT13, Opal.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT14, Opal.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT15, Opal.NetApi.Generated.Model.up_data_structs.EnumCollectionMode>>(Call.create_collection);
				AddTypeDecoder<Opal.NetApi.Generated.Model.up_data_structs.CreateCollectionData>(Call.create_collection_ex);
				AddTypeDecoder<Opal.NetApi.Generated.Model.up_data_structs.CollectionId>(Call.destroy_collection);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr>>(Call.add_to_allow_list);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr>>(Call.remove_from_allow_list);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Call.change_collection_owner);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr>>(Call.add_collection_admin);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr>>(Call.remove_collection_admin);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Call.set_collection_sponsor);
				AddTypeDecoder<Opal.NetApi.Generated.Model.up_data_structs.CollectionId>(Call.confirm_sponsorship);
				AddTypeDecoder<Opal.NetApi.Generated.Model.up_data_structs.CollectionId>(Call.remove_collection_sponsor);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.up_data_structs.EnumCreateItemData>>(Call.create_item);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Substrate.NetApi.Model.Types.Base.BaseVec<Opal.NetApi.Generated.Model.up_data_structs.EnumCreateItemData>>>(Call.create_multiple_items);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Substrate.NetApi.Model.Types.Base.BaseVec<Opal.NetApi.Generated.Model.up_data_structs.Property>>>(Call.set_collection_properties);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Substrate.NetApi.Model.Types.Base.BaseVec<Opal.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT17>>>(Call.delete_collection_properties);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Base.BaseVec<Opal.NetApi.Generated.Model.up_data_structs.Property>>>(Call.set_token_properties);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Base.BaseVec<Opal.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT17>>>(Call.delete_token_properties);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Substrate.NetApi.Model.Types.Base.BaseVec<Opal.NetApi.Generated.Model.up_data_structs.PropertyKeyPermission>>>(Call.set_token_property_permissions);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.EnumCreateItemExData>>(Call.create_multiple_items_ex);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.set_transfers_enabled_flag);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.burn_item);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.burn_from);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.transfer);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.approve);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.approve_from);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.transfer_from);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.CollectionLimits>>(Call.set_collection_limits);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.CollectionPermissions>>(Call.set_collection_permissions);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.repartition);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.set_allowance_for_all);
				AddTypeDecoder<Opal.NetApi.Generated.Model.up_data_structs.CollectionId>(Call.force_repair_collection);
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.up_data_structs.CollectionId, Opal.NetApi.Generated.Model.up_data_structs.TokenId>>(Call.force_repair_item);
        }
    }
}
