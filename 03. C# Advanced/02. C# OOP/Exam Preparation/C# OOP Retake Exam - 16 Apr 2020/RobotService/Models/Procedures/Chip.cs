using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);


            if (robot.IsChipped)
            {
                string msg = string.Format(ExceptionMessages.AlreadyChipped, robot.Name);
                throw new ArgumentException(msg);
            }

            robot.IsChipped = true;
            robot.Happiness -= 5;
            this.Robots.Add(robot);
        }
    }


}
