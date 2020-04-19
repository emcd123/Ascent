using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent
{
    // WallTile is based on BaseTile
    public class WallTile : BaseTile
    {
        // Default constructor
        // Walls are set to block movement and line of sight by default
        // and have a light gray foreground and a transparent background
        // represented by the # symbol
        public WallTile(bool blocksMovement = true, bool blocksLOS = true) : base(Color.LightGray, Color.Transparent, '#', blocksMovement, blocksLOS)
        {
            Name = "Wall";
        }
    }
}
