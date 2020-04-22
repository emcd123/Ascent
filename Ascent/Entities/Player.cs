using Ascent.SerializedTypes;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent.Entities
{
    // Creates a new player
    // Default glyph is @
    [JsonConverter(typeof(PlayerJsonConverter))]
    public class Player : Actor
    {
        public int AttackPower;
        public Player(Color foreground, Color background) : base(foreground, background, '@')
        {
            Attack = 10;
            AttackChance = 40;
            Defense = 5;
            DefenseChance = 20;
            Name = "Rogue";
            AttackPower = 50;
        }
    }
}
