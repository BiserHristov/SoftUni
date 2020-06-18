﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class MyTuple<T, V>
    {
        private T item1;
        private V item2;

        public MyTuple(T item1, V item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        public T Item1
        {
            get { return this.item1; }
            set { this.item1 = value; }
        }
        public V Item2
        {
            get { return this.item2; }
            set { this.item2 = value; }
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }

    }
}
