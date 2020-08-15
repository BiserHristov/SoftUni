namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ComputerTests
    {
        private Computer computer;
        private Part part;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Computer_ValidDataShouldCreateValicComputer()
        {
            computer = new Computer("a");
            Assert.That("a", Is.EqualTo(computer.Name));
            Assert.That(0, Is.EqualTo(computer.Parts.Count));
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]

        public void Computer_InvalidNameShouldThrow(string name)
        {

            Assert.Throws<ArgumentNullException>(() => computer = new Computer(name));
        }

        [Test]
        public void Computer_AddpartWithValidDAta()
        {
            computer = new Computer("a");
            part = new Part("p", 10);
            Part newpart = new Part("c", 30);

            computer.AddPart(part);
            computer.AddPart(newpart);
            Assert.That(2, Is.EqualTo(computer.Parts.Count));
      
        }

        [Test]
        public void Computer_AddpartWithNullValueShouldThrow()
        {
            computer = new Computer("a");

         

            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void Computer_TotalPriceWorksAsExpected()
        {
            computer = new Computer("a");
            part = new Part("p", 10);
            Part newpart = new Part("c", 30);

            computer.AddPart(part);
            computer.AddPart(newpart);
            Assert.That(40, Is.EqualTo(computer.TotalPrice));

        }

        [Test]
        public void Computer_RemovePartWorksAsExpected()
        {
            computer = new Computer("a");
            part = new Part("p", 10);
            Part newpart = new Part("c", 30);
            Part testpart = new Part("c", 80);


            computer.AddPart(part);
            computer.AddPart(newpart);
            computer.AddPart(testpart);

            computer.RemovePart(part);
            Assert.That(2, Is.EqualTo(computer.Parts.Count));

        }

        [Test]
        public void Computer_GetPartWorksAsExpected()
        {

            computer = new Computer("a");
            part = new Part("p", 10);
            Part newpart = new Part("c", 30);
            Part testpart = new Part("d", 80);

            computer.AddPart(part);
            computer.AddPart(newpart);
            computer.AddPart(testpart);

            Part result = computer.GetPart("c");
            Assert.That("c", Is.EqualTo(result.Name));
            Assert.That(30, Is.EqualTo(result.Price));


        }
    }
}