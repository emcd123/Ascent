using System;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Ascent;
using Ascent.Entities;

namespace MyProject
{
    class Game
    {
        public static BaseTile[] _tiles; // an array of TileBase that contains all of the tiles for a map
        static void Main(string[] args)
        {
            // Setup the engine and create the main window.
            SadConsole.Game.Create(Hud.WindowWidth, Hud.WindowHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;


            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            InputHandling.TakeInput(MapGenerator.Player);
        }

        private static void Init()
        {
            Hud.InitHUD();
            // Build the room's walls then carve out some floors
            CreateWalls();
            CreateFloors();
            Hud.MapScrollConsole = new ScrollingConsole(Hud.MapWidth, Hud.MapHeight, Global.FontDefault, new Rectangle(0, 0, Hud.MapWidth, Hud.MapHeight), _tiles);
            Hud.MapConsole.Children.Add(Hud.MapScrollConsole);
            CreatePlayer();
        }

        // Create a player using SadConsole's Entity class
        private static void CreatePlayer()
        {
            MapGenerator.Player = new Player(Color.Yellow, Color.Transparent);
            // Place the player on the first non-movement-blocking tile on the map
            for (int i = 0; i < _tiles.Length; i++)
            {
                if (!_tiles[i].IsBlockingMove)
                {
                    // Set the player's position to the index of the current map position
                    MapGenerator.Player.Position = SadConsole.Helpers.GetPointFromIndex(i, Hud.MapWidth);
                    break;
                }
            }
            Hud.MapConsole.Children.Add(MapGenerator.Player);
        }

        // Carve out a rectangular floor using the TileFloors class
        private static void CreateFloors()
        {
            //Carve out a rectangle of floors in the tile array
            for (int x = 1; x < Hud.MapWidth-1; x++)
            {
                for (int y = 1; y < Hud.MapHeight-1; y++)
                {
                    // Calculates the appropriate position (index) in the array
                    // based on the y of tile, width of map, and x of tile
                    _tiles[y * Hud.MapWidth + x] = new FloorTile();
                }
            }
        }

        // Flood the map using the TileWall class
        private static void CreateWalls()
        {
            // Create an empty array of tiles that is equal to the map size
            _tiles = new BaseTile[Hud.MapWidth * Hud.MapHeight];

            //Fill the entire tile array with floors
            for (int i = 0; i < _tiles.Length; i++)
            {
                _tiles[i] = new WallTile();
            }
        }
    }
}