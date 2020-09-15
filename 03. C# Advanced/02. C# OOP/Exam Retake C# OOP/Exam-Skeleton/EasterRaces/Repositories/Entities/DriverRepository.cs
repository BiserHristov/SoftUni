using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository:IRepository<IDriver>
    {
        private readonly ICollection<IDriver> models;
        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }
        public IDriver GetByName(string name)
        {
            IDriver driver = this.models.FirstOrDefault(d => d.Name == name);
            return driver;
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return (IReadOnlyCollection<IDriver>)this.models;
        }

        public void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDriver model)
        {
            IDriver driver = this.models.FirstOrDefault(d => d.Name == model.Name);
            return this.models.Remove(driver);
        }
    }
}
