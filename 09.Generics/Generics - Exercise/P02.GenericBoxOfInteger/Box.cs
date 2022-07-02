using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfInteger
{
    public class Box<T>
    {
        private T digit;

        public Box(T digit)
        {
            this.digit = digit;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.digit}";
        }
    }
}
