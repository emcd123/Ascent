using ConsoleLayers;
using Microsoft.Xna.Framework;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent
{
    public class Hud
    {
        public static int WindowWidth = 80;
        public static int WindowHeight = 30;

        public static int SkillsWidth = 60;
        public static int SkillsHeight = 5;

        public static int MapWidth = 60;
        public static int MapHeight = 20;

        public static int InventoryWidth = 20;
        public static int InventoryHeight = 10;

        public static int ProfileWidth = 20;
        public static int ProfileHeight = 20;

        public static int MessageWidth = 60;
        public static int MessageHeight = 5;

        public static CustomConsole SkillsConsole { get; set; }
        public static CustomConsole MapConsole { get; set; }
        public static ScrollingConsole MapScrollConsole { get; set; }
        public static CustomConsole SidebarInventory { get; set; }
        public static CustomConsole SidebarPlayerProfile { get; set; }
        public static CustomConsole MessageConsole { get; set; }
        public static MessageLogWindow MessageLog { get; set; }


        public static void InitHUD()
        {
            SadConsole.Themes.Library.Default.Colors.ControlHostBack = Color.Black;
            SadConsole.Themes.Library.Default.Colors.ControlHostFore = Color.Black;
            var console = new SadConsole.Console(WindowWidth, WindowHeight);
            SadConsole.Global.CurrentScreen = console;

            SkillsConsole = new CustomConsole(Microsoft.Xna.Framework.Color.Blue, SkillsWidth, SkillsHeight) { Position = new Point(0, 0) };
            MapConsole = new CustomConsole(Microsoft.Xna.Framework.Color.Black, MapWidth, MapHeight) { Position = new Point(0, 5) };
            MapScrollConsole = new ScrollingConsole(MapWidth, MapHeight, Global.FontDefault);
            SidebarInventory = new CustomConsole(Microsoft.Xna.Framework.Color.Green, InventoryWidth, InventoryHeight) { Position = new Point(60, 0) };
            SidebarPlayerProfile = new CustomConsole(Microsoft.Xna.Framework.Color.Red, ProfileWidth, ProfileHeight) { Position = new Point(60, 10) };
            MessageConsole = new CustomConsole(Microsoft.Xna.Framework.Color.Black, MessageWidth, MessageHeight) { Position = new Point(0, 25) };
            MessageLog = new MessageLogWindow(MessageWidth, MessageHeight, "Message Log");

            console.Children.Add(SkillsConsole);
            console.Children.Add(MapConsole);
            console.Children.Add(SidebarInventory);
            console.Children.Add(SidebarPlayerProfile);
            console.Children.Add(MessageConsole);

            MapConsole.Children.Add(MapScrollConsole);

            MessageConsole.Children.Add(MessageLog);
            MessageConsole.Fill(Color.Black, Color.Black, 176);
            MessageLog.Fill(Color.Black, Color.Black, 176);
            MessageLog.Show();
            MessageLog.Position = new Point(0, 0);

            MessageLog.Add("Welcome to the dungeon.");


        }
    }
}
