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


namespace XCavatePaseo.NetApi.Generated.Model.generic_runtime_template
{
    
    
    /// <summary>
    /// >> OriginCaller
    /// </summary>
    public enum OriginCaller
    {
        
        /// <summary>
        /// >> system
        /// </summary>
        system = 0,
        
        /// <summary>
        /// >> Origins
        /// </summary>
        Origins = 18,
        
        /// <summary>
        /// >> PolkadotXcm
        /// </summary>
        PolkadotXcm = 31,
        
        /// <summary>
        /// >> CumulusXcm
        /// </summary>
        CumulusXcm = 32,
        
        /// <summary>
        /// >> Void
        /// </summary>
        Void = 4,
    }
    
    /// <summary>
    /// >> 116 - Variant[generic_runtime_template.OriginCaller]
    /// </summary>
    public sealed class EnumOriginCaller : BaseEnumRust<OriginCaller>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumOriginCaller()
        {
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.frame_support.dispatch.EnumRawOrigin>(OriginCaller.system);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.generic_runtime_template.configs.governance.origins.pallet_custom_origins.EnumOrigin>(OriginCaller.Origins);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.pallet_xcm.pallet.EnumOrigin>(OriginCaller.PolkadotXcm);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.cumulus_pallet_xcm.pallet.EnumOrigin>(OriginCaller.CumulusXcm);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVoid>(OriginCaller.Void);
        }
    }
}
