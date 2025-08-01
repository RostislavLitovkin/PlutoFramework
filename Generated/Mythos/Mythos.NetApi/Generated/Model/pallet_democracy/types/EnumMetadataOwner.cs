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


namespace Mythos.NetApi.Generated.Model.pallet_democracy.types
{
    
    
    /// <summary>
    /// >> MetadataOwner
    /// </summary>
    public enum MetadataOwner
    {
        
        /// <summary>
        /// >> External
        /// </summary>
        External = 0,
        
        /// <summary>
        /// >> Proposal
        /// </summary>
        Proposal = 1,
        
        /// <summary>
        /// >> Referendum
        /// </summary>
        Referendum = 2,
    }
    
    /// <summary>
    /// >> 71 - Variant[pallet_democracy.types.MetadataOwner]
    /// </summary>
    public sealed class EnumMetadataOwner : BaseEnumRust<MetadataOwner>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumMetadataOwner()
        {
				AddTypeDecoder<BaseVoid>(MetadataOwner.External);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(MetadataOwner.Proposal);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(MetadataOwner.Referendum);
        }
    }
}
