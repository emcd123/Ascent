﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent
{
    public class FloorTile : BaseTile
    {
        // Default constructor
        // Floors are set to allow movement and line of sight by default
        // and have a dark gray foreground and a transparent background
        // represented by the . symbol
        public FloorTile(bool blocksMovement = false, bool blocksLOS = false) : base(Color.DarkGray, Color.Transparent, '.', blocksMovement, blocksLOS)
        {
            Name = "Floor";
        }
    }
}
