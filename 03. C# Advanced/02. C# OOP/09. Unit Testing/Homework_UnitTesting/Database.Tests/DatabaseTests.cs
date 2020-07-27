using NUnit.Framework;
using DatabaseProblem; //You should comment this "using" for submitting in Judge
namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database db;
        [SetUp]
        public void Setup()
        {
        }

        //Constructor
        [Test]
        public void ConstructorWorksNormalyWithValidData()
        {

            db = new Database(new int[] { 1, 2, 3, 4 });
            Assert.That(db.Count, Is.EqualTo(4));
        }

        [Test]
        public void ConstructorWorksNormalyWithEmptyData()
        {

            db = new Database(new int[] {});
            Assert.That(db.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorThrowsExceptionWithDataOverCapacity()
        {

            Assert.That(() => db = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 }), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));

        }


        //Remove
        [Test]
        public void RemoveMethodWorksAsExpectedWithValidData()
        {
            db = new Database(new int[] { 1, 2, 3, 4 });
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveMethodThrowsWithEmptyData()
        {
            db = new Database(new int[] { });

            Assert.That(() => db.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        //Fetch
        [Test]
        public void FetchMetodWorksAsExpectedWithvalidData()
        {
            var inputData = new int[] { 1, 2, 3, 4 };
            db = new Database(inputData);
            var data = new int[4];
            data = db.Fetch();
            for (int i = 0; i < 4; i++)
            {
                Assert.That(data[i], Is.EqualTo(inputData[i]));
            }
        }
    }
}