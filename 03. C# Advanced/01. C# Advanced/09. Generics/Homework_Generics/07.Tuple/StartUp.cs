using System;
using System.Linq;
using System.Text;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split().ToArray();
            string town = string.Join(" ", data.TakeLast(1));
            string name = string.Join(" ", data.Take(data.Length - 1));

            var sb = new StringBuilder();

            var myTuple = new MyTuple<string, string>(name, town);
            sb.AppendLine(myTuple.ToString());

            data = Console.ReadLine().Split().ToArray();
            string numberAsString = string.Join(" ", data.TakeLast(1));
            name = string.Join(" ", data.Take(data.Length - 1));
            var myTuple2 = new MyTuple<string, int>(name, int.Parse(numberAsString));
            sb.AppendLine(myTuple2.ToString());

            data = Console.ReadLine().Split().ToArray();
            string doubleAsString = string.Join(" ", data.TakeLast(1));
            string intAsString = string.Join(" ", data.Take(data.Length - 1));
            var myTuple3 = new MyTuple<int, double>(int.Parse(intAsString), double.Parse(doubleAsString));
            sb.AppendLine(myTuple3.ToString());

            Console.WriteLine(sb.ToString());

        }
    }
}
