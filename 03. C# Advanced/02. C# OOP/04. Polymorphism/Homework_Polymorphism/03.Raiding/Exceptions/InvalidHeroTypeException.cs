using System;

namespace Raiding.Exceptions
{
    public class InvalidHeroTypeException : Exception
    {
        private const string InvalidHeroTypeMessage = "Invalid hero!";

        public InvalidHeroTypeException()
            : base(InvalidHeroTypeMessage)
        {
        }

        public InvalidHeroTypeException(string message)
            : base(message)
        {
        }
    }
}
