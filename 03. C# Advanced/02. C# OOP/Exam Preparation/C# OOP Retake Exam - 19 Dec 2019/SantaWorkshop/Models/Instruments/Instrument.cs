using System;
using System.Collections.Generic;
using System.Text;
using SantaWorkshop.Models.Instruments.Contracts;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get => this.power;
            private set
            {
                //TODO: Works properly?
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;

            }
        }
        public void Use()
        {
            this.Power -= 10;
        }

        public bool IsBroken()
        {
            return this.Power == 0;
        }
    }
}
