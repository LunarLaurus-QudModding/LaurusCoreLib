using LaurusCoreLib.Net.Laurus.Config;
using LaurusCoreLib.Net.Laurus.Enums;

namespace LaurusCoreLib.Net.Laurus.Logging
{

    public class LL
    {
        public static void Info(string msg, LogCategory category)
        {
            if (!ConfigHandler.GLOBAL_LOGGING_ENABLED ||
                (!ConfigHandler.GLOBAL_LOGGING_DEBUG_ENABLED && category == LogCategory.Debug) ||
                string.IsNullOrEmpty(msg))
            {
                if (string.IsNullOrEmpty(msg))
                {
                    UnityEngine.Debug.LogWarning("[Laurus] Attempted to log an empty or null message.");
                }
                return;
            }

            string prefixText = $"[Laurus][{category.ToString().ToUpper()}] ";
            string modifiedS = prefixText + msg;

            XRL.Messages.MessageQueue.AddPlayerMessage(modifiedS);
            UnityEngine.Debug.LogError(modifiedS);
        }
    }
}