using Ascent;
using Ascent.Entities;
using ConsoleLayers;
using Microsoft.Xna.Framework;
using MyProject;
using SadConsole;

namespace Ascent
{
    public class CommandHelpers
    {
        // Move the actor BY +/- X&Y coordinates
        // returns true if the move was successful
        // and false if unable to move there
        public static void MoveActorBy(Actor actor, Point offset)
        {
            MoveTo(actor, offset);
        }

        // Moves the Actor TO newPosition location
        // returns true if actor was able to move, false if failed to move
        public static bool MoveTo(Actor actor, Point newPosition)
        {
            // Check the map if we can move to this new position
            if (MapGenerator.IsTileWalkable(actor.Position + newPosition, Hud.MapWidth, Hud.MapHeight))
            {
                actor.Position += newPosition;
                return true;
            }
            else
                return false;
        }

        // centers the viewport camera on an Actor
        public static void CenterOnActor(Actor actor)
        {
            Hud.MapScrollConsole.CenterViewPortOnPoint(actor.Position);
        }

        #region Currently Unused
        // Moves the Actor BY positionChange tiles in any X/Y direction
        // returns true if actor was able to move, false if failed to move
        public static bool MovePlayerBy(Point positionChange)
        {
            // Check the map if we can move to this new position
            if (MapGenerator.IsTileWalkable(GameLoop.GameDataManager.Player.Position + positionChange, Hud.MapWidth, Hud.MapHeight))
            {
                GameLoop.GameDataManager.Player.Position += positionChange;
                return true;
            }
            else
                return false;
        }

        // centers the viewport camera on an Actor
        public static void CenterOnPlayer()
        {
            Hud.MapScrollConsole.CenterViewPortOnPoint(GameLoop.GameDataManager.Player.Position);
        }
        #endregion
    }
}
