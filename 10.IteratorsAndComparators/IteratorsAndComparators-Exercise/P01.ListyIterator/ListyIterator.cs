using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> collection;
        private int currIndex;
        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
            this.currIndex = 0;
        }

        public bool Move()
        {
            if (currIndex < collection.Count -1)
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

    }
}
