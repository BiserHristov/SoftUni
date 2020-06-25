using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();

        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > this.Count)
            {
                this.data.Add(rabbit);

            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(x => x.Name == name);
            return data.Remove(rabbit);
        }

        public void RemoveSpecies(string species)
        {
            this.data = this.data.Where(x => x.Species != species).ToList();
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(x => x.Name == name);
            rabbit.Available = false;
            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbits = this.data.Where(x => x.Species == species).ToArray();
            for (int i = 0; i < rabbits.Length; i++)
            {
                rabbits[i].Available = false;
            }

            return rabbits;

        }

        public string Report()
        {
            this.data = this.data.Where(x => x.Available == true).ToList();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.data)
            {
                sb.AppendLine($"{rabbit.ToString().Trim()}");
            }

            return sb.ToString().Trim();
        }
    }
}
