using System;
using Ascent;
using Ascent.Entities;

namespace MyProject
{
    internal class InputHandling
    {
        internal static void TakeInput(Actor actor)
        {

            // As an example, we'll use the F11 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F11))
            {
                SadConsole.Settings.ToggleFullScreen();
            }

            // Keyboard movement for Player character: Up arrow
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                CommandManager.up_command.Execute(actor);
            }

            // Keyboard movement for Player character: Down arrow
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                CommandManager.down_command.Execute(actor);
            }

            // Keyboard movement for Player character: Left arrow
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                CommandManager.left_command.Execute(actor);
            }

            // Keyboard movement for Player character: Right arrow
            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                CommandManager.right_command.Execute(actor);
            }

            // Keyboard movement for Player character: Right arrow
            if ((SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift) || SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift)) && (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.OemPeriod) || SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.OemComma)))
            {
                CommandManager.UseStairs.Execute(actor);
            }

            // Keyboard movement for Player character: Right arrow
            if (SadConsole.Global.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) && SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.X))
            {
                LoadingSystem.SaveGameToFileJson();
            }
        }
    }
}