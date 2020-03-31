using System;

namespace _04._Password_Validator
{
    class Start
    {
        static void Main()
        {
            //            4.Password Validator
            //Write a program that checks if a given password is valid.Password rules are:
            //•	6 – 10 characters(inclusive)
            //•	Consists only of letters and digits
            //•	Have at least 2 digits
            //If a password is valid print "Password is valid".If it is not valid, for every unfulfilled rule print a message:
            //•	"Password must be between 6 and 10 characters"
            //•	"Password must consist only of letters and digits"
            //•	"Password must have at least 2 digits"


            string line = Console.ReadLine();

            ValidatePassword(line);

        }

        static bool IsValidLenght(string input)
        {
            bool isValid = false;
            if (input.Length >= 6 && input.Length <= 10)
            {
                isValid = true;
            }

            return isValid;
        }

        static bool CheckForDigitsAndLetters(string input)
        {
            bool isValid = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetterOrDigit(input[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;

        }

        static bool CheckForDigits(string input)
        {
            bool isValid = false;
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    count++;
                    if (count == 2)
                    {
                        isValid = true;
                        break;
                    }
                }
            }

            return isValid;

        }

        static void ValidatePassword(string password)
        {
            if (IsValidLenght(password) &&
                CheckForDigitsAndLetters(password) &&
                CheckForDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!IsValidLenght(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }

                if (!CheckForDigitsAndLetters(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }

                if (!CheckForDigits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }
    }
}
