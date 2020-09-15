using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository:IRepository<IRace>
    {
        private readonly ICollection<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public IRace GetByName(string name)
        {
            IRace race = this.models.FirstOrDefault(r => r.Name == name);
            return race;
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return (IReadOnlyCollection<IRace>)this.models;
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
            IRace race = this.models.FirstOrDefault(r => r.Name == model.Name);
            return this.models.Remove(race);
        }
    }
}
