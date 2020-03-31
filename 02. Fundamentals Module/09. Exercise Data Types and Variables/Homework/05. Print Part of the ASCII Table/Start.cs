using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Print_Part_of_the_ASCII_Table
{
    class Start
    {
        static void Main()
        {
            //            5.Print Part of the ASCII Table
            //Find online more information about ASCII(American Standard Code for Information Interchange) and write a program that prints part of the ASCII table of characters at the console.  On the first line of input you will receive the char index you should start with and on the second line - the index of the last character you should print.

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                Console.Write((char)i + " ");
            }

        }
    }
}
