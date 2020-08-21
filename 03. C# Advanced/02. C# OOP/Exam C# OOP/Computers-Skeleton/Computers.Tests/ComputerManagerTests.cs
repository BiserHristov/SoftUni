using System;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Computer_ValidDataCreatesValidComputer()
        {
            var computer = new Computer("a", "b", 20.5M);

            Assert.That("a", Is.EqualTo(computer.Manufacturer));
            Assert.That("b", Is.EqualTo(computer.Model));
            Assert.That(20.5, Is.EqualTo(computer.Price));

        }

        [Test]
        public void ComputerManager_ValidDataCreatesValidComputerManager()
        {
            var manager = new ComputerManager();

            Assert.That(0, Is.EqualTo(manager.Computers.Count));
         
        }

        [Test]
        public void ComputerManager_AddNullComputerShouldThrow()
        {
            var manager = new ComputerManager();
            var computer = new Computer("a", "b", 20.5M);

            Assert.Throws<ArgumentNullException>(() => manager.AddComputer(null));

        }
        [Test]
        public void ComputerManager_AddDuplicateComputerShouldThrow()
        {
            var manager = new ComputerManager();
            var computer = new Computer("a", "b", 20.5M);
            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => manager.AddComputer(computer));

        }

        [Test]
        public void ComputerManager_AddValidComputerShouldIncreaseCount()
        {
            var manager = new ComputerManager();
            var computer = new Computer("a", "b", 20.5M);
            manager.AddComputer(computer);

            Assert.That(1, Is.EqualTo(manager.Count));
            
        }

        [Test]
        public void ComputerManager_GetComputer_ManufactureNullShouldThrow()
        {
            var manager = new ComputerManager();
          
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null,"a"));

        }

        [Test]
        public void ComputerManager_GetComputer_ModelNullShouldThrow()
        {
            var manager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("a", null));

        }

        [Test]
        public void ComputerManager_GetMissingComputerShouldThrow()
        {
            var manager = new ComputerManager();
            var computer = new Computer("a", "b", 20.5M);
            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => manager.GetComputer("f", "w"));

        }

        [Test]
        public void ComputerManager_GetExistingComputerShouldReturnValidComputer()
        {
            var manager = new ComputerManager();
            var computer = new Computer("a", "b", 20.5M);
            manager.AddComputer(computer);
            Computer serchedComputer = manager.GetComputer("a", "b");

            Assert.That("a", Is.EqualTo(computer.Manufacturer));
            Assert.That("b", Is.EqualTo(computer.Model));
            Assert.That(20.5, Is.EqualTo(computer.Price));


        }

        //[Test]
        //public void ComputerManager_RemmoveNullManufactureShouldThrow()
        //{
        //    var cm = new ComputerManager();

        //    Assert.Throws<ArgumentNullException>(() => cm.RemoveComputer(null, "s"));


        //}

        [Test]
        public void ComputerManager_RemmoveNullModelShouldThrow()
        {
            var cm = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => cm.RemoveComputer("s", null));


        }
        [Test]
        public void ComputerManager_RemoveComputerShouldDecreaseCount()
        {
            var manager = new ComputerManager();
            var computer = new Computer("a", "b", 20.5M);
            var computer2 = new Computer("c", "d", 30M);
            manager.AddComputer(computer);
            manager.AddComputer(computer2);

            var deletedComputer=manager.RemoveComputer("a","b");
           

            Assert.That("a", Is.EqualTo(deletedComputer.Manufacturer));
            Assert.That("b", Is.EqualTo(deletedComputer.Model));
            Assert.That(1, Is.EqualTo(manager.Count));

        }

        [Test]
        public void ComputerManager_GetComputersByManufacturer_NullManufactureShouldThrow()
        {
            var manager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => manager.GetComputersByManufacturer(null));

        }

        [Test]
        public void ComputerManager_GetComputersByManufacturer_ValidmannufactureShouldReturnValidCollection()
        {
            var manager = new ComputerManager();
            var computer = new Computer("a", "b", 20.5M);
            var computer2 = new Computer("c", "d", 30M);
            var computer3 = new Computer("a", "f", 70.6M);
            manager.AddComputer(computer);
            manager.AddComputer(computer2);
            manager.AddComputer(computer3);
            var collection = manager.GetComputersByManufacturer("a");

            Assert.That(2, Is.EqualTo(collection.Count));
            //Assert.That("a", Is.EqualTo(collection[0])));
            //Assert.That(1, Is.EqualTo(manager.Count));

        }
    }
}