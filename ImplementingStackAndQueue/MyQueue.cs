using System;

namespace CustomDataStructures
{
    public class MyQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] elements;
        
        public MyQueue()
        {
            elements = new T[DefaultCapacity];
            Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (Count >= elements.Length)
            {
                Resize();
            }

            elements[Count] = item;
            Count++;
        }

        public T Dequeue()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException();
            }

            T removedElement = elements[0];
            T[] dequeuedArr = new T[Count - 1];

            for (int i = 1; i < Count; i++)
            {
                dequeuedArr[i - 1] = elements[i];
            }

            Count--;
            elements = dequeuedArr;
            return removedElement;
        }

        public T Peek()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }

        public void Clear()
        {
            T[] clearArray = new T[DefaultCapacity];
            elements = clearArray;
            Count = 0;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]);
            }
        }

        private void Resize()
        {
            T[] newArray = new T[Count * 2];

            for (int i = 0; i < elements.Length; i++)
            {
                newArray[i] = elements[i];
            }

            elements = newArray;
        }
    }
}
