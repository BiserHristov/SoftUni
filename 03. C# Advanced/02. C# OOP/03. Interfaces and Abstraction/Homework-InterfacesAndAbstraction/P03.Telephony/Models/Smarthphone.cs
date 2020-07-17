using _03.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony.Models
{
    public class Smarthphone : IBrowseable, ICallable
    {


        public string Browse(string site)
        {
            if (site.Any(Char.IsDigit))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {site}!";
        }
        public string Call(string number)
        {
            if (!number.All(Char.IsDigit))
            {
                return "Invalid number!";
            }

            return $"Calling... {number}";
        }

        private bool ValidateAddress(string address)
        {
            for (int i = 0; i < address.Length; i++)
            {
                if (char.IsDigit(address[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
