using PlutoFramework.Components.WebView;

namespace PlutoFramework.Model
{
    public class ExtensionWebViewModel
    {

        public static uint NextTabId = 0;

        public static Dictionary<uint, DAppInfo> TabInfos = new Dictionary<uint, DAppInfo>();

        public static Dictionary<string, bool> ApprovedUrls = new Dictionary<string, bool>();
        public static uint GetNextTabId()
        {
            var nextTabId = NextTabId;

            NextTabId++;

            return nextTabId;
        }
    }
}
