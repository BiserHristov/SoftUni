using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Rabbits
{
    public class Rabbit
    {
        public Rabbit(string name, string species)
            : this(name, species, true)
        {

        }
        public Rabbit(string name, string species, bool available)
        {
            this.Name = name;
            this.Species = species;
            this.Available = available;

        }
        public string Name { get; set; }
        public string Species { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return $"Rabbit ({this.Species}): {this.Name}";
        }
    }
}
