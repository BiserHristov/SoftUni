﻿using _06.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    public class Rebel : INameable, IAgeable, IBuyer
    {
        private int food;
        public Rebel(string name, string age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;

        }
        public string Group { get; private set; }
        public string Name { get; private set; }
        public string Age { get; private set; }
        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
