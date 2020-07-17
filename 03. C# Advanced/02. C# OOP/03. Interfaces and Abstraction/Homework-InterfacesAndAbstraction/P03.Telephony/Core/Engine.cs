using _03.Telephony.Interfaces;
using _03.Telephony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony.Core
{
    public class Engine
    {
        private List<string> phoneNumbers;
        private List<string> siteAddresses;
        public Engine()
        {
            this.phoneNumbers = new List<string>();
            this.siteAddresses = new List<string>();
        }
        public void Run()
        {
            this.phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            this.siteAddresses = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            Smarthphone smarthphone = new Smarthphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 10)
                    {
                        Console.WriteLine(smarthphone.Call(number));
                        continue;
                    }

                    Console.WriteLine(stationaryPhone.Call(number));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var site in siteAddresses)
            {
            
                try
                {
                    Console.WriteLine(smarthphone.Browse(site));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

        }
    }


}
