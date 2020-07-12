using _06.FoodShortage.Interfaces;

namespace _06.FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthable, INameable, IAgeable, IBuyer
    {
        private int food;
        public Citizen(string name, string age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate=birthDate;
            this.Food = 0;
        }
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }

        public int Food { get; private set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
