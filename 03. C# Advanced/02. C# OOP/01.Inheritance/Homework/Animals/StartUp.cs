using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            string type = Console.ReadLine();
            StringBuilder result = new StringBuilder();


            while (type != "Beast!")
            {
                try
                {
                    string[] args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    //string name = args[0];
                    //int age = int.Parse(args[1]);
                    //string gender = args[2];

                    string name = string.Empty;
                    int age = 0;
                    string gender = string.Empty;

                    for (int i = 0; i < args.Length; i++)
                    {

                        bool isNumeric = int.TryParse(args[i], out int parsedAge);

                        if (!isNumeric)
                        {
                            if (args[i] != "Male" &&
                            args[i] != "Female")
                            {

                                name = args[i];
                            }
                            else
                            {
                                gender = args[i];
                            }

                        }
                        else
                        {
                            age = parsedAge;
                        }


                    }


                    switch (type)
                    {
                        case "Dog":
                            var dog = new Dog(name, age, gender);
                            result.AppendLine(dog.ToString());
                            break;

                        case "Cat":
                            var cat = new Cat(name, age, gender);
                            result.AppendLine(cat.ToString());
                            break;

                        case "Frog":
                            var frog = new Frog(name, age, gender);
                            result.AppendLine(frog.ToString());
                            break;

                        case "Kitten":
                            var kitten = new Kitten(name, age);
                            result.AppendLine(kitten.ToString());
                            break;

                        case "Tomcat":
                            var tomcat = new Tomcat(name, age);
                            result.AppendLine(tomcat.ToString());
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");

                    }
                }
                catch (Exception m)
                {
                    result.AppendLine(m.Message);
                }



                type = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());

        }
    }
}
