using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01.ActionPoint
{
    public class ActionPoint
    {
        public static void Main()
        {
            Action<string> printName = x => Console.WriteLine(x);

            Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .ToList()
                 .ForEach(printName);

        }
    }
}
