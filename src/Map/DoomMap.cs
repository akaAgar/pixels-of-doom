﻿/*
==========================================================================
This file is part of Pixels of Doom, a tool to create Doom maps from PNG files
by @akaAgar (https://github.com/akaAgar/pixels-of-doom)
Pixels of Doom is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
Pixels of Doom is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with Pixels of Doom. If not, see https://www.gnu.org/licenses/
==========================================================================
*/

using PixelsOfDoom.Wad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PixelsOfDoom.Map
{
    public sealed class DoomMap : IDisposable
    {
        public string Name { get; }

        public List<Linedef> Linedefs { get; } = new List<Linedef>();
        public List<Sector> Sectors { get; } = new List<Sector>();
        public List<Sidedef> Sidedefs { get; } = new List<Sidedef>();
        public List<Thing> Things { get; } = new List<Thing>();
        private List<Vertex> Vertices { get; } = new List<Vertex>();

        public DoomMap(string name)
        {
            Name = name;
        }

        public void AddToWad(WadFile wad)
        {
            wad.AddLump(Name, new byte[0]);
            wad.AddLump("LINEDEFS", Linedefs.SelectMany(x => x.ToBytes()).ToArray());
            wad.AddLump("SECTORS", Sectors.SelectMany(x => x.ToBytes()).ToArray());
            wad.AddLump("SIDEDEFS", Sidedefs.SelectMany(x => x.ToBytes()).ToArray());
            wad.AddLump("THINGS", Things.SelectMany(x => x.ToBytes()).ToArray());
            wad.AddLump("VERTEXES", Vertices.SelectMany(x => x.ToBytes()).ToArray());
        }

        public void AddThing(Point position, int type, ThingAngle angle, ThingOptions options = ThingOptions.AllSkills)
        {
            Things.Add(new Thing(position.X, position.Y, (int)angle, type, options));
        }


        public int AddVertex(int x, int y) { return AddVertex(new Point(x, y)); }
        public int AddVertex(Point pt)
        {
            for (int i = 0; i < Vertices.Count; i++)
                if ((Vertices[i].X == pt.X) && (Vertices[i].Y == pt.Y))
                    return i;

            Vertices.Add(new Vertex(pt));
            return Vertices.Count - 1;
        }

        public void Dispose()
        {

        }
    }
}