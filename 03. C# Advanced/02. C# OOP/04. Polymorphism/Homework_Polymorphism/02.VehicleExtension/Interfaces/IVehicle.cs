namespace _02.VehicleExtension.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        int TankCapacity { get; }
        string Drive(double distance);
        void Refuel(double litres);
    }
}
