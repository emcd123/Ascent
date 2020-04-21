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
            InputHandling.TakeInput(GameDataManager.Player);
        }

        private static void Init()
        {
            Hud.InitHUD();
            GameDataManager.CurrentGameLevel = GameDataManager.HighestLevelAchieved = 0;
            MapGenerator.GenerateTownMap();
            MapGenerator.LoadMap();
        }
    }
}