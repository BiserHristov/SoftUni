namespace _02.VehicleExtension.Models
{
    public class Car : Vehicle
    {

        private const double FUEL_INCREASE_COEFICIENT = 0.9;
        private Car(double quantity, double fuelConsumption)
            : base(quantity, fuelConsumption)
        {
        }

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
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

        
    }
}
