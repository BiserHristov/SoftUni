using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string NotValidMissionMessage = "Mission is not valid!";
        public InvalidMissionStateException()
            : base(NotValidMissionMessage)
        {
        }

        public InvalidMissionStateException(string message) : base(message)
        {
        }
    }
}
