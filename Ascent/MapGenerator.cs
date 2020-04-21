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
        public static void GenerateSquareMap()
        {
            Hud.MapConsole.Children.Clear();
            GameDataManager.GameMap = new Map(Hud.MapWidth, Hud.MapHeight);
            CreateWalls();
            CreateFloors();
            PlaceStairs(true);
            CreateEnemies();
            CreatePlayer();
        }

        public static void GenerateTownMap()
        {
            Hud.MapConsole.Children.Clear();
            GameDataManager.GameMap = new Map(Hud.MapWidth, Hud.MapHeight);
            CreateWalls();
            CreateFloors();
            CreateTownBuildings();
            PlaceStairs();
            CreatePlayer();
        }

        private static void PlaceStairs(bool notTown = false)
        {
            GameDataManager.Stairs = new List<Stair>() { };
            Stair Downstairs = new Stair(Color.White, Color.Black, "Down Stairs", true, '>');
            Downstairs.Position = SadConsole.Helpers.GetPointFromIndex((GameDataManager.GameMap.Height / 2) * Hud.MapWidth + (GameDataManager.GameMap.Width / 2), Hud.MapWidth);
            GameDataManager.Stairs.Add(Downstairs);
            Hud.MapConsole.Children.Add(Downstairs);

            // **TEST this is just to guarantee an upstairs on the non-town level
            if (notTown)
            {
                Stair UpStairs = new Stair(Color.White, Color.Black, "Up Stairs", false, '<');
                UpStairs.Position = SadConsole.Helpers.GetPointFromIndex((GameDataManager.GameMap.Height / 2) * Hud.MapWidth + (GameDataManager.GameMap.Width / 2 -1), Hud.MapWidth);
                GameDataManager.Stairs.Add(UpStairs);
                Hud.MapConsole.Children.Add(UpStairs);
            }
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

            //Fill the entire tile array with walls
            for (int i = 0; i < GameDataManager.GameMap.Tiles.Length; i++)
            {
                GameDataManager.GameMap.Tiles[i] = new WallTile();
            }
        }

        public static void CreateTownBuildings()
        {
            //Top Left Building
            for (int i = 10; i < 15; i++)
            {
                for (int j = 4; j < 9; j++)
                {
                    GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new WallTile();
                    if (i == 14 && j == 6)
                        GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new FloorTile();
                }
            }

            //Bottom Left Building
            for (int i = 10; i < 15; i++)
            {
                for (int j = 12; j < 17; j++)
                {
                    GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new WallTile();
                    if (i == 14 && j == 14)
                        GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new FloorTile();
                }
            }

            //Top Right Building
            for (int i = 45; i < 50; i++)
            {
                for (int j = 4; j < 9; j++)
                {
                    GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new WallTile();
                    if (i == 45 && j == 6)
                        GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new FloorTile();
                }
            }

            //Bottom Right Building
            for (int i = 45; i < 50; i++)
            {
                for (int j = 12; j < 17; j++)
                {
                    GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new WallTile();
                    if (i == 45 && j == 14)
                        GameDataManager.GameMap.Tiles[j * Hud.MapWidth + i] = new FloorTile();
                }
            }
        }

        // Create some random monsters with random attack and defense values
        // and drop them all over the map in
        // random places.
        public static void CreateEnemies()
        {
            GameDataManager.Enemies = new List<Enemy>();
            // number of monsters to create
            int numMonsters = 2;

            // Create several monsters and 
            // pick a random position on the map to place them.
            // check if the placement spot is blocking (e.g. a wall)
            // and if it is, try a new position
            for (int i = 0; i < numMonsters; i++)
            {
                int enemyPosition = 0;
                Enemy newEnemy = new Enemy(Color.Blue, Color.Transparent);
                while (GameDataManager.GameMap.Tiles[enemyPosition].IsBlockingMove)
                {
                    // pick a random spot on the map
                    enemyPosition = GameDataManager.rng.Next(0, Hud.MapWidth * Hud.MapHeight);
                }

                // plug in some magic numbers for attack and defense values
                newEnemy.Defense = GameDataManager.rng.Next(0, 10);
                newEnemy.DefenseChance = GameDataManager.rng.Next(0, 50);
                newEnemy.Attack = GameDataManager.rng.Next(0, 10);
                newEnemy.AttackChance = GameDataManager.rng.Next(0, 50);
                newEnemy.Name = "a common troll";

                // Set the monster's new position
                // Note: this fancy math will be replaced by a new helper method
                // in the next revision of SadConsole
                newEnemy.Position = new Point(enemyPosition % Hud.MapWidth, enemyPosition / Hud.MapWidth);
                GameDataManager.Enemies.Add(newEnemy);
                Hud.MapConsole.Children.Add(newEnemy);
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
