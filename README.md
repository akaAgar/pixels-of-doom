# Pixels of Doom

A C# (.Net/Mono) command line tool to turn BMP/PNG images to Doom maps.

Pixels of Doom is also a very good way to learn about the (very elegant) Doom map format. To learn more about Doom maps and archives, and better understand this source code, you should read the [Unofficial Doom Specs](http://www.gamers.org/dhs/helpdocs/dmsp1666.html) by Matthew S. Fell.

![Preview images](preview.png)

## Features
- Any bitmap size
- Supports doors, secret passages, special sectors, entrances, exits,  variable floor/ceiling height.
- Theme configuration to create maps with various feelings and textures (hell, tech base, sewers...)
- Can generate maps in the Doom 1 (ExMx) or Doom 2 (MAPxx) name format.
- Optional things generation to create immediately playable maps filled with monsters and items. Or you can disable the thing generator and populate the map yourself using a map editor such as [Doombuilder](http://www.doombuilder.com/).
- Includes [Bsp](http://games.moria.org.uk/doom/bsp/) for node generation on Windows. On macOS/Linux you'll have to build nodes manually using a third-party node builder before you can play your maps.

## Usage

### Using the command-line
Syntax is: **PixelsOfDoom.exe SomeImage.png \[SomeOtherImage.png\] \[YetAnotherImage.png\]...**

### From the GUI
Drag and drop one or more PNG files on **PixelsOfDoom.exe**

First file will be 

Output WAD fi

## Creating images

Run your favorite image edition tool and create a new PNG of any size. Each pixel is a 64x64 tile on the map.

### Theme
The upper-left pixel is always a wall. Its color is ignored and used to select the map theme, as defined in the Preferences.ini file. You can add more themes by editing the file.

Available themes are:

- Red (255, 0, 0): hell
- Any other color: tech base (default)

### Image pixels
| Pixel color           | Tile type                                                    |
| --------------------- | ------------------------------------------------------------ |
| White (255, 255, 255) | Wall                                                         |
| Red (255, 0, 0)       | Room with special floor (nukage, lava,  etc.) as defined in the map theme |
| Green (0, 128, 0)     | Room with special ceiling (lamp, etc.) as defined in the map theme |
| Blue (0, 0, 255) | Room with open sky (exterior) |
| Olive (128, 128, 0) | Door |
| Magenta (255, 0, 255) | Secret passage |
| Yellow (255, 255, 0) | Entrance/player start |
| Lime (0, 255, 0) | Exit |
| Any other color       | Room                                                         |


