namespace _02.VehicleExtension.Models
{
    public class Truck : Vehicle
    {

        private const double FUEL_INCREASE_COEFICIENT = 1.6;
        private Truck(double quantity, double fuelConsumption)
            : base(quantity, fuelConsumption)
        {
        }
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                base.FuelConsumption = value + FUEL_INCREASE_COEFICIENT;
            }
        }
        public override void Refuel(double litres)
        {
            base.Refuel(litres);
            this.FuelQuantity *= 0.05;
        }


    }
}
