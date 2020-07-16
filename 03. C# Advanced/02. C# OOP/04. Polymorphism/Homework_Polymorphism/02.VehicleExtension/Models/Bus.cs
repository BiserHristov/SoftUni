namespace _02.VehicleExtension.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_INCREASE_COEFICIENT = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption + FUEL_INCREASE_COEFICIENT, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= FUEL_INCREASE_COEFICIENT;
            return base.Drive(distance);
        }

    }
}
