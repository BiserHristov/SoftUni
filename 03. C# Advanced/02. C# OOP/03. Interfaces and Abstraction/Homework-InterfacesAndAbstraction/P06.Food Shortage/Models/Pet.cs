using _06.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    public class Pet : IBirthable, INameable
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.Birthdate = birthDate;
        }
        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}
