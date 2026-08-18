using BepInEx;
using HarmonyLib;

namespace WishfulReplenishment
{
    [BepInPlugin("mba.vm.wishfulreplenishment", "Wishful Replenishment", "0.1")]
    public class WishfulReplenishment : BaseUnityPlugin
    {
        private void Awake()
        {
            PluginConfig.Initialize(this);

            var harmony = new Harmony(Info.Metadata.GUID);
            harmony.PatchAll();
            Logger.LogInfo("Wishful Replenishment is loaded!");
        }
    }
}