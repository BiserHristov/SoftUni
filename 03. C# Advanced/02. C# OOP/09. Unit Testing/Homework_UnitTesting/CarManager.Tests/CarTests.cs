using NUnit.Framework;
using CarManager; //You should comment this "using" for submitting in Judge
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ValidDataShouldReturnValidCar()
        {
            car = new Car("make", "model", 5, 50);

            Assert.That(0, Is.EqualTo(car.FuelAmount));
            Assert.That("make", Is.EqualTo(car.Make));
            Assert.That("model", Is.EqualTo(car.Model));
            Assert.That(5, Is.EqualTo(car.FuelConsumption));
            Assert.That(50, Is.EqualTo(car.FuelCapacity));

        }

        [TestCase(null)]
        [TestCase("")]
        public void Make_InvalidMakeShouldThrow(string make)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, "model", 5, 50));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Model_InvalidModelShouldThrow(string model)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make",model, 5, 50));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void FuelConsumption_InvalidFuelConsumptionShouldThrow(int fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", "model", fuelConsumption, 50));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void FuelCapacity_InvalidFuelCapacityShouldThrow(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", "model", 5, fuelCapacity));
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Refuel_InvalidFuelToRefuelShouldThrow(double fuelToRefuel)
        {
            car = new Car("make", "model", 5, 50);
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void Refuel_ValidFuelToRefuelLessThanCapacityShouldIncreaseFuelAmount()
        {
            car = new Car("make", "model", 5, 50);
            car.Refuel(20);

            Assert.That(20, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void Refuel_ValidFuelToRefuelMoreThanCapacityShouldMakeFuelAmountEqualToCapacity()
        {
            car = new Car("make", "model", 5, 50);
            car.Refuel(60);

            Assert.That(50, Is.EqualTo(car.FuelAmount));
        }

        [Test]
        public void Drive_FuelAmountIsNotEnoughForGivenDistance()
        {
            car = new Car("make", "model", 1, 100);
            Assert.Throws<InvalidOperationException>(() => car.Drive(150.0));

        }

        [Test]
        public void Drive_FuelAmountIsEnoughForGivenDistance()
        {
            car = new Car("make", "model", 10, 100);
            car.Refuel(100);
            car.Drive(60.0);

            Assert.That(94, Is.EqualTo(car.FuelAmount));


        }


    }
}