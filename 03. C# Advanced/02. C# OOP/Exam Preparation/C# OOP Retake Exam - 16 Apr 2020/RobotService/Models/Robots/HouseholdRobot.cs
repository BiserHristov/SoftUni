using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Robots
{
    public class HouseholdRobot : Robot
    {
        public HouseholdRobot(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime)
        {
        }

        //public override string ToString()
        //{
        //    return string.Format(base.ToString(),this.GetType().Name,this.Name,this.Happiness,this.Energy);
        //}
    }
}
