namespace _02.VehicleExtension.Models
{
    public class Truck : Vehicle
    {

        private const double FUEL_INCREASE_COEFICIENT = 1.6;
        public Truck(double quantity, double fuelConsumption, int tankCapacity)
            : base(quantity, fuelConsumption+ FUEL_INCREASE_COEFICIENT, tankCapacity)
        {
        }

  
        public override void Refuel(double litres)
        {
            base.Refuel(litres);
            this.FuelQuantity -= litres * 0.05;
        }


    }
}
