using System;
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
    }

    public static class AppConfigurationModel
    {
        public static string Location = DefaultAppConfiguration.LOCATION;
    }
}
