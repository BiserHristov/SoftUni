using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarsSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;

        }
        public Car(string model, Engine engine, int weight)
           : this(model, engine)

        {
            this.Weight = weight;


        }
        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)

        {
            this.Color = color;

        }
        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(this.Engine.ToString());
            sb.AppendLine($"  Weight: " + (this.Weight > 0 ? this.Weight.ToString() : "n/a"));
            sb.Append($"  Color: " + (this.Color != null ? this.Color : "n/a"));
            return sb.ToString();
        }
    }
}
