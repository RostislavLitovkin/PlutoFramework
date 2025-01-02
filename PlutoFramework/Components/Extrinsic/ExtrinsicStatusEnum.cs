using System;
namespace PlutoFramework.Components.Extrinsic
{
	public enum ExtrinsicStatusEnum
	{
        NothingUpdateUIBug,
		Submitting,
		Error,
        Pending,
        InBlockSuccess,
        InBlockFailed,
        FinalizedSuccess,
        FinalizedFailed,
        Dropped,
        Unknown,
	}
}

