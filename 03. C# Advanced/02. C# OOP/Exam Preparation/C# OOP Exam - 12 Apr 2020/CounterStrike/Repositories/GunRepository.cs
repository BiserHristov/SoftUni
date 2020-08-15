using CounterStrike.Models.Guns.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using CounterStrike.Utilities.Messages;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        
        private readonly ICollection<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.models;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.models.Add(model);
        }

        public IGun FindByName(string name)
        {
            IGun gun = this.models.FirstOrDefault(g => g.Name == name);
            return gun;
        }

        public bool Remove(IGun model)
        {
            IGun gun = this.models.FirstOrDefault(g => g.Name == model.Name);
            return this.models.Remove(gun);
        }
    }
}
