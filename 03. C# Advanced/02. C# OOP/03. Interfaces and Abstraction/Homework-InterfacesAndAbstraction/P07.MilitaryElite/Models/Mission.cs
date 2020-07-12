using P07.MilitaryElite.Enumerations;
using P07.MilitaryElite.Exceptions;
using P07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string name, string state)
        {
            this.Name = name;
            this.State = ParseState(state);
        }
        public string Name { get; private set; }

        public States State { get; private set; }

        public void CompleteMission()
        {
            this.State = States.Finished;
        }

        private States ParseState(string stateString)
        {
            States state;

            bool parsed = Enum.TryParse<States>(stateString, false, out state);

            if (!parsed)
            {
                throw new InvalidMissionStateException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}
