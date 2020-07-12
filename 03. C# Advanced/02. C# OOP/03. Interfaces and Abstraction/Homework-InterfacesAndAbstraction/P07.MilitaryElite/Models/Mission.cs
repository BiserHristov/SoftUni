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
            ParseState(state);
        }
        public string Name { get; private set; }

        public States State { get; private set; }

        public void CompleteMission()
        {
            this.State = States.Finished;
        }

        private void ParseState(string stateString)
        {
            States state;

            bool parsed = Enum.TryParse<States>(stateString, out state);

            if (!parsed)
            {
                throw new ArgumentException(string.Format(CommonExceptions.NotValidMissionMessage, stateString));
            }

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.Name} State: {this.State}";
        }
    }
}
