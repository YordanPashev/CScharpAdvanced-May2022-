using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        public EqualityScale(T rightElement, T leftElement)
        {
            this.RightElement = rightElement;
            this.LeftElement = leftElement;
        }

        public T RightElement { get; set; }
        public T LeftElement { get; set; }

        public bool AreEqual()
        {
            bool result = this.LeftElement.Equals(this.RightElement);
            return result;
        }
    }
}
