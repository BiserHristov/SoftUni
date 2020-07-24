using _04.WildFarm.Models.Animal;
using _04.WildFarm.Models.Animal.Birds;
using _04.WildFarm.Models.Animal.Mammals;
using _04.WildFarm.Models.Animal.Mammals.Feline;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal ProduceAnimal(string[] input)
        {
            string type = input[0];
            string name = input[1];
            double weight = double.Parse(input[2]);

            Animal hero = null;
            //Type searchedType = Type.GetType("_04.WildFarm.Models.Animal.Mammals.Feline." + type);

            if (type=="Cat" || type=="Tiger")
            {
                string livingRegion = input[3];
                string breed = input[4];


                if (type == "Cat")
                {
                    hero = new Cat(name, weight, livingRegion, breed);

                }

                else if (type == "Tiger")
                {
                    hero = new Tiger(name, weight, livingRegion, breed);

                }

            }
            else if (type == "Mouse" || type == "Dog")
            {
                string livingRegion = input[3];

                if (type == "Mouse")
                {
                    hero = new Mouse(name, weight, livingRegion);

                }
                else if (type == "Dog")
                {
                    hero = new Dog(name, weight, livingRegion);

                }

            }
            else if (type == "Owl" || type == "Hen")
            {
                double wingSize = double.Parse(input[3]);

                if (type == "Owl")
                {
                    hero = new Owl(name, weight, wingSize);

                }

                else if (type == "Hen")
                {
                    hero = new Hen(name, weight, wingSize);

                }

            }


            if (hero != null)
            {
                return hero;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
