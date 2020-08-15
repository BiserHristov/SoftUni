using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int CapacityValue = 10;

        private readonly Dictionary<string, IRobot> _robots;
        public Garage()
        {
            this._robots = new Dictionary<string, IRobot>();
        }
        public int Capacity => CapacityValue;

        public IReadOnlyDictionary<string, IRobot> Robots => this._robots;

        public void Manufacture(IRobot robot)
        {
            if (this._robots.Count == this.Capacity)
            {
                var message = ExceptionMessages.NotEnoughCapacity;
                throw new InvalidOperationException(message);
            }

            if (this._robots.ContainsKey(robot.Name))
            {
                var message = string.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(message);
            }

            this._robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this._robots.ContainsKey(robotName))
            {
                var message = string.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(message);
            }

            var robot = this._robots.First(r => r.Key == robotName).Value;

            robot.Owner = ownerName;
            robot.IsBought = true;
            this._robots.Remove(robotName);
        }





        //    private const int Max_Capacity = 10;
        //    private IDictionary<string, IRobot> robots;


        //    public Garage()
        //    {
        //        this.robots = new Dictionary<string, IRobot>();
        //    }

        //    public IReadOnlyDictionary<string, IRobot> Robots => (IReadOnlyDictionary<string, IRobot>)this.robots;
        //    public int Capacity => Max_Capacity;

        //    public void Manufacture(IRobot robot)
        //    {
        //        if (this.Robots.Count==Max_Capacity)
        //        {
        //            throw new InvalidOperationException("Not enough capacity");
        //        }

        //        if (this.Robots.ContainsKey(robot.Name))
        //        {
        //            throw new ArgumentException($"Robot {robot.Name} already exist");
        //        }

        //        this.robots.Add(robot.Name, robot);
        //    }

        //    public void Sell(string robotName, string ownerName)
        //    {
        //        if (!this.Robots.ContainsKey(robotName))
        //        {
        //            throw new ArgumentException($"Robot {robotName} does not exist");
        //        }

        //        Robot robot = this.robots.FirstOrDefault(r => r.Key == robotName).Value as Robot;
        //        robot.Owner = ownerName;
        //        //

        //        //Check maybe isBought should be true

        //        robot.IsBought = true;

        //        this.robots.Remove(robotName);
        //    }
    }
}
