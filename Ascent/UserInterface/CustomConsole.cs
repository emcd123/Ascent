using Microsoft.Xna.Framework;
using SadConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLayers
{
    public class CustomConsole : SadConsole.Console
    {
        public CustomConsole(Color ConsoleColor, int Width, int Height) : base(Width, Height)
        {
            Fill(ConsoleColor, Color.Black, 176);
        }
    }
}
