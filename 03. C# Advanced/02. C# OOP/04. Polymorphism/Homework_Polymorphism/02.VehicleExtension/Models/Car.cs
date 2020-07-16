namespace _02.VehicleExtension.Models
{
    public class Car : Vehicle
    {

        private const double FUEL_INCREASE_COEFICIENT = 0.9;
        public Car(double quantity, double fuelConsumption, int tankCapacity)
            : base(quantity, fuelConsumption+ FUEL_INCREASE_COEFICIENT, tankCapacity)
        {
        }



    }
}
