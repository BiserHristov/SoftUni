using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public CustomStack()
        {
            this.Data = new List<T>();
            
        }
        public List<T> Data { get; set; }

        public void Push(T element)
        {
            this.Data.Add(element);
        }

        public void Pop()
        {
            if (this.Data.Count==0)
            {
                throw new InvalidOperationException("No elements");
            }
            
            //T element = this.Data.Last();
            this.Data.RemoveAt(this.Data.Count - 1);
            //return element.ToString();

        }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
