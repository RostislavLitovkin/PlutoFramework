using PolkadotPeople.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi;

namespace PlutoFramework.Model
{
	public class IdentityModel
	{
		public static async Task<OnChainIdentity?> GetIdentityForAddressAsync(PolkadotPeople.NetApi.Generated.SubstrateClientExt client, string address, CancellationToken token)
		{
			try
			{
				if (address == null)
				{
					return null;
				}

				var account32 = new AccountId32();
				account32.Create(Utils.GetPublicKeyFrom(address));

				var identity = await client.IdentityStorage.IdentityOf(account32, null, token);

				if (identity == null)
				{
					return null;
				}

				Judgement finalJudgement = Judgement.Unknown;

                foreach (Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.EnumJudgement> thing in identity.Judgements.Value.Value)
				{
					switch (((PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.EnumJudgement)thing.Value[1]).Value)
					{
						case PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.Judgement.Unknown:
							finalJudgement = Judgement.Unknown;
							break;
						case PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.Judgement.FeePaid:
							// fee paid
							break;
						case PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.Judgement.Reasonable:
							finalJudgement = Judgement.Reasonable;
							break;
						case PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.Judgement.KnownGood:
							finalJudgement = Judgement.KnownGood;
							break;
						case PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.Judgement.OutOfDate:
							finalJudgement = Judgement.OutOfDate;
							break;
						case PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.Judgement.LowQuality:
							finalJudgement = Judgement.LowQuality;
							break;
						case PolkadotPeople.NetApi.Generated.Model.pallet_identity.types.Judgement.Erroneous:
							finalJudgement = Judgement.Erroneous;
							break;
						default:
							finalJudgement = Judgement.Unknown;
							break;
					}
				}

				return new OnChainIdentity
				{
					DisplayName = System.Text.Encoding.UTF8.GetString(identity.Info.Display.Value2.Encode()),
					FinalJudgement = finalJudgement,
				};
			}
			catch
			{
				return null;
			}
		}
	}

	public class OnChainIdentity
	{
		public required string DisplayName { get; set; }
		public Judgement FinalJudgement { get; set; }
		//public required string LegalName { get; set; }
		//public Endpoint Endpoint { get; set; }
	}

	public enum Judgement
	{
		Unknown,
		Reasonable,
        KnownGood,
        OutOfDate,
        LowQuality,
        Erroneous,
    }
}

