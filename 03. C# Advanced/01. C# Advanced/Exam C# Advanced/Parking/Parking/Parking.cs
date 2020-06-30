using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();

        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.Capacity > Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = this.data.Where(x => x.Manufacturer == manufacturer).Where(x => x.Model == model).FirstOrDefault();
            return this.data.Remove(car);
        }

        public Car GetLatestCar()
        {
            return this.data.OrderByDescending(x => x.Year).FirstOrDefault();
           
        }

        public Car GetCar(string manufacturer, string model)
        {
            return this.data.Where(x => x.Manufacturer == manufacturer).Where(x => x.Model == model).FirstOrDefault();
           
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.data)
            {
                sb.AppendLine(car.ToString().Trim());
            }

            return sb.ToString().Trim();
            
        }
    }
}
