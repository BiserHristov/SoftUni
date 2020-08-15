using NUnit.Framework;

namespace Presents.Tests
{
    using System;
    [TestFixture]
    public class PresentsTests
    {


        [Test]
        public void Present_ValidDataShouldCreateValidPresent()
        {
            var present = new Present("a", 5.6);
            Assert.That("a", Is.EqualTo(present.Name));
            Assert.That(5.6, Is.EqualTo(present.Magic));

        }


        [Test]
        public void ValidDataCreatesValidBag()
        {
            var bag = new Bag();
            Assert.That(0, Is.EqualTo(bag.GetPresents().Count));

        }

        [Test]
        public void Create_NullPresentShouldThrow()
        {
            var bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));

        }

        [Test]
        public void Create_DuplicatePresentShouldThrow()
        {
            var bag = new Bag();
            var present = new Present("a", 5.6);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));

        }

        [Test]
        public void Create_ValidPresentShouldAddPresentToCollection()
        {
            var bag = new Bag();
            var present = new Present("a", 5.6);
            string result= bag.Create(present);
            string message = $"Successfully added present {present.Name}.";

            Assert.That(1, Is.EqualTo(bag.GetPresents().Count));
            Assert.That(message, Is.EqualTo(result));

        }

        [Test]
        public void Remove_ValidDataShouldRemovePresent()
        {
            var bag = new Bag();
            var present = new Present("a", 5.6);
            bag.Create(present);
            var result=bag.Remove(present);
            Assert.That(0, Is.EqualTo(bag.GetPresents().Count));
            Assert.That(true, Is.EqualTo(result));


        }

        [Test]
        public void GetPresentWithLeastMagic_Remove_ValidDataShouldWorkAsExpected()
        {
            var bag = new Bag();
            var present = new Present("a", 5.6);
            var present3 = new Present("c", 0.3);
            var present2 = new Present("b", 7.9);

            bag.Create(present);
            bag.Create(present3);
            bag.Create(present2);

            var result = bag.GetPresentWithLeastMagic();

            Assert.That("c", Is.EqualTo(result.Name));
            Assert.That(0.3, Is.EqualTo(result.Magic));


        }

        [Test]
        public void GetPresent_ValidNameShouldReturnValidRPresent()
        {
            var bag = new Bag();
            var present = new Present("a", 5.6);
            var present3 = new Present("c", 0.3);
            var present2 = new Present("b", 7.9);

            bag.Create(present);
            bag.Create(present3);
            bag.Create(present2);

            var result = bag.GetPresent("b");

            Assert.That("b", Is.EqualTo(result.Name));

        }
    }
}
