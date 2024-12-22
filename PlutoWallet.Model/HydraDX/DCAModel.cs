﻿using Polkadot.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using static Substrate.NetApi.Model.Meta.Storage;
using System.Numerics;
using Substrate.NetApi.Model.Types.Base;
using Hydration.NetApi.Generated;

namespace PlutoWallet.Model.HydraDX
{
	public class DCAModel
	{
        private const long TICKS_PER_BLOCK = 6_0000000; // 12 seconds
        public static async Task<List<DCAPosition>> GetDCAPositionsAsync(SubstrateClientExt client, string substrateAddress, CancellationToken token)
        {
            var account32 = new AccountId32();
            account32.Create(Utils.GetPublicKeyFrom(substrateAddress));

            var keyBytes = RequestGenerator.GetStorageKeyBytesHash("DCA", "ScheduleOwnership");

            byte[] prefix = keyBytes.Concat(HashExtension.Hash(Hasher.BlakeTwo128Concat, account32.Encode())).ToArray();

            string prefixString = Utils.Bytes2HexString(prefix);

            byte[] startKey = null;

            List<U32> positionIds;

            var keysPaged = await client.State.GetKeysPagedAsync(prefix, 1000, startKey, string.Empty, token);

            if (keysPaged == null || !keysPaged.Any())
            {
                return new List<DCAPosition>();
            }
            else
            {
                positionIds = keysPaged.Select(p => HashModel.GetU32FromTwox_64Concat(p.ToString().Substring(162))).ToList();
            }

            List<DCAPosition> result = new List<DCAPosition>();

            foreach (U32 positionId in positionIds)
            {

                var schedule = await client.DCAStorage.Schedules(positionId, null, token);

                if (schedule.Order.Value.ToString() != "Sell")
                {
                    continue;
                }

                U128 amount = await client.DCAStorage.RemainingAmounts(positionId, null, token);

                int i = 0;
                var scheduleOrder = new BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9>();
                scheduleOrder.Decode(schedule.Order.Value2.Encode(), ref i);

                var fromAsset = await client.AssetRegistryStorage.Assets((U32)scheduleOrder.Value[0], null, token);

                var toAsset = await client.AssetRegistryStorage.Assets((U32)scheduleOrder.Value[1], null, token);

                // Get the time left for the DCA order
                BigInteger times = (schedule.TotalAmount.Value - amount.Value) / ((U128)scheduleOrder.Value[2]).Value + 1;

                BigInteger blocks = times * schedule.Period.Value;

                Console.WriteLine("Times: " + times);

                Console.WriteLine("Blocks: " + blocks);

                TimeSpan time = new TimeSpan((long)blocks * TICKS_PER_BLOCK + 3600 * TICKS_PER_BLOCK);

                Console.WriteLine("Seconds: " + time.TotalSeconds);

                result.Add(new DCAPosition
                {
                    Amount = (double)amount.Value / Math.Pow(10, fromAsset.Decimals.Value),
                    FromSymbol = Model.ToStringModel.VecU8ToString(fromAsset.Symbol.Value.Value),
                    ToSymbol = Model.ToStringModel.VecU8ToString(toAsset.Symbol.Value.Value),
                    RemainingDays = time.Days,
                    RemainingHours = time.Hours,
                });
            }

            return result;
        }
    }

    public class DCAPosition
    {
        public double Amount { get; set; }
        public string FromSymbol { get; set; }
        public string ToSymbol { get; set; }
        public int RemainingDays { get; set; }
        public int RemainingHours { get; set; }
    }
}

