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
    /// How skill level should affect thing spawning?
    /// </summary>
    public enum ThingSkillVariation
    {
        /// <summary>
        /// Same amount of thing in all difficulty level
        /// </summary>
        None,
        /// <summary>
        /// More things in easy modes (e.g. health pickups)
        /// </summary>
        MoreThingsInEasyMode,
        /// <summary>
        /// More things in hard mode (e.g. monsters)
        /// </summary>
        MoreThingsInHardMode
    }
}
