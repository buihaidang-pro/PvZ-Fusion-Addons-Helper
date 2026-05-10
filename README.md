# PvZ Fusion Helper

PvZ Fusion Helper is a **MelonLoader Mod Suite** for Plants vs. Zombies Fusion (v3.6.1). It provides addons that enhance gameplay, add quality-of-life features, and unlock sandbox tools so you can play the fusion game *your* way.

---

## Installation

1. Install [MelonLoader](https://melonwiki.xyz/#/modders/quickstart) for PvZ Fusion.
2. [Download](https://github.com/buihaidang-pro/PvZ-Fusion-Addons-Helper/releases/tag/v1.1.0) the latest mod DLLs from the GitHub Releases page **or** build them yourself (see [Building from Source](#building-from-source) below).
3. Copy the `.dll` files you want into your game's `Mods` folder:
   ```
   <Game Directory>\Mods\
   ```
4. Launch the game — MelonLoader will load all mods automatically.

---

## Addons

### 🛠️ Quality of Life

#### Better Game Speed
Adjust game speed in real-time with customizable hotkeys.

| Key | Action |
|-----|--------|
| **`,`** (Comma) | Decrease speed by 0.5× (min 1×) |
| **`.`** (Period) | Pause the game |
| **`/`** (Slash) | Increase speed by 0.5× (max 3×) |

All keybindings are configurable via the `Better_Game_Speed` MelonPreferences category.

#### Better Pot Fusion
Hold **Left Shift** and click a Flower Pot plant with a seed in your cursor to fuse them into a potted variant.

**Recipes:**

| Pot + | Result |
|---|---|
| Cabbage-pult | Silver Cabbage |
| Kernel-pult | Golden Kernel |
| Garlic | Garlic Pot |
| Umbrella Leaf | Umbrella Pot |
| Marigold | Silver Marigold |
| Melon-pult | Golden Melon |
| Sunflower | Sun-nut hybrid |

#### Better Pumpkin Fusion
Hold **Left Shift** and click a Pumpkin with a seed to fuse them.

**Recipes:**

| Pumpkin + | Result |
|---|---|
| Plantern | Jack O'Lantern |
| Cactus | Thorngourd |
| Blover | Windgourd |
| Starfruit | Stargourd |
| Magnet-shroom | Starjoker |
| Cherry Bomb | PumpKaboom |
| Potato Mine | Miner Pumpkin |

#### No Craters
Prevents Doom-shroom and Ice Doom-shroom from leaving craters on the lawn after exploding. Keeps your battlefield clean.

---

### 🎮 Sandbox

#### Plant and Zombie Spawner
Spawn any plant or zombie from the Almanac directly onto the lawn.

| Key | Action |
|-----|--------|
| **B** | Spawn selected plant at cursor location |
| **N** | Spawn selected zombie at cursor location |
| **Ctrl** (Left/Right) | Toggle mind-control on spawned zombies |

**How to use:** Open the Almanac → click the plant or zombie you want → close the Almanac → hover over the lawn → press **B** or **N**.

#### Plant Conveyor
Cycle through seed cards on the conveyor belt during a level. Press the **arrow keys** (← →) to rotate which plants appear in your seed slots. Cards reset their cooldown when you switch.

#### Odyssey Buffs
Configure and enable all Odyssey/Travel mode buffs, upgrades, and debuffs without needing to earn them through gameplay. All settings are available in the MelonPreferences menu under separate categories for Main, Advanced, Ultimate, and Debuffs.

> **Note for v3.6.1:** The game's buff API has been significantly reworked. This mod currently logs your configured buff settings to the MelonLoader console. Full auto-apply support will be restored in a future update.

#### Seed Rain Overhaul
Overhauls the seed rain system with 6 modes and per-plant toggles.

| Mode | Description |
|------|-------------|
| **0** | Default seed rain |
| **1** | Custom seed rain (only enabled plants) |
| **2** | Default + Odyssey plants |
| **3** | Odyssey plants only |
| **4** | All plants |
| **5** | All plants except aquatic plants |

Configure which plants are enabled via the `Seed Rain Overhaul - Custom Enabled Plants` preferences.

#### Multi Giftbox
Allows multiple Plant Giftboxes to be active at the same time. Removes the default one-giftbox limit so you can stack and open multiple giftboxes.

---

### 🧰 Utilities Addon

A comprehensive cheat/cheat-toggle utility mod with an on-screen status overlay. Press **F12** to toggle the overlay.

#### Toggleable Features

| Key | Feature |
|-----|---------|
| **F1** | Unlimited Sun |
| **F2** | Unlimited Coins |
| **F3** | No Cooldown (plants, hammer, glove) |
| **F4** | Invulnerable Plants |
| **F5** | Invulnerable Zombies |
| **F6** | Double Damage |
| **F7** | Super Damage (100×) |
| **F8** | Stop Zombie Spawning |
| **F9** | Stop Game Over |
| **F10** | Plant Everywhere (ignore restrictions) |
| **F11** | Developer Mode |
| **;** | Scaredy Dream toggle |
| **'** | Seed Rain toggle |

#### Quick Actions (Numpad)

| Key | Action |
|-----|--------|
| **Numpad 0** | Generate Trophy |
| **Numpad 1** | Generate Fertilizer |
| **Numpad 2** | Generate Bucket |
| **Numpad 3** | Generate Helmet |
| **Numpad 4** | Generate Jack-in-the-Box |
| **Numpad 5** | Generate Pickaxe |
| **Numpad 6** | Generate Mecha |
| **Numpad 7** | Generate Super Mecha |
| **Numpad 8** | Generate Magnetar Meteor |
| **Numpad 9** | Generate Sprout Pot |
| **Numpad \*** | Charm All Zombies |
| **Numpad -** | Kill All Zombies |
| **Numpad +** | Kill All Your Plants |

---

## Building from Source

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- PvZ Fusion installed with MelonLoader

### Steps

1. Open each project's `.csproj` file and update the `<GamePath>` property to point to **your** game installation directory.
2. Build all projects:
   ```bash
   dotnet build "PvZ Fusion Helper.sln" --configuration Release
   ```
3. The compiled DLLs will be in each project's `bin/Release/net6.0/` folder. Copy them to your game's `Mods/` folder.

---

## Credits

- **[ArifRios1st](https://github.com/ArifRios1st/PVZ-Hyper-Fusion-Mod)** — OG Mod Developer
- **Wizard J** — OG BepInEx Mods
- **dynaslash** — Original author of this suite
- **TuanAnh2901** — Co-author (Better Pot Fusion, Better Pumpkin Fusion, Odyssey Buffs, Seed Rain Overhaul, Plant and Zombie Spawner)
- **Climeron** — Plant Conveyor collaboration

## Changelog

- Updated all mods for PvZ Fusion v3.6.1 compatibility
- **Better Game Speed** — Changed hotkeys, fixed GameStatus enum comparisons
- **Utilities** — Added Generate Sprout, added F12 overlay toggle
- **Plant and Zombie Spawner** — Changed hotkeys to B/N
- **Odyssey Buffs** — Adapted to new TravelMgr API (buffs currently logged, not auto-applied)
- **Better Pot Fusion** / **Better Pumpkin Fusion** — Updated GloveMgr → Glove.Instance, Board.plantArray → reflection-based iteration
- **Plant Conveyor** — Updated InGameUIMgr → InGameUI
- **No Craters** — No changes needed, still compatible
