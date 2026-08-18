# Wishful Replenishment

A BepInEx + Harmony mod for [Sephiria](https://store.steampowered.com/app/2436940/).

Wishful Replenishment is a targeted shop-refresh utility designed to help players quickly restock or refresh specific items in the shop. Instead of manually repeating the refresh loop, the mod lets you pick a desired item and automates the replenishment flow until it appears.

## Why this mod

In a shop system where item refresh is repetitive, this mod removes the friction of manually retrying the same action over and over. It is focused on one thing: efficiently obtaining a specific item by repeatedly triggering replenishment and validating the result.

## Features

- Middle-click shortcut on the shop replenishment button
- Journal-based item selection for target acquisition
- Automatic repeated replenishment attempts until the selected item appears
- Success/failure feedback through the in-game system message UI
- Harmony-based patching for shop and UI integration

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

This project is intended for players who want a faster, more controlled replenishment workflow when targeting a specific item in the shop. It is designed to reduce repetitive manual refresh actions while preserving the game’s normal flow.
