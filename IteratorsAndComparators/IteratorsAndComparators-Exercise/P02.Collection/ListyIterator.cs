using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp43
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currIndex;
        private int iterationIndex;
        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
            this.currIndex = 0;
            iterationIndex = -1;
        }

        public bool Move()
        {
            if (currIndex < collection.Count - 1)
            {
                currIndex++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }

            Console.WriteLine($"{this.collection[this.currIndex]}");
        }

        public bool HasNext() => currIndex + 1 < collection.Count;

        public void PrintAll()
        {
            foreach (T item in this.collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (++this.iterationIndex < this.collection.Count)
            {
                yield return collection[this.iterationIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
