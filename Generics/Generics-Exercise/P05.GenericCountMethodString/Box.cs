using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        public Box()
        {
            listOfelements = new List<T>();
        }

        public List<T> listOfelements { get; set; } 

        public T Text { get; set; }

        public int GetCompareResult(string elementToCompare)
        {
            int countOfGreaterElements = 0;
            foreach (T element in listOfelements)
            {
                if (element.CompareTo(elementToCompare) > 0)
                {
                    countOfGreaterElements++;
                }
            }

            return countOfGreaterElements;
        }
    }
}
