using NUnit.Framework;

namespace Robots.Tests
{
    using System;
    [TestFixture]
    public class RobotsTests
    {
        private RobotManager rm;
        private Robot robot;

        [Test]
        public void RobotShouldBeCreatedWithValidData()
        {
            robot = new Robot("a", 10);
            Assert.That("a", Is.EqualTo(robot.Name));
            Assert.That(10, Is.EqualTo(robot.Battery));
            Assert.That(10, Is.EqualTo(robot.MaximumBattery));

        }

        [Test]
        public  void RobotManager_ConstructorCreateRobotManagerWithValidData()
        {
             rm = new RobotManager(10);
            Assert.That(10, Is.EqualTo(rm.Capacity));
            Assert.That(0, Is.EqualTo(rm.Count));

        }

        [Test]
        public  void RobotManager_InvalidCapacityShouldThrow()
        {

            Assert.Throws<ArgumentException>(() => rm = new RobotManager(-5));
        }


        [Test]
        public  void RobotManager_AddRobotWithwithvalidData()
        {
             rm = new RobotManager(5);
            robot= new Robot("a",10);
            rm.Add(robot);

            Assert.That(1, Is.EqualTo(rm.Count));

        }

        [Test]
        public  void RobotManager_AddRobotWithDuplicateNameShouldThrow()
        {
             rm = new RobotManager(5);
             robot = new Robot("a", 10);
             rm.Add(robot);


             Assert.Throws<InvalidOperationException>(() => rm.Add((robot)));
        }

        [Test]
        public void RobotManager_NotEnoughCapacityShouldThrow()
        {
            rm = new RobotManager(1);
            robot = new Robot("a", 10);
            var robot2 = new Robot("b", 10);
            
            rm.Add(robot);


            Assert.Throws<InvalidOperationException>(() => rm.Add((robot2)));
        }

        [Test]
        public void Remove_NotExistingRobotShouldThrow()
        {
            rm = new RobotManager(10);
            robot = new Robot("a", 10);
           

            rm.Add(robot);


            Assert.Throws<InvalidOperationException>(() => rm.Remove("b"));
        }

        [Test]
        public void Remove_ExistingRobotShouldWorkAsExpected()
        {
            rm = new RobotManager(10);
            robot = new Robot("a", 10);


            rm.Add(robot);
            rm.Remove("a");
            Assert.That(0, Is.EqualTo(rm.Count));

        }

        [Test]
        public void Work_NotExistingRobotShouldThrow()
        {
            rm = new RobotManager(10);
            robot = new Robot("a", 10);
            rm.Add(robot);

            Assert.Throws<InvalidOperationException>(() => rm.Work("b","job",10));

        }

        [Test]
        public void Work_HigherbatteryUsageShouldThrow()
        {
            rm = new RobotManager(10);
            robot = new Robot("a", 10);
            rm.Add(robot);

            Assert.Throws<InvalidOperationException>(() => rm.Work("a", "job", 20));

        }
        [Test]
        public void Work_ShouldWorkAsExpectedWithValidData()
        {
            rm = new RobotManager(10);
            robot = new Robot("a", 10);
            rm.Add(robot);
            rm.Work("a","job",4);

            Assert.That(6,Is.EqualTo(robot.Battery));

        }

        [Test]
        public void Charge_NotExistingRobotShouldThrow()
        {
            rm = new RobotManager(10);
            robot = new Robot("a", 10);
            rm.Add(robot);

            Assert.Throws<InvalidOperationException>(() => rm.Charge("b"));

        }

        [Test]
        public void Charge_ShouldWorkAsExpectedWithValidData()
        {
            rm = new RobotManager(10);
            robot = new Robot("a", 10);
            rm.Add(robot);
            rm.Work("a","job", 6);
            rm.Charge("a");

            Assert.That(10, Is.EqualTo(robot.Battery));

        }
    }
}
