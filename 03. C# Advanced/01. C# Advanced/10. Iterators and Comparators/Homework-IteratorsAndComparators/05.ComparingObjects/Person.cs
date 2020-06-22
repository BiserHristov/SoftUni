using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        //private List<Person> people;
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
            // this.People = new List<Person>();

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        // public List<Person> People { get; set; }

        public int CompareTo( Person other)
        {
            if (this.Name!=other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }
            else
            {
                if (this.Age != other.Age)
                {
                    return this.Age.CompareTo(other.Age);
                }
                else
                {
                    if (this.Town != other.Town)
                    {
                        return this.Town.CompareTo(other.Town);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }



    }
}
