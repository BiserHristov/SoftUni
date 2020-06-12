using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace _08.CarsSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;

        }
        public Engine(string model, int power, int displacement )
          : this(model, power)
        {
            this.Displacement = displacement;
            
        }
        public Engine(string model, int power, int displacement, string efficiency )
            :this(model,power,displacement)
        {
            this.Efficiency = efficiency;
        }
        public string Efficiency
        {
            get { return this.efficiency; }
            set { this.efficiency = value; }
        }

        public int Displacement
        {
            get { return this.displacement; }
            set { this.displacement = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: " + (this.Displacement > 0 ? this.Displacement.ToString() : "n/a"));
            sb.Append($"    Efficiency: " + (this.Efficiency !=null ? this.Efficiency : "n/a"));
            return sb.ToString();
        }
    }
}
