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

namespace PNG2WAD.Generator
{
    /// <summary>
    /// Four sides of a tile. Used for linedef generation.
    /// </summary>
    public enum TileSide
    {
        /// <summary>
        /// North.
        /// </summary>
        North,
        /// <summary>
        /// East.
        /// </summary>
        East,
        /// <summary>
        /// South.
        /// </summary>
        South,
        /// <summary>
        /// West.
        /// </summary>
        West
    }
}
