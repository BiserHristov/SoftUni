using System;
using System.Text;

namespace _05.MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main()
        {
            string numberAsString = Console.ReadLine().TrimStart('0');
            int multiplier = int.Parse(Console.ReadLine().TrimStart('0'));
            StringBuilder sb = new StringBuilder();
            int addTens = 0;

            if (multiplier == 0)
            {
                sb.Append(0);
            }
            else
            {


                for (int i = numberAsString.Length - 1; i >= 0; i--)
                {

                    int result = int.Parse(numberAsString[i].ToString()) * multiplier + addTens;

                    if (result > 9)
                    {
                        addTens = result / 10;
                        result %= 10;
                    }
                    else
                    {
                        addTens = 0;
                    }

                    sb.Insert(0, result);
                }

                if (addTens > 0)
                {
                    sb.Insert(0, addTens);

                }
            }



            Console.WriteLine(sb.ToString());
        }
    }
}
