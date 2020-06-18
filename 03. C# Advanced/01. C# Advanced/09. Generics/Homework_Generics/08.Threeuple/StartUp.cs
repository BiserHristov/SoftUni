using System;
using System.Linq;
using System.Text;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split().ToArray();

            string name = string.Join(" ", data.Take(2));
            string address = string.Join(" ", data.Skip(2).Take(1));
            string town = string.Join(" ", data.Skip(3).Take(data.Length - 3));

            var sb = new StringBuilder();

            var myTuple = new MyTuple<string, string, string>(name, address, town);
            sb.AppendLine(myTuple.ToString());



            data = Console.ReadLine().Split().ToArray();
            name = string.Join(" ", data.Take(1));
            string ageAsString = string.Join(" ", data.Skip(1).Take(1));
            string condition = string.Join(" ", data.Skip(2).Take(1));
            bool isDrunk = condition == "drunk" ? true : false;
            var myTuple2 = new MyTuple<string, int, bool>(name, int.Parse(ageAsString), isDrunk);
            sb.AppendLine(myTuple2.ToString());


            data = Console.ReadLine().Split().ToArray();
            name = string.Join(" ", data.Take(1));
            string doubleValueAsString = string.Join(" ", data.Skip(1).Take(1));
            string bank = string.Join(" ", data.Skip(2).Take(1));
            var myTuple3 = new MyTuple<string, double, string>(name, double.Parse(doubleValueAsString), bank);
            sb.AppendLine(myTuple3.ToString());

            Console.WriteLine(sb.ToString());

        }
    }
}
