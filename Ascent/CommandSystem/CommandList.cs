using Ascent.Entities;
using ConsoleLayers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent
{
    public class UpCommand : ICommand
    {
        public void Execute(Actor actor)
        {
            if (MapGenerator.IsTileWalkable(actor.Position + new Point(0, -1), Hud.MapWidth, Hud.MapHeight))
            {
                if (GameDataManager.Enemies != null)
                {
                    Enemy enemy = GameDataManager.GameMap.GetEnemyAt(actor.Position + new Point(0, -1));
                    //Item item = MapGenerator.GameMap.GetEntityAt<Item>(actor.Position + new Point(1, 0));
                    if (enemy != null)
                    {
                        CommandManager.attack_command.Execute(actor, enemy);
                        return;
                    }
                }
                //// if there's an item here,
                //// try to pick it up
                //else if (item != null)
                //{
                //    CommandManager.pickup_command.Execute(actor, item);
                //    return;
                //}
                actor.Position += new Point(0, -1);
                CommandHelpers.CenterOnActor(actor);
            }
            else
                return;
        }
    }

    public class DownCommand : ICommand
    {
        public void Execute(Actor actor)
        {
            if (MapGenerator.IsTileWalkable(actor.Position + new Point(0, 1), Hud.MapWidth, Hud.MapHeight))
            {
                if (GameDataManager.Enemies != null)
                {
                    Enemy enemy = GameDataManager.GameMap.GetEnemyAt(actor.Position + new Point(0, 1));
                    //Item item = MapGenerator.GameMap.GetEntityAt<Item>(actor.Position + new Point(1, 0));
                    if (enemy != null)
                    {
                        CommandManager.attack_command.Execute(actor, enemy);
                        return;
                    }
                }
                //// if there's an item here,
                //// try to pick it up
                //else if (item != null)
                //{
                //    CommandManager.pickup_command.Execute(actor, item);
                //    return;
                //}
                actor.Position += new Point(0, 1);
                CommandHelpers.CenterOnActor(actor);
            }
            else
                return;
        }
    }

    public class LeftCommand : ICommand
    {
        public void Execute(Actor actor)
        {
            if (MapGenerator.IsTileWalkable(actor.Position + new Point(-1, 0), Hud.MapWidth, Hud.MapHeight))
            {
                if (GameDataManager.Enemies != null)
                {
                    Enemy enemy = GameDataManager.GameMap.GetEnemyAt(actor.Position + new Point(-1, 0));
                    //Item item = MapGenerator.GameMap.GetEntityAt<Item>(actor.Position + new Point(1, 0));
                    if (enemy != null)
                    {
                        CommandManager.attack_command.Execute(actor, enemy);
                        return;
                    }
                }
                //// if there's an item here,
                //// try to pick it up
                //else if (item != null)
                //{
                //    CommandManager.pickup_command.Execute(actor, item);
                //    return;
                //}

                actor.Position += new Point(-1, 0);
                CommandHelpers.CenterOnActor(actor);
            }
            else
                return;
        }
    }

    public class RightCommand : ICommand
    {
        public void Execute(Actor actor)
        {
            if (MapGenerator.IsTileWalkable(actor.Position + new Point(1, 0), Hud.MapWidth, Hud.MapHeight))
            {
                if(GameDataManager.Enemies != null)
                {
                    Enemy enemy = GameDataManager.GameMap.GetEnemyAt(actor.Position + new Point(1, 0));
                    //Item item = MapGenerator.GameMap.GetEntityAt<Item>(actor.Position + new Point(1, 0));
                    if (enemy != null)
                    {
                        CommandManager.attack_command.Execute(actor, enemy);
                        return;
                    }
                }
                //// if there's an item here,
                //// try to pick it up
                //else if (item != null)
                //{
                //    CommandManager.pickup_command.Execute(actor, item);
                //    return;
                //}

                actor.Position += new Point(1, 0);
                CommandHelpers.CenterOnActor(actor);
            }
            else
                return;
        }
    }

    public class UseStairsCommand : ICommand
    {
        public void Execute(Actor actor)
        {
            if (MapGenerator.IsTileWalkable(actor.Position, Hud.MapWidth, Hud.MapHeight))
            {
                Stair Stairs = GameDataManager.GameMap.GetStairAt(actor.Position);
                if (Stairs != null)
                {
                    // **TEST For now there are only two levels with no level tracker so all upstairs go to town
                    if (!Stairs.DownStair) 
                    {
                        --GameDataManager.CurrentGameLevel;
                        if (GameDataManager.CurrentGameLevel == 0)
                            MapGenerator.GenerateTownMap();
                        else
                            MapGenerator.GenerateSquareMap();
                        MapGenerator.LoadMap();
                        return;
                    }
                    ++GameDataManager.CurrentGameLevel;
                    ++GameDataManager.HighestLevelAchieved;
                    MapGenerator.GenerateSquareMap();
                    MapGenerator.LoadMap();
                    return;
                }
            }
            else
                return;
        }
    }

    public class AttackCommand : ICommandBinary
    {
        public void Execute(Actor attacker, Actor defender)
        {
            var CombatSystem = new Combat();
            CombatSystem.Attack(attacker, defender);
        }
    }

    //public class PickupCommand : ICommandItem
    //{
    //    public void Execute(Actor actor, Item item)
    //    {
    //        // Add the item to the Actor's inventory list
    //        // and then destroy it
    //        actor.Inventory.Add(item);
    //        Hud.MessageLog.Add($"{actor.Name} picked up {item.Name}");
    //        item.Destroy(MapGenerator.GameMap);
    //    }
    //}
}
