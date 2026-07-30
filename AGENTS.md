Include ..\AGENTS.md

# List All Goods — Mod-Specific Agent Instructions

## Identity
- **Assembly:** `listallgoods`
- **Namespace:** `Calloatti.ListAllGoods`
- **Framework:** Harmony, Bindito DI
- **Publicizer:** includes `Timberborn.ResourceCountingSystem`
- **ModId:** `Calloatti.ListAllGoods`
- **Min Game Version:** 1.0.12.10 — uses `timberborn-decompiled-1.0.*`

## What This Mod Does
Enhances the goods display to list ALL goods (including ones with zero stock) instead of only showing goods currently in storage.

## Source Architecture (`Version-1.0/Source/`)

| File | Role |
|---|---|
| `ModStarter.cs` | Entry point — `IModStarter` |
| `ModPatches.cs` | Harmony patches for goods listing behavior |
