# SuddenDeathPlus
osu! mod that triggers a BSOD if you miss with Sudden Death 

# FAQ:

## How do I download this?

The .exe file can be downloaded from the [releases page](https://github.com/Plextora/SuddenDeathPlus/releases/latest)

## How does this work?
Using the [Memory.dll](https://github.com/erfg12/memory.dll) library and [signatures and offsets](https://github.com/GH-Rake/PatternScan?tab=readme-ov-file#what-is-pattern-scanning) from [tosu](https://github.com/tosuapp/tosu/blob/master/packages/tosu/src/memory/stable.ts), the program reads the osu! process memory for these conditions
- Is the game running?
- What's the current HP of the player?
- Is Sudden Death (SD) or Perfect (PF) one of the mods currently enabled?

If all of these conditions are met, the program marks itself as a process critical to the operating system running, and then kills itself, causing a Blue Screen of Death (BSOD)

## My antivirus flagged this as a virus!! You're trying to take over my PC!!!!
I wouldn't be surprised if this program was flagged by any antiviruses, as this is basically malware (crashes your computer). However, this isn't some data stealer, and you can look through the source code to see for yourself. Get ChatGPT to explain it for you if you don't know how to read code.
