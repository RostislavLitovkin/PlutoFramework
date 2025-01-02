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


namespace Mythos.NetApi.Generated.Model.xcm.v3
{
    
    
    /// <summary>
    /// >> 284 - Composite[xcm.v3.PalletInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PalletInfo : BaseType
    {
        
        /// <summary>
        /// >> index
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Index { get; set; }
        /// <summary>
        /// >> name
        /// </summary>
        public Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT10 Name { get; set; }
        /// <summary>
        /// >> module_name
        /// </summary>
        public Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT10 ModuleName { get; set; }
        /// <summary>
        /// >> major
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Major { get; set; }
        /// <summary>
        /// >> minor
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Minor { get; set; }
        /// <summary>
        /// >> patch
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Patch { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PalletInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Name.Encode());
            result.AddRange(ModuleName.Encode());
            result.AddRange(Major.Encode());
            result.AddRange(Minor.Encode());
            result.AddRange(Patch.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Index.Decode(byteArray, ref p);
            Name = new Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT10();
            Name.Decode(byteArray, ref p);
            ModuleName = new Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT10();
            ModuleName.Decode(byteArray, ref p);
            Major = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Major.Decode(byteArray, ref p);
            Minor = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Minor.Decode(byteArray, ref p);
            Patch = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Patch.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
