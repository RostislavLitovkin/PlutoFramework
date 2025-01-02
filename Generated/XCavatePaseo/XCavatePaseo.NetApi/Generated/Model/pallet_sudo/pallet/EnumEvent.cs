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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_sudo.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Sudid
        /// A sudo call just took place.
        /// </summary>
        Sudid = 0,
        
        /// <summary>
        /// >> KeyChanged
        /// The sudo key has been updated.
        /// </summary>
        KeyChanged = 1,
        
        /// <summary>
        /// >> KeyRemoved
        /// The key was permanently removed.
        /// </summary>
        KeyRemoved = 2,
        
        /// <summary>
        /// >> SudoAsDone
        /// A [sudo_as](Pallet::sudo_as) call just took place.
        /// </summary>
        SudoAsDone = 3,
    }
    
    /// <summary>
    /// >> 84 - Variant[pallet_sudo.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Types.Base.EnumResult>(Event.Sudid);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.KeyChanged);
				AddTypeDecoder<BaseVoid>(Event.KeyRemoved);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Types.Base.EnumResult>(Event.SudoAsDone);
        }
    }
}
