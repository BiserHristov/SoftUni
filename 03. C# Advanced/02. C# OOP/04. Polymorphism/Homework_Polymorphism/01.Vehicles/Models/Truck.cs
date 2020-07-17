namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {

        private const double FUEL_INCREASE_COEFICIENT = 1.6;
        public Truck(double quantity, double fuelConsumption)
            : base(quantity, fuelConsumption)
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
            this.FuelQuantity -= litres * 0.05;
        }

 
    }
}
