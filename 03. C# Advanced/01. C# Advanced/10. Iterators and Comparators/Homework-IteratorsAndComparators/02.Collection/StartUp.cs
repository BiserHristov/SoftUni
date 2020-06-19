using System;
using System.Linq;
using System.Text;

namespace _02.Collection
{
    public class StartUp
    {
        public static void Main()
        {
            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            ListyIterator<string> listyIterator = new ListyIterator<string>(data.ToList());
            StringBuilder sb = new StringBuilder();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move":
                        bool moveResult = listyIterator.Move();
                        sb.AppendLine(moveResult.ToString());
                        break;

                    case "Print":
                        string printResult = listyIterator.Print();
                        sb.AppendLine(printResult);
                        break;

                    case "HasNext":
                        bool hasNextResult = listyIterator.HasNext();
                        sb.AppendLine(hasNextResult.ToString());
                        break;

                    case "PrintAll":
                        StringBuilder result = new StringBuilder();

                        foreach (var item in listyIterator)
                        {
                            result.Append($"{item} ");
                        }

                        sb.AppendLine(result.ToString().Trim());

                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(sb.ToString());

        }
    }
}
