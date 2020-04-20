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
        // Loads a Map into the MapConsole
        public static void LoadMap()
        {
            // First load the map's tiles into the console
            Hud.MapScrollConsole = new ScrollingConsole(Hud.MapWidth, Hud.MapHeight, Global.FontDefault, new Rectangle(0, 0, Hud.MapWidth, Hud.MapHeight), GameDataManager.GameMap.Tiles);
            Hud.MapConsole.Children.Add(Hud.MapScrollConsole);
        }

        public static void GenerateTownMap()
        {
            CreateWalls();
            CreateFloors();
            CreatePlayer();
        }

        // Create a player using SadConsole's Entity class
        private static void CreatePlayer()
        {
            GameDataManager.Player = new Player(Color.Yellow, Color.Transparent);
            // Place the player on the first non-movement-blocking tile on the map
            for (int i = 0; i < GameDataManager.GameMap.Tiles.Length; i++)
            {
                if (!GameDataManager.GameMap.Tiles[i].IsBlockingMove)
                {
                    // Set the player's position to the index of the current map position
                    GameDataManager.Player.Position = SadConsole.Helpers.GetPointFromIndex(i, Hud.MapWidth);
                    break;
                }
            }
            Hud.MapConsole.Children.Add(GameDataManager.Player);
        }

        // Carve out a rectangular floor using the TileFloors class
        private static void CreateFloors()
        {
            //Carve out a rectangle of floors in the tile array
            for (int x = 1; x < Hud.MapWidth - 1; x++)
            {
                for (int y = 1; y < Hud.MapHeight - 1; y++)
                {
                    // Calculates the appropriate position (index) in the array
                    // based on the y of tile, width of map, and x of tile
                    GameDataManager.GameMap.Tiles[y * Hud.MapWidth + x] = new FloorTile();
                }
            }
        }

        // Flood the map using the TileWall class
        private static void CreateWalls()
        {
            // Create an empty array of tiles that is equal to the map size
            GameDataManager.GameMap.Tiles = new BaseTile[Hud.MapWidth * Hud.MapHeight];

            //Fill the entire tile array with floors
            for (int i = 0; i < GameDataManager.GameMap.Tiles.Length; i++)
            {
                GameDataManager.GameMap.Tiles[i] = new WallTile();
            }
        }

        public static bool IsTileWalkable(Point location, int mapWidth, int mapHeight)
        {
            // first make sure that actor isn't trying to move
            // off the limits of the map
            if (location.X < 0 || location.Y < 0 || location.X >= Hud.MapWidth || location.Y >= Hud.MapHeight)
                return false;
            // then return whether the tile is walkable
            return !GameDataManager.GameMap.Tiles[location.Y * Hud.MapWidth + location.X].IsBlockingMove;
        }
    }
}
