using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stoneValues = new List<int>();

        public Lake(List<int> stoneValues)
        {
            this.stoneValues = stoneValues;       
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stoneValues.Count; i+= 2)
            {
                yield return stoneValues[i];
            }

            if (stoneValues.Count % 2 == 0)
            {
                for (int i = stoneValues.Count - 1; i >= 0; i -= 2)
                {
                    yield return stoneValues[i];
                }
            }

            else
            {
                for (int i = stoneValues.Count - 2; i >= 0; i -= 2)
                {
                    yield return stoneValues[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
