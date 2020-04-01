using System;
using System.Text;

namespace _07.StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int additionalStrength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '>')
                {
                    sb.Append(input[i]);
                }
                else
                {
                    sb.Append('>');
                    int strength = int.Parse(input[i + 1].ToString());

                    if (strength == 0)
                    {
                        continue;
                    }
                    else if (strength == 1)
                    {
                        i++;
                        continue;

                    }

                    int endindex = i + strength + additionalStrength;
                    if (endindex > input.Length - 1)
                    {
                        endindex = input.Length - 1;
                    }

                    for (int j = i + 1; j <= endindex; j++)
                    {
                        if (input[j] == '>')
                        {
                            if (endindex == j)
                            {
                                additionalStrength++;
                            }
                            else
                            {

                                additionalStrength += endindex - j;
                            }
                            i = j - 1;
                            break;

                        }
                        else
                        {
                            i = j;
                            additionalStrength = 0;
                        }

                    }
                }

            }

            Console.WriteLine(sb.ToString());

        }
    }
}