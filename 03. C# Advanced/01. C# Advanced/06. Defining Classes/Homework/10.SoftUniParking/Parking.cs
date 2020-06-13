using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        List<Car> cars;

        private int capacity;
        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }


        public List<Car> Cars { get; set; }

        public int Count
        {
            get { return this.Cars.Count(); }
           
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";

            }
            else if (this.Cars.Count == this.Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.Cars.Add(car);
                
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public string RemoveCar(string registrationNumber)
        {
            if (!this.Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                this.Cars = this.Cars.Where(x => x.RegistrationNumber != registrationNumber).ToList();
               
                return $"Successfully removed {registrationNumber}";
            }

        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                string currentReg = registrationNumbers[i];

                if (GetCar(currentReg)!=null)
                {
                    RemoveCar(currentReg);
                    
                }
            }
        }

        public Car GetCar(string regNumber)
        {
            return this.Cars.Where(x => x.RegistrationNumber == regNumber).FirstOrDefault();
        }


    }
}
