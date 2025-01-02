using KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Numerics;
using Unique.NetApi.Generated.Model.primitive_types;
using U256 = Substrate.NetApi.Model.Types.Primitive.U256;

namespace UniqueryPlus.EVM
{
    public static class Helpers
    {
        /// <summary>
        /// Method for Unique network
        /// </summary>
        public static (uint CollectionId, uint Id) GetNftIdFromNftAddress(string address)
        {
            var collectionId = new U32();
            collectionId.Create(Utils.HexToByteArray(address.Substring(26, 8)).Reverse().ToArray());

            var id = new U32();
            id.Create(Utils.HexToByteArray(address.Substring(34, 8)).Reverse().ToArray());

            return (collectionId, id);
        }

        /// <summary>
        /// Method for Unique network
        /// </summary>
        public static string GetNftAddress(uint collectionId, uint id)
        {
            return $"{Constants.EVM_NFT_ADDRESS_PREFIX}{Utils.Bytes2HexString(BitConverter.GetBytes(collectionId).Reverse().ToArray(), Utils.HexStringFormat.Pure).ToLower()}{Utils.Bytes2HexString(BitConverter.GetBytes(id).Reverse().ToArray(), Utils.HexStringFormat.Pure).ToLower()}";
        }

        /// <summary>
        /// Method for Unique network
        /// </summary>
        public static string GetCollectionAddress(uint collectionId)
        {
            return $"0x17c4e6453cc49aaaaeaca894e6d9683e{Utils.Bytes2HexString(BitConverter.GetBytes(collectionId).Reverse().ToArray(), Utils.HexStringFormat.Pure).ToLower()}";
        }

        private static BigInteger SubstrateAddressToUint256(string address) => new BigInteger(Utils.GetPublicKeyFrom(address), true, true);

        public static Unique.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr ToUniqueCrossAccountIdRepr(string address)
        {
            var crossAccountId = new Unique.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr();

            if (address[0..2] == "0x")
            {
                var h160accountId = new H160();
                h160accountId.Create(Utils.HexToByteArray(address));

                crossAccountId.Create(Unique.NetApi.Generated.Model.pallet_evm.account.BasicCrossAccountIdRepr.Ethereum, h160accountId);
            }
            else
            {
                var accountId = new AccountId32();
                accountId.Create(Utils.GetPublicKeyFrom(address));

                crossAccountId.Create(Unique.NetApi.Generated.Model.pallet_evm.account.BasicCrossAccountIdRepr.Substrate, accountId);
            }

            return crossAccountId;
        }

        public static Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr ToOpalCrossAccountIdRepr(string address)
        {
            var crossAccountId = new Opal.NetApi.Generated.Model.pallet_evm.account.EnumBasicCrossAccountIdRepr();

            if (address[0..2] == "0x")
            {
                var h160accountId = new H160();
                h160accountId.Create(Utils.HexToByteArray(address));

                crossAccountId.Create(Opal.NetApi.Generated.Model.pallet_evm.account.BasicCrossAccountIdRepr.Ethereum, h160accountId);
            }
            else
            {
                var accountId = new AccountId32();
                accountId.Create(Utils.GetPublicKeyFrom(address));

                crossAccountId.Create(Opal.NetApi.Generated.Model.pallet_evm.account.BasicCrossAccountIdRepr.Substrate, accountId);
            }

            return crossAccountId;
        }

        public static CrossAddress ToCrossAddress(string address)
            {
                return address[0..2] switch
                {
                    "0x" => new CrossAddress
                    {
                        Eth = address,
                        Sub = 0,
                    },
                    _ => new CrossAddress
                    {
                        Eth = "0x0000000000000000000000000000000000000000",
                        Sub = EVM.Helpers.SubstrateAddressToUint256(address),
                    }
                };
            }

