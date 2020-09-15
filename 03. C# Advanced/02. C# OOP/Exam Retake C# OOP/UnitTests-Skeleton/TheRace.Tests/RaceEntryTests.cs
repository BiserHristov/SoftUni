using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitDriver driver;
        private RaceEntry race;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitDriver_NullnameThrows()
        {

            Assert.Throws<ArgumentNullException>(() => driver = new UnitDriver(null, new UnitCar("a", 10, 10.5)));
        }

        [Test]
        public void UnitDriver_REturnName()
        {
            driver = new UnitDriver("pesho", new UnitCar("a", 10, 10.5));
            Assert.AreEqual("pesho", driver.Name);
        }

        [Test]
        public void UnitDriver_REturnCar()
        {
            driver = new UnitDriver("pesho", new UnitCar("a", 10, 10.5));
            Assert.AreEqual("a", driver.Car.Model);
        }

        [Test]
        public void Race()
        {
            race = new RaceEntry();

            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        public void Race_AddNullDriver()
        {
            race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void Race_AddDuplicateDriver()
        {
            race = new RaceEntry();
            driver = new UnitDriver("a", new UnitCar("a", 10, 10.5));
            UnitDriver driver2 = new UnitDriver("a", new UnitCar("b", 100, 10.5));
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver2));
        }

        [Test]
        public void Race_AddDriver()
        {
            race = new RaceEntry();
            driver = new UnitDriver("a", new UnitCar("a", 10, 10.5));
            UnitDriver driver2 = new UnitDriver("f", new UnitCar("b", 100, 10.5));
            race.AddDriver(driver);
            race.AddDriver(driver2);

            Assert.AreEqual(2, race.Counter);
        }

        [Test]
        public void Race_AddDriverMessage()
        {
            race = new RaceEntry();
            driver = new UnitDriver("a", new UnitCar("a", 10, 10.5));
    
            string realresult=race.AddDriver(driver);
            string expectedMessage = $"Driver {driver.Name} added in race.";

            Assert.AreEqual(expectedMessage, realresult);
        }

        [Test]
        public void AverageHp_Throws()
        {
            race = new RaceEntry();
            driver = new UnitDriver("a", new UnitCar("a", 10, 10.5));
           
            race.AddDriver(driver);


            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void AverageHp_calculate()
        {
            race = new RaceEntry();
            driver = new UnitDriver("a", new UnitCar("a", 200, 10.5));
            UnitDriver driver2 = new UnitDriver("f", new UnitCar("b", 100, 10.5));
            race.AddDriver(driver);
            race.AddDriver(driver2);

            Assert.AreEqual(150, race.CalculateAverageHorsePower());
        }
    }
}