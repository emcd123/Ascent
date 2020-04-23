using Ascent.SerializedTypes;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent.Tiles
{
    // TileBase is an abstract base class 
    // representing the most basic form of of all Tiles used.
    [JsonConverter(typeof(TileJsonConverter))]
    public class Tile : Cell
    {
        // Movement and Line of Sight Flags
        public bool IsBlockingMove;
        public bool IsBlockingLOS;

        // Tile's name
        public string Name;

        // TileBase is an abstract base class 
        // representing the most basic form of of all Tiles used.
        // Every TileBase has a Foreground Colour, Background Colour, and Glyph
        // IsBlockingMove and IsBlockingLOS are optional parameters, set to false by default
        public Tile(Color foreground, Color background, int glyph, String type) : base(foreground, background, glyph)
        {
            if(type  == TileTypes.Floor)
            {
                IsBlockingMove = false;
                IsBlockingLOS = false;
                Name = type;
            }
            if(type == TileTypes.Wall)
            {

                IsBlockingMove = true;
                IsBlockingLOS = true;
                Name = type;
            }
        }
    }

    public class TileTypes
    {
        public readonly static string Floor = "Floor";
        public readonly static string Wall = "Wall";
    }
}
