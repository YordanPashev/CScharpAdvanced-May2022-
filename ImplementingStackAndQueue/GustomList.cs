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
                CheckIsInRange(i);
                return elements[i];
            }

            set
            {
                CheckIsInRange(i);
                elements[i] = value;
            }
        }

        public void Add(int element)
        {
            Risize();

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
            CheckIsInRange(index);

            int elementToRemove = elements[index];
            internalCounter--;

            for (int i = index; i < internalCounter; i++)
            {
                elements[i] = elements[i + 1];
            }

            return elementToRemove;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < internalCounter; i++)
            {
                if (elements[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIsInRange(firstIndex);
            CheckIsInRange(secondIndex);

            int firstElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;
        }

        private void Risize()
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
        }

        private void CheckIsInRange(int i)
        {
            if (i > internalCounter - 1 || i < 0)
            {
                throw new NotImplementedException();
            }
        }
    }
}
