using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IRobot> robots;
        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        //protected?? or public
        public ICollection<IRobot> Robots => this.robots;

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());

            }

            return sb.ToString().Trim();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            
            robot.ProcedureTime -= procedureTime;
            //ToDO: Check < >
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }

        }
    }
}
