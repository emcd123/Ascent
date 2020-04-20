﻿using Microsoft.Xna.Framework;
using SadConsole.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent.Entities
{
    public class Stair : Entity
    {
        // By default, a new Item is sized 1x1, with a weight of 1, and at 100% condition
        public Stair(Color foreground, Color background, string name, char glyph, int width = 1, int height = 1) : base(foreground, background, glyph)
        {
            // assign the object's fields to the parameters set in the constructor
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
            Name = name;
        }

        // Destroy this object by removing it from
        // the MultiSpatialMap's list of entities
        // and lets the garbage collector take it
        // out of memory automatically.
        public void Destroy(Map map)
        {
            //map.Remove(this);
        }
    }
}