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
            int elementToRemove = elements[index];

            for (int i = index; i < internalCounter - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            internalCounter--;

            return elementToRemove;
        }
    }
}
