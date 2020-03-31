using System;
using System.Globalization;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class Login
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            string input = Console.ReadLine();

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }


            int counter = 0;
            while (password != input)
            {
                counter++;
                if (counter <= 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                input = Console.ReadLine();

            }

            Console.WriteLine($"User {username} logged in.");

        }
    }
}

