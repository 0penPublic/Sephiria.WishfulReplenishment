# Wishful Replenishment

A BepInEx + Harmony client-side mod for [Sephiria](https://store.steampowered.com/app/2436940/).

Wishful Replenishment is a targeted shop-refresh utility designed to help players efficiently acquire a specific item by simulating the same manual replenishment flow used in the shop UI. The mod does not modify server-authoritative fields or privileged game state; it only triggers the same client-side refresh actions a player would normally perform by hand.

## Why this mod

In a shop system where item refresh is repetitive, this mod removes the friction of manually retrying the same action over and over. It is focused on one thing: efficiently targeting a specific item by repeatedly triggering the replenishment flow and validating the result.

## Notes

This is a client-side mod that simulates the same manual replenishment flow available to the player. It does not overwrite server-owned or protected fields, so it is suitable for multiplayer scenarios where the player is not the host or room owner.

## Features

- Middle-click shortcut on the shop replenishment button
- Journal-based item selection for target acquisition
- Automatic repeated replenishment attempts until the selected item appears
- Success/failure feedback through the in-game system message UI
- Harmony-based patching for shop and UI integration
- Safe for non-host multiplayer use because it does not alter protected server-side fields

## How it works

1. Open the shop.
2. Use the middle-click action on the replenishment button.
3. Choose the target item from the journal.
4. The mod repeatedly refreshes the shop until the item is acquired.
5. A result message is shown once the process completes.

## Project structure

- `WishfulReplenishment.cs` — entry point and Harmony bootstrap
- `Config/PluginConfig.cs` — configuration binding
- `Services/ReplenishmentService.cs` — replenishment logic
- `Patches/ShopPanelPatches.cs` — Harmony patch hooks
- `UI/MiddleClickListener.cs` — middle-click interaction handling

## Requirements

- BepInEx
- Harmony
- Unity-based game environment compatible with the project

## Supported Game

- [Sephiria on Steam](https://store.steampowered.com/app/2436940/)

## Notes

This mod is intended for players who want a faster, more controlled replenishment workflow when targeting a specific item in the shop. It is designed to reduce repetitive manual refresh actions without modifying server-authoritative state, which makes it suitable for use as a client-side utility in multiplayer sessions.
