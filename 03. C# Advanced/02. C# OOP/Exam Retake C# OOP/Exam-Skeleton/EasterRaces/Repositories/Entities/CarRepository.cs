using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;
        public CarRepository()
        {
            this.models= new List<ICar>();
        }

        //public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)this.models;

        public ICar GetByName(string name)
        {
            ICar car = this.models.FirstOrDefault(c => c.Model == name);
            return car;
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return (IReadOnlyCollection<ICar>)this.models;
        }

        public void Add(ICar model)
        {
            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            ICar car = this.models.FirstOrDefault(c => c.Model == model.Model);
            return this.models.Remove(car);
        }
    }
}
