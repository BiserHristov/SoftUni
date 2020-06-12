using System;
using System.Linq;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static double CalculateDifference(string firstDate, string secondDate)
        {
            int[] tokens = firstDate.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            DateTime dateOne = new DateTime(tokens[0], tokens[1], tokens[2]);

            tokens = secondDate.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            DateTime dateTwo = new DateTime(tokens[0], tokens[1], tokens[2]);

            return Math.Abs((dateOne - dateTwo).TotalDays);
        }
    }
}
