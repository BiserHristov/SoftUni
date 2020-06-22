using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private List<T> data;

        public Lake(List<T> data)
        {
            this.Data = data;
        }

        public List<T> Data { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            int lastIndex = this.Data.Count-1;
            for (int i = 0; i <= lastIndex; i += 2)
            {

                yield return this.Data[i];
            }

            if (lastIndex % 2 == 0)
            {
                lastIndex--;
            }

            for (int i =lastIndex; i >= 0; i-=2)
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
