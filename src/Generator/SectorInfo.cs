﻿/*
==========================================================================
This file is part of PNG2WAD, a tool to create Doom maps from PNG files,
created by @akaAgar (https://github.com/akaAgar/png2wad)

PNG2WAD is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

PNG2WAD is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with PNG2WAD. If not, see https://www.gnu.org/licenses/
==========================================================================
*/

using PNG2WAD.Config;
using System;

namespace PNG2WAD.Generator
{
    public struct SectorInfo
    {
        public TileType Type { get; }
        public int CeilingHeight { get; private set; }
        public string CeilingTexture { get; private set; }
        public int FloorHeight { get; private set; }
        public string FloorTexture { get; private set; }
        public int LightLevel { get; private set; }
        public int LinedefSpecial { get; private set; }
        public int SectorSpecial { get; private set; }
        public string WallTexture { get; private set; }
        public string WallTextureUpper { get; private set; }
        public string WallTextureLower { get; private set; }

        public SectorInfo(TileType type, PreferencesTheme theme, string[] themeTextures)
        {
            Type = type;

            FloorHeight = theme.Height[(int)ThemeSector.Default][0];
            CeilingHeight = theme.Height[(int)ThemeSector.Default][1];
            LinedefSpecial = 0;
            SectorSpecial = 0;

            LightLevel = theme.LightLevel[(int)ThemeSector.Default];

            CeilingTexture = themeTextures[(int)ThemeTexture.Ceiling];
            FloorTexture = themeTextures[(int)ThemeTexture.Floor];
            WallTexture = Toolbox.RandomFromArray(theme.Textures[(int)ThemeTexture.Wall]);
            WallTextureUpper = null;
            WallTextureLower = null;

            switch (type)
            {
                case TileType.Door:
                    CeilingHeight = FloorHeight;
                    LinedefSpecial = 1; // DR Door Open Wait Close
                    CeilingTexture = "CRATOP1";
                    WallTexture = "DOORTRAK";
                    WallTextureUpper = themeTextures[(int)ThemeTexture.Door];
                    break;

                case TileType.DoorSide:
                    WallTexture = themeTextures[(int)ThemeTexture.DoorSide];
                    break;

                case TileType.Entrance:
                    ApplySectorSpecial(theme, ThemeSector.Entrance);
                    FloorTexture = themeTextures[(int)ThemeTexture.FloorEntrance];
                    break;

                case TileType.Exit:
                    ApplySectorSpecial(theme, ThemeSector.Exit);
                    LinedefSpecial = 52; // W1 Exit Level
                    FloorTexture = themeTextures[(int)ThemeTexture.FloorExit];
                    break;

                case TileType.RoomExterior:
                    ApplySectorSpecial(theme, ThemeSector.Exterior);
                    CeilingTexture = "F_SKY1";
                    FloorTexture = themeTextures[(int)ThemeTexture.FloorExterior];
                    break;

                case TileType.RoomSpecialCeiling:
                    ApplySectorSpecial(theme, ThemeSector.SpecialCeiling);
                    CeilingTexture = themeTextures[(int)ThemeTexture.CeilingSpecial];
                    break;

                case TileType.RoomSpecialFloor:
                    ApplySectorSpecial(theme, ThemeSector.SpecialFloor);
                    FloorTexture = themeTextures[(int)ThemeTexture.FloorSpecial];
                    break;

                case TileType.Secret:
                    CeilingHeight = FloorHeight;
                    LinedefSpecial = 31; // D1 Door Open Stay
                    SectorSpecial = 9; // Secret room
                    WallTexture = "DOORTRAK";
                    break;
            }

            CeilingHeight = Math.Max(FloorHeight, CeilingHeight);

            WallTextureUpper = WallTextureUpper ?? WallTexture;
            WallTextureLower = WallTextureLower ?? WallTexture;
        }

        private void ApplySectorSpecial(PreferencesTheme theme, ThemeSector themeSector)
        {
            CeilingHeight = theme.Height[(int)themeSector][1];
            FloorHeight = theme.Height[(int)themeSector][0];
            LightLevel = theme.LightLevel[(int)themeSector];
            SectorSpecial = theme.SectorSpecial[(int)themeSector];
        }
    }
}
