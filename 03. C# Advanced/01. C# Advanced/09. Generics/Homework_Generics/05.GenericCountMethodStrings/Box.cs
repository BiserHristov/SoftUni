using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T> where T : IComparable
    {
        private List<T> values;
        public Box()
        {
            this.values = new List<T>();
        }
        public List<T> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        public int GreaterElementsCount(T element)
        {
            int count = 0;

            foreach (var item in this.Values)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
