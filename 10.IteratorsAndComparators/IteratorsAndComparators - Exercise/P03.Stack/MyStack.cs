using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> stack = new List<T>();

        public void Push(List<T> elements)
        {
            foreach (T element in elements)
            {
                this.stack.Add(element);
            }
        }
        public void Pop()
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("No elements");
                return;
            }

            T lastInElement = stack[stack.Count - 1];
            this.stack.Remove(lastInElement);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
