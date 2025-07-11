﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFramework.Model
{
    /// <summary>
    /// Provide default values here
    /// </summary>
    public class DefaultAppConfiguration
    {
        public const double POUNDS_TO_USD = 0.82;

        public const string LOCATION = "UK";

        public const uint BOTTOM_CARD_POPUP_ANIMATION_DURATION = 500;

        public const string CURRENCY_FORMAT = "{0:0}";

        public const string? TRANSACTION_ANALYZER_PALLET_CALL_NAME_SUBSTITUTION = "Transaction detail";

        public const bool DISPLAY_NETWORKS = false;
    }

    public static class AppConfigurationModel
    {
        public static string Location = DefaultAppConfiguration.LOCATION;
    }
}
