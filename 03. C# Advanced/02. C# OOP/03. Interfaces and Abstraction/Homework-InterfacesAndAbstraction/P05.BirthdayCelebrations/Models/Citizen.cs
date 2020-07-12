using _05.BirthdayCelebrations.Interfaces;

namespace _05.BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, string age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate=birthDate;
        }
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
    }
}
