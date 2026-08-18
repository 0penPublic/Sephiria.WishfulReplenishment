using BepInEx;
using BepInEx.Configuration;

namespace WishfulReplenishment
{
    public static class PluginConfig
    {
        private const byte DefaultMaxAttempts = 128;
        private static ConfigEntry<byte>? maxAttemptsEntry;

        public static byte MaxAttempts => maxAttemptsEntry?.Value ?? DefaultMaxAttempts;

        public static void Initialize(BaseUnityPlugin plugin)
        {
            maxAttemptsEntry = plugin.Config.Bind(
                "General",
                "MaxAttempts",
                DefaultMaxAttempts,
                new ConfigDescription(
                    "Maximum number of replenishment attempts before giving up.",
                    new AcceptableValueRange<byte>(1, byte.MaxValue)));
        }
    }
}
