﻿using System;
using Ajuna.NetApi.Attributes;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;

namespace PlutoWallet.Types.AjunaExtTypes
{
    /// <summary>
    /// >> 0 - Composite[sp_core.crypto.AccountId32]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class AccountId32 : BaseType
    {

        /// <summary>
        /// >> value
        /// </summary>
        private AjunaExample.NetApiExt.Generated.Types.Base.Arr32U8 _value;

        public AjunaExample.NetApiExt.Generated.Types.Base.Arr32U8 Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public override string TypeName()
        {
            return "AccountId32";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new AjunaExample.NetApiExt.Generated.Types.Base.Arr32U8();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}

