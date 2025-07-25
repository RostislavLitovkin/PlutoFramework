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


namespace Opal.NetApi.Generated.Model.up_data_structs
{
    
    
    /// <summary>
    /// >> 343 - Composite[up_data_structs.CollectionPermissions]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CollectionPermissions : BaseType
    {
        
        /// <summary>
        /// >> access
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Opal.NetApi.Generated.Model.up_data_structs.EnumAccessMode> Access { get; set; }
        /// <summary>
        /// >> mint_mode
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.Bool> MintMode { get; set; }
        /// <summary>
        /// >> nesting
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Opal.NetApi.Generated.Model.up_data_structs.NestingPermissions> Nesting { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CollectionPermissions";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Access.Encode());
            result.AddRange(MintMode.Encode());
            result.AddRange(Nesting.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Access = new Substrate.NetApi.Model.Types.Base.BaseOpt<Opal.NetApi.Generated.Model.up_data_structs.EnumAccessMode>();
            Access.Decode(byteArray, ref p);
            MintMode = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.Bool>();
            MintMode.Decode(byteArray, ref p);
            Nesting = new Substrate.NetApi.Model.Types.Base.BaseOpt<Opal.NetApi.Generated.Model.up_data_structs.NestingPermissions>();
            Nesting.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
