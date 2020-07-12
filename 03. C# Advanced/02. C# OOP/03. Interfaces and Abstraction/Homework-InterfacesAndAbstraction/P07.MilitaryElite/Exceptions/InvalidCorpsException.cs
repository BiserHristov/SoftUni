using System;

namespace P07.MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string NotValidCorpsMessage = "Corp is not valid!";
        public InvalidCorpsException()
            : base(NotValidCorpsMessage)
        {
        }

        public InvalidCorpsException(string message) : base(message)
        {
        }
    }
}
