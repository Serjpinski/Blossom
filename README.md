# Blossom

A stochastic cellular automata made into screensaver.

# Credits

`Screensaver.cs` code by Rei Miyasaka: http://www.codeproject.com/Articles/14081/Write-a-Screensaver-that-Actually-Works

`Blossom.ColorFromHSB()` original code by Chris Jackson: https://blogs.msdn.microsoft.com/cjacks/2006/04/12/converting-from-hsb-to-rgb-in-net/

Settings dialog basics taken from Frank McCown: http://www.harding.edu/fmccown/screensaver/screensaver.html

# Usage

You can download and install the screensaver file `~/Windows/Blossom.scr` or download the whole project and compile it yourself. If you are interested in the main algorithm, the source is in `~/Windows/Blossom/Blossom.cs`.

# Settings

You can customize the screensaver via the `Settings` button in Windows menu. There are 4 parameters:

- Framerate. It's the number of times the cellular automata updates per second. Warning: a high framerate value can be CPU intensive, specially for large screens.
- Cell size. It's the size of each cell, in pixels. Default is 1 cell = 1 pixel, but you can increase the size if you want pixelated or smaller patterns.
- Uniformity. The higher this value is, the more uniformly the pattern will expand in every direction.
- Growth. This represents the probability for a new cell to spawn. The higher the value, the faster the pattern will expand.

The last two parameters have great influence in the style of the patterns obtained. Try messing with them!

# Examples

- Pattern generated with uniformity = 0 and growth = 0.50:

![Pattern generated with uniformity = 0 and growth = 0.50](/Screenshots/uni000gro050.png?raw=true "Pattern generated with uniformity = 0 and growth = 0.50")

- Pattern generated with uniformity = 0.4 and growth = 0.05:

![Pattern generated with uniformity = 0.4 and growth = 0.05](/Screenshots/uni040gro005.png?raw=true "Pattern generated with uniformity = 0.4 and growth = 0.05")