            public static Method GetUniqueEVMCallMethod(string substrateAddress, string contractAddress, byte[] calldata, BigInteger? amountToSend)
            {
                int p = 0;
                var source = new Unique.NetApi.Generated.Model.primitive_types.H160();
                source.Decode(Utils.GetPublicKeyFrom(substrateAddress), ref p);

                p = 0;
                var target = new Unique.NetApi.Generated.Model.primitive_types.H160();
                target.Decode(Utils.HexToByteArray(contractAddress), ref p);

                p = 0;
                BaseVec<U8> input = new BaseVec<U8>(calldata.Select(v => new U8(v)).ToArray());

                p = 0;
                var value = new Unique.NetApi.Generated.Model.primitive_types.U256();
                var valueArray = new Unique.NetApi.Generated.Types.Base.Arr4U64();
                valueArray.Decode(new U256(amountToSend ?? 0).Encode(), ref p);
                value.Value = valueArray;

                // Value taken from https://unique.subscan.io/extrinsic/5908919-2
                var gasLimit = new U64(200_000);

                // Value taken from https://unique.subscan.io/extrinsic/5908919-2
                p = 0;
                var maxFeePerGas = new Unique.NetApi.Generated.Model.primitive_types.U256();
                maxFeePerGas.Decode(Utils.HexToByteArray("0x2bbc2938b4010000000000000000000000000000000000000000000000000000"), ref p);

                var marPriorityFeePerGas = new BaseOpt<Unique.NetApi.Generated.Model.primitive_types.U256>();

                var nonce = new BaseOpt<Unique.NetApi.Generated.Model.primitive_types.U256>();

                var accessList = new Substrate.NetApi.Model.Types.Base.BaseVec<BaseTuple<Unique.NetApi.Generated.Model.primitive_types.H160, BaseVec<Unique.NetApi.Generated.Model.primitive_types.H256>>>([]);

                return Unique.NetApi.Generated.Storage.EVMCalls.Call(source, target, input, value, gasLimit, maxFeePerGas, maxFeePerGas, nonce, accessList);
            }

            public static Method GetOpalEVMCallMethod(string substrateAddress, string contractAddress, byte[] calldata, BigInteger? amountToSend)
            {
                Console.WriteLine("Call data: " + Utils.Bytes2HexString(calldata));
                int p = 0;
                var source = new Opal.NetApi.Generated.Model.primitive_types.H160();
                source.Decode(Utils.GetPublicKeyFrom(substrateAddress), ref p);

                p = 0;
                var target = new Opal.NetApi.Generated.Model.primitive_types.H160();
                target.Decode(Utils.HexToByteArray(contractAddress), ref p);

                BaseVec<U8> input = new BaseVec<U8>(calldata.Select(v => new U8(v)).ToArray());

                p = 0;
                var value = new Opal.NetApi.Generated.Model.primitive_types.U256();
                var valueArray = new Opal.NetApi.Generated.Types.Base.Arr4U64();
                valueArray.Decode(new U256(amountToSend ?? 0).Encode(), ref p);
                value.Value = valueArray;

                // Value taken from https://unique.subscan.io/extrinsic/5908919-2
                var gasLimit = new U64(200_000);

                // Value taken from https://unique.subscan.io/extrinsic/5908919-2
                p = 0;
                var maxFeePerGas = new Opal.NetApi.Generated.Model.primitive_types.U256();
                maxFeePerGas.Decode(Utils.HexToByteArray("0x2bbc2938b4010000000000000000000000000000000000000000000000000000"), ref p);

                var marPriorityFeePerGas = new BaseOpt<Opal.NetApi.Generated.Model.primitive_types.U256>();

                var nonce = new BaseOpt<Opal.NetApi.Generated.Model.primitive_types.U256>();

                var accessList = new BaseVec<BaseTuple<Opal.NetApi.Generated.Model.primitive_types.H160, BaseVec<Opal.NetApi.Generated.Model.primitive_types.H256>>>([]);

                return Opal.NetApi.Generated.Storage.EVMCalls.Call(source, target, input, value, gasLimit, maxFeePerGas, maxFeePerGas, nonce, accessList);
            }
        }
    }
