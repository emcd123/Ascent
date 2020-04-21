﻿using System;
using System.Collections.Generic;
using System.Text;
using Ascent.Entities;
using Microsoft.Xna.Framework;
using SadConsole.Entities;

namespace Ascent
{
    public class Map
    {

        private BaseTile[] _tiles; // contain all tile objects
        private int _width;
        private int _height;

        public BaseTile[] Tiles { get { return _tiles; } set { _tiles = value; } }
        public int Width { get { return _width; } set { _width = value; } }
        public int Height { get { return _height; } set { _height = value; } }


        //Build a new map with a specified width and height
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            Tiles = new BaseTile[width * height];
        }

        public Stair GetStairAt(Point position)
        {
            foreach(var stair in GameDataManager.Stairs)
            {
                if (stair.Position == position)
                    return stair;
            }
            return null;
        }
    }
}
