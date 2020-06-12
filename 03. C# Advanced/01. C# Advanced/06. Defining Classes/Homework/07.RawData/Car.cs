using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _07.RawData
{
    public class Car
    {

        private Engine engine;
        private Cargo cargo;
        private List<Tyre> tyres;
        private string model;
        public Car(string model,Engine engine, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = new List<Tyre>();

        }



        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public List<Tyre> Tyres
        {
            get { return this.tyres; }
            set { this.tyres = value; }
        }
    }
}

