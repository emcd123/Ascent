
using Ascent.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent
{
    public class GameDataManager
    {
        public static Random rng = new Random();
        public static Map GameMap { get; set; }
        public static Player Player { get; set; }
        public static List<Stair> Stairs { get; set; }
    }
}
