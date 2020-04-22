using Microsoft.Xna.Framework;
using SadConsole.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ascent.Entities
{
    public class Actor : Entity
    {
        private int _health; //current health
        private int _maxHealth; //maximum possible health

        public int Health { get { return _health; } set { _health = value; } } // public getter for current health
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } } // public setter for current health
        public int Attack { get; set; } // attack strength
        public int AttackChance { get; set; } // percent chance of successful hit
        public int Defense { get; set; } // defensive strength
        public int DefenseChance { get; set; } // percent chance of successfully blocking a hit
        public int Gold { get; set; } // amount of gold carried


        //public List<Item> Inventory = new List<Item>(); // the player's collection of items

        public Actor(Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }
    }
}
