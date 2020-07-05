using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        protected string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        protected int Age
        {
            get
            {
                return this.age;
            }
            private set
            {

                bool isBlank = string.IsNullOrWhiteSpace(value.ToString());
                
                if (value <= 0 || isBlank || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        protected string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name.ToString());
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());
            return sb.ToString().Trim();
        }
    }
}
