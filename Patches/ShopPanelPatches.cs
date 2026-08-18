using HarmonyLib;
using UnityEngine.EventSystems;

namespace WishfulReplenishment.Patches
{
    public static class ShopPanelPatches
    {
        public static UI_JournalPanel? JournalPanel { get; private set; }
        public static UI_ShopPanel? ShopPanel { get; private set; }
        public static bool IsSelectingForReplenishment { get; private set; }
        public static bool DisableReplenishmentUpdate { get; private set; }

        [HarmonyPatch(typeof(UI_ShopPanel))]
        public static class ShopPanel_Patch
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(UI_ShopPanel.OnOpened))]
            public static void OnOpened_Postfix(UI_ShopPanel __instance)
            {
                ShopPanel = __instance;
                if (__instance.replenishmentButton == null)
                {
                    return;
                }

                var listener = __instance.replenishmentButton.GetComponent<MiddleClickListener>()
                    ?? __instance.replenishmentButton.gameObject.AddComponent<MiddleClickListener>();

                listener.onMiddleClick = () =>
                {
                    JournalPanel = UIManager.Instance.GetElement<UI_JournalPanel>();
                    if (JournalPanel == null)
                    {
                        return;
                    }

                    if (JournalPanel.IsOpened)
                    {
                        CloseJournal();
                    }
                    else
                    {
                        IsSelectingForReplenishment = true;
                        JournalPanel.Open();
                        JournalPanel.transform.SetAsLastSibling();
                        JournalPanel.SelectTab(0);
                    }
                };
            }

            [HarmonyPostfix]
            [HarmonyPatch(nameof(UI_ShopPanel.OnClosed))]
            public static void OnClosed_Postfix()
            {
                CloseJournal();
                ShopPanel = null;
            }

            [HarmonyPrefix]
            [HarmonyPatch("UpdateReplenishmentIcon")]
            public static bool UpdateReplenishmentIcon_Prefix()
            {
                return !DisableReplenishmentUpdate;
            }

            public static void CloseJournal()
            {
                IsSelectingForReplenishment = false;
                if (JournalPanel != null)
                {
                    JournalPanel.Close();
                    JournalPanel = null;
                }
            }
        }

        [HarmonyPatch(typeof(UI_ItemIcon), nameof(UI_ItemIcon.OnPointerClick))]
        public static class ItemIcon_Click_Patch
        {
            [HarmonyPostfix]
            public static void Postfix(UI_ItemIcon __instance, PointerEventData eventData)
            {
                if (eventData.button != PointerEventData.InputButton.Left) return;
                if (!IsSelectingForReplenishment || ShopPanel == null) return;

                int targetEntityId = __instance.Item.entityID;
                string itemName = __instance.Item.Name;
                if (ShopPanel == null || ShopPanel.ShopCharacter == null) return;

                ShopPanel_Patch.CloseJournal();

                DisableReplenishmentUpdate = true;
                try
                {
                    int actualAttempts;
                    int totalAttempts;
                    bool found = ReplenishmentService.TryReplenish(
                        (UI_ShopPanel)ShopPanel,
                        targetEntityId,
                        out actualAttempts,
                        out totalAttempts
                    );

                    if (found)
                    {
                        UIManager.Instance.GetElement<UI_SystemMessage>()?
                            .Open($"Successfully replenished item {itemName} after {actualAttempts}({totalAttempts}) attempts.", 3f, false);
                    }
                    else
                    {
                        UIManager.Instance.GetElement<UI_SystemMessage>()?
                            .Open($"Failed to replenish item {itemName} after {totalAttempts} attempts.", 3f, false);
                    }
                }
                finally
                {
                    DisableReplenishmentUpdate = false;
                    Traverse.Create(ShopPanel).Method("UpdateReplenishmentIcon").GetValue();
                }
            }
        }
    }
}
