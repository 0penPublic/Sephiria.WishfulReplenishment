using UnityEngine;

namespace WishfulReplenishment
{
    public static class ReplenishmentService
    {
        public static bool TryReplenish(
            UI_ShopPanel shopPanel, 
            int targetEntityId, 
            out int actualAttempts,
            out int totalAttempts
        )
        {
            actualAttempts = 0;
            totalAttempts = 0;

            var shop = shopPanel.ShopCharacter.GetComponent<UnitAI_NewBasic>();
            if (shop == null)
            {
                return false;
            }

            if (shop.replenishments != null && shop.replenishments.Exists(item => item != null && item.entityID == targetEntityId))
            {
                return true;
            }

            byte maxAttempts = PluginConfig.MaxAttempts;
            for (byte attempt = 0; attempt < maxAttempts; attempt++)
            {
                actualAttempts++;
                shopPanel.DoReplenishment();

                if (shop.replenishments != null && shop.replenishments.Exists(item => item != null && item.entityID == targetEntityId))
                {
                    totalAttempts = shop.replenishmentTryCount;
                    return true;
                }
            }
            totalAttempts = shop.replenishmentTryCount;
            return false;
        }
    }
}
