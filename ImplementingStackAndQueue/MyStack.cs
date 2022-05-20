using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataStructures
{
    public class MyStack<T>
    {
        private const int DefaultCapacity = 4;
        private int[] elements;

        public MyStack()
        {
            elements = new int[DefaultCapacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (Count >= elements.Length)
            {
                Resize();
            }

            elements[Count] = element;
            Count++;
        }

        public int Pop()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException();
            }

            int removedElement = elements[Count - 1];
            Count--;
            int[] popedArray = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                popedArray[i] = elements[i];
            }

            elements = popedArray;
            return removedElement;
        }

        public int Peek()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(this.elements[i]);
            }
        }

        private void Resize()
        {
            int[] newArray = new int[Count * 2];

            for (int i = 0; i < elements.Length; i++)
            {
                newArray[i] = elements[i];
            }

            elements = newArray;
        }
    }
}
