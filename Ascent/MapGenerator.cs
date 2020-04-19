using Ascent.Entities;
using Microsoft.Xna.Framework;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent
{
    public class MapGenerator
    {
        public static Random rng = new Random();
        public static Map GameMap { get; set; }
        public static Player Player { get; set; }

        // Loads a Map into the MapConsole
        public static void LoadMap(Map map)
        {
            // First load the map's tiles into the console
            Hud.MapScrollConsole = new ScrollingConsole(Hud.MapWidth, Hud.MapHeight, Global.FontDefault, new Rectangle(0, 0, Hud.MapWidth, Hud.MapHeight), map.Tiles);
            Hud.MapConsole.Children.Add(Hud.MapScrollConsole);
        }

        public static bool IsTileWalkable(Point location, int mapWidth, int mapHeight)
        {
            // first make sure that actor isn't trying to move
            // off the limits of the map
            if (location.X < 0 || location.Y < 0 || location.X >= Hud.MapWidth || location.Y >= Hud.MapHeight)
                return false;
            // then return whether the tile is walkable
            return !MyProject.Game._tiles[location.Y * Hud.MapWidth + location.X].IsBlockingMove;
        }
    }
}
