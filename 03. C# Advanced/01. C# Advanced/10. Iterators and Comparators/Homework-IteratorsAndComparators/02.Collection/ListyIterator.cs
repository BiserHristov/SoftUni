using System.Collections;
using System.Collections.Generic;
using System;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.List = list;
            this.index = 0;
        }

        public List<T> List { get; set; }
        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.List.Count)
            {
                return true;
            }

            return false;
        }

        public string Print()
        {
            try
            {
                return this.List[this.index].ToString();
            }
            catch (Exception)
            {
                return "Invalid Operation!";
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                yield return this.List[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
