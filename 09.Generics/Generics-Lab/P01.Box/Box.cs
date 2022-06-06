using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> internalList = new List<T>();

        public void Add(T element)
        {
            internalList.Add(element);
        }

        public int Count => internalList.Count;

        public T Remove()
        {
            T element = internalList[internalList.Count - 1];
            internalList.RemoveAt(internalList.Count - 1);
            return element;
        }
    }
}
