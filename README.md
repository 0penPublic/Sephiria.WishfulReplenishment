# Wishful Replenishment

A small BepInEx plugin for the Sephiria shop experience, inspired by the feeling of a quiet market where every stall keeps a secret wish, and every merchant is ready to restock with a little more grace.

## What it does

- Adds a middle-click shortcut on the replenishment button in the shop UI.
- Opens the journal to let you choose an item to replenish.
- Replenishes the selected item automatically.
- Shows success or failure feedback through the in-game system message box.

## Functional flow

1. Open the shop.
2. Middle-click the replenishment button.
3. The journal opens and the player can choose an item.
4. Click the desired item to trigger replenishment.
5. The plugin tries to restock and reports the result.

## Project structure

- `WishfulReplenishment.cs` — plugin entry point and Harmony bootstrap.
- `Config/PluginConfig.cs` — BepInEx configuration bindings.
- `Services/ReplenishmentService.cs` — replenishment logic.
- `Patches/ShopPanelPatches.cs` — Harmony patch implementations.
- `UI/MiddleClickListener.cs` — middle-click event hook.

## Plugin identity

The plugin is named:

Wishful Replenishment

It is designed to feel like a soft, hopeful little ritual in a market full of wishes, restocks, and quiet miracles.
