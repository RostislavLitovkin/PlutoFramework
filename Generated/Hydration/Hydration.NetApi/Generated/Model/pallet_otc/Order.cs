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


namespace Hydration.NetApi.Generated.Model.pallet_otc
{
    
    
    /// <summary>
    /// >> 664 - Composite[pallet_otc.Order]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Order : BaseType
    {
        
        /// <summary>
        /// >> owner
        /// </summary>
        public Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 Owner { get; set; }
        /// <summary>
        /// >> asset_in
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 AssetIn { get; set; }
        /// <summary>
        /// >> asset_out
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 AssetOut { get; set; }
        /// <summary>
        /// >> amount_in
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 AmountIn { get; set; }
        /// <summary>
        /// >> amount_out
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 AmountOut { get; set; }
        /// <summary>
        /// >> partially_fillable
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool PartiallyFillable { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Order";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Owner.Encode());
            result.AddRange(AssetIn.Encode());
            result.AddRange(AssetOut.Encode());
            result.AddRange(AmountIn.Encode());
            result.AddRange(AmountOut.Encode());
            result.AddRange(PartiallyFillable.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Owner = new Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Owner.Decode(byteArray, ref p);
            AssetIn = new Substrate.NetApi.Model.Types.Primitive.U32();
            AssetIn.Decode(byteArray, ref p);
            AssetOut = new Substrate.NetApi.Model.Types.Primitive.U32();
            AssetOut.Decode(byteArray, ref p);
            AmountIn = new Substrate.NetApi.Model.Types.Primitive.U128();
            AmountIn.Decode(byteArray, ref p);
            AmountOut = new Substrate.NetApi.Model.Types.Primitive.U128();
            AmountOut.Decode(byteArray, ref p);
            PartiallyFillable = new Substrate.NetApi.Model.Types.Primitive.Bool();
            PartiallyFillable.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
