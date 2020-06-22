using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Lake<int> lake = new Lake<int>(list);

             Console.WriteLine(string.Join(", ", lake));
            //StringBuilder result = new StringBuilder();
            //foreach (var item in lake)
            //{
            //    result.Append($"{item}, ");
            //}
            //Console.WriteLine(result.ToString().Trim(new char[] { ' ',','}));
        }
    }
}
