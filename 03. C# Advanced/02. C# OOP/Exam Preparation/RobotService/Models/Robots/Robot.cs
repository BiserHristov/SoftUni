using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private const string InvalidMessage = "Invalid {0}";
        //private string name;
        private int energy;
        private int happiness;
       // private int procedureTime;
        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;
            this.Owner = "Service";
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;

        }

        public string Name { get; }
        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(string.Format(InvalidMessage, nameof(happiness)));
                }

                this.happiness = value;
            }
        }



        public int Energy
        {
            get => this.energy;
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(string.Format(InvalidMessage, nameof(energy)));
                }

                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        private static bool IsValid(int value)
        {
            return 0 <= value && value <= 100;
        }

        public override string ToString()
        {
            return " Robot type: {robot type} - {robot name} - Happiness: {robot happiness} - Energy: {robot energy}";
        }
    }
}
