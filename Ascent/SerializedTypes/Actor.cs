using Ascent.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ascent.SerializedTypes
{
    public class ActorSerialised
    {
        private int _health; //current health
        private int _maxHealth; //maximum possible health

        [DataMember] public int Health { get { return _health; } set { _health = value; } } // public getter for current health
        [DataMember] public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } } // public setter for current health
        [DataMember] public int Attack { get; set; } // attack strength
        [DataMember] public int AttackChance { get; set; } // percent chance of successful hit
        [DataMember] public int Defense { get; set; } // defensive strength
        [DataMember] public int DefenseChance { get; set; } // percent chance of successfully blocking a hit
        [DataMember] public int Gold { get; set; } // amount of gold carried

        public static implicit operator ActorSerialised(Actor actor)
        {
            var serializedObject = new ActorSerialised()
            {
                Health = actor.Health,
            };

            return serializedObject;
        }

        public static implicit operator Actor(ActorSerialised serializedObject)
        {
            var actor = new Actor(Color.Yellow, Color.Transparent, '@');
            actor.Health = serializedObject.Health;
            return actor;
        }
    }
}
