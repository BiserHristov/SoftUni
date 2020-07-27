using ExtendedDatabaseProblem; //You should comment this "using" for submitting in Judge
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_EmptyDataShouldReturnZeroCount()
        {
            ExtendedDatabase ed = new ExtendedDatabase();

            int expectedResult = 0;
            int actualResult = ed.Count;

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Constructor_ValidDataWithTwoPeopleShouldReturnTwoCount()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "3");

            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson);

            int expectedResult = 2;
            int actualResult = ed.Count;

            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void Constructor_DataWith17PeopleShouldThrow()
        {
            Person[] persons = new Person[17];

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));

        }

        [Test]
        public void Add_Add17thPersonShouldThrow()
        {

            Person[] persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, i.ToString() + "a");
            }

            ExtendedDatabase ed = new ExtendedDatabase(persons);

            Person person = new Person(1000, "a");

            Assert.Throws<InvalidOperationException>(() => ed.Add(person));


        }

        [Test]
        public void Add_AddDuplicateByNamePersonShouldThrow()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(100, "a");

            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson);

            Assert.Throws<InvalidOperationException>(() => ed.Add(testPerson));

        }

        [Test]
        public void Add_AddDuplicateByIdPersonShouldThrow()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(1, "c");

            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson);

            Assert.Throws<InvalidOperationException>(() => ed.Add(testPerson));

        }


        [Test]
        public void Remove_EmptyDataShouldThrow()
        {
            ExtendedDatabase ed = new ExtendedDatabase();


            Assert.Throws<InvalidOperationException>(() => ed.Remove());

        }

        [Test]
        public void Remove_OnePersonSholdDecreaseCountByOne()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(3, "c");

            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson, testPerson);
            ed.Remove();
            int expectedResult = 2;
            int actualResult = ed.Count;

            Assert.That(expectedResult, Is.EqualTo(actualResult));

        }


        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_EmptyDataShouldThrow(string name)
        {

            ExtendedDatabase ed = new ExtendedDatabase();

            Assert.Throws<ArgumentNullException>(() => ed.FindByUsername(name));

        }

        [Test]
        public void FindByUsername_MissingPersonByNameShouldThrow()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(3, "c");
            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson, testPerson);

            Assert.Throws<InvalidOperationException>(() => ed.FindByUsername("d"));

        }

        [Test]
        public void FindByUsername_ExistingPersonByNameShouldReturnPerson()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(3, "c");
            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson, testPerson);

            int expectedId = 2;
            string expectedName = "b";

            long actualId = ed.FindByUsername("b").Id;
            string actualName = ed.FindByUsername("b").UserName;

            Assert.That(expectedId, Is.EqualTo(actualId));
            Assert.That(expectedName, Is.EqualTo(actualName));


        }

        [Test]
        public void FindById_NegativeIdShouldThrow()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(3, "c");
            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson, testPerson);

            Assert.Throws<ArgumentOutOfRangeException>(() => ed.FindById(-1));
        }

        [Test]
        public void FindById_MissingIdShouldThrow()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(3, "c");
            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson, testPerson);

            Assert.Throws<InvalidOperationException>(() => ed.FindById(4));

        }

        [Test]
        public void FindByUsername_ExistingPersonByIdShouldReturnPerson()
        {
            Person person = new Person(1, "a");
            Person anotherPerson = new Person(2, "b");
            Person testPerson = new Person(3, "c");
            ExtendedDatabase ed = new ExtendedDatabase(person, anotherPerson, testPerson);

            int expectedId = 2;
            string expectedName = "b";

            long actualId = ed.FindById(2).Id;
            string actualName = ed.FindById(2).UserName;

            Assert.That(expectedId, Is.EqualTo(actualId));
            Assert.That(expectedName, Is.EqualTo(actualName));


        }
    }
}