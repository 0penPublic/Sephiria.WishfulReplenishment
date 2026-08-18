# Wishful Replenishment

This project is a Unity mod developed with BepInEx and Harmony for the Sephiria game. It implements directed automatic replenishment in the shop: the player can select a target item from the journal or item list, and the mod will repeatedly trigger shop replenishment until that specific item appears.

## Overview

The mod is designed for a shop-based gameplay loop where the player wants to refresh specific items efficiently without manually repeating the same shop refresh actions. It focuses on targeted item acquisition by automating the replenishment process.

## Features

- Adds a middle-click shortcut on the shop replenishment button.
- Opens the journal to select the desired target item.
- Automatically triggers replenishment repeatedly until the chosen item is found.
- Displays success or failure feedback through the in-game system message UI.
- Uses Harmony patching to hook into the relevant shop and UI lifecycle methods.

## Workflow

1. Open the shop.
2. Use the middle-click shortcut on the replenishment button.
3. Select the target item from the journal.
4. The mod automatically performs repeated replenishment attempts.
5. When the target item is found, it reports the result through the system message box.

## Technical notes

This is a BepInEx plugin built on Harmony for runtime patching. The implementation separates responsibilities into:

- `WishfulReplenishment.cs` — plugin bootstrap and Harmony startup.
- `Config/PluginConfig.cs` — configuration binding.
- `Services/ReplenishmentService.cs` — replenishment execution logic.
- `Patches/ShopPanelPatches.cs` — Harmony patch hooks for shop and UI behavior.
- `UI/MiddleClickListener.cs` — middle-click interaction listener.

## Plugin identity

Wishful Replenishment is a targeted shop replenishment utility mod meant to streamline item refresh and acquisition in a controlled, repeatable manner.
