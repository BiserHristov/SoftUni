using System;

namespace _02.AsciiSumator
{
    class AsciiSumator
    {
        static void Main(string[] args)
        {
            string line = "dsg12gr5653feee5";
            int number = 363;

            int sum = 0;
            string result = "";

            foreach (var item in line)
            {
                Console.WriteLine((int)item);
            }

            for (int i = 0; i < line.Length; i++)
            {
                for (int j = i; j < line.Length; j++)
                {
                    result += line[j];
                    if (char.IsDigit(line[j]))
                    {
                        sum += int.Parse(line[j].ToString());
                    }
                    else
                    {
                        
                    sum += line[j];

                    }
                    if (sum == number)
                    {
                        Console.WriteLine(result);
                        break;
                    }
                    if (sum > number)
                    {
                        sum = 0;
                        result = "";
                        break;
                    }

                }
               
            }













            //string startSymbol = Console.ReadLine();
            //string endSymbol = Console.ReadLine();
            //string line = Console.ReadLine();

            //int startIndex = -1;
            //int endIndex = -1;

            //if (line.IndexOf(startSymbol) < 0)
            //{
            //    startIndex = 0;

            //}
            //else
            //{
            //    startIndex = line.IndexOf(startSymbol) + 1;
            //}

            //if (line.IndexOf(endSymbol) < 0)
            //{
            //    endIndex = line.Length - 1;

            //}
            //else
            //{
            //    endIndex = line.IndexOf(endSymbol) - 1;
            //}

            //int sum = 0;

            //for (int i = startIndex; i <= endIndex; i++)
            //{
            //    sum += line[i];
            //}

            //Console.WriteLine(sum);
        }
    }
}
