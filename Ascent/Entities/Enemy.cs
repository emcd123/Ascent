using Ascent.SerializedTypes;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent.Entities
{
    [JsonConverter(typeof(EnemyJsonConverter))]
    //A generic monster capable of
    //combat and interaction
    //yields treasure upon death
    public class Enemy : Actor
    {
        public Enemy(Color foreground, Color background) : base(foreground, background, 'M')
        {
            MaxHealth = 40;
            Health = 40;

            ////number of loot to spawn for monster
            //int lootNum = rndNum.Next(1, 4);

            //for (int i = 0; i < lootNum; i++)
            //{
            //    // monsters are made out of spork, obvs.
            //    Item newLoot = new Item(Color.HotPink, Color.Transparent, "spork", 'L', 2);
            //    Inventory.Add(newLoot);
            //}
        }
    }
}
