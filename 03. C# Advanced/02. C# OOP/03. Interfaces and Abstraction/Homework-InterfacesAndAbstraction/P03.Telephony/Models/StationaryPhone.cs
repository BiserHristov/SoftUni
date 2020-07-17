using _03.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(Char.IsDigit))
            {
                return "Invalid number!";
            }
            return $"Dialing... {number}";
        }
    }
}
