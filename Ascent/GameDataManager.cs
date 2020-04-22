
using Ascent.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent
{
    public class GameDataManager
    {
        public Random rng = new Random();
        public Map GameMap { get; set; }
        public int CurrentGameLevel { get; set; }
        public int HighestLevelAchieved { get; set; }
        public Player Player { get; set; }
        public List<Stair> Stairs { get; set; }
        public List<Enemy> Enemies { get; set; }
    }
}
