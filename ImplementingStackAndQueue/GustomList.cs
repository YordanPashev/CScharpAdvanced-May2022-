using System;

namespace CustomDataStructures
{
    public class GustomList
    {
        private int[] elements;
        private int internalCounter;
        public GustomList()
        {
            elements = new int[2];

        }

        public int Count { get {return internalCounter; } }

        public int this[int i]
        {
            get
            {
                return elements[i];
            }

            set
            {
                elements[i] = value;
            }
        }

        public void Add(int element)
        {
            if (elements.Length == internalCounter)
            {
                int[] copyArray = new int[elements.Length * 2];

                for (int i = 0; i < elements.Length; i++)
                {
                    copyArray[i] = elements[i];
                }

                elements = copyArray; 
            }

            elements[internalCounter] = element;
            internalCounter++;
        }

        public void Shrink()
        {
            int[] newArray = new int[internalCounter];

            for (int i = 0;i < internalCounter; i++)
            {
                newArray[i] = elements[i];
            }

            elements =  newArray;
        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index > internalCounter - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            int elementToRemove = elements[index];

            for (int i = index; i < internalCounter - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            internalCounter--;

            return elementToRemove;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < internalCounter; i++)
            {
                if (elements[i]== element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex > internalCounter - 1 ||
                secondIndex < 0 || secondIndex > internalCounter - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            int firstElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;
        }
    }
}
