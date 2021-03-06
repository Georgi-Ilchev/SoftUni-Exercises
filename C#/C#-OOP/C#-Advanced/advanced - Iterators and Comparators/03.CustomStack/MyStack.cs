using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.CustomStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> data;
        public MyStack()
        {
            this.data = new List<T>();
        }

        public int Count => this.data.Count;

        public void Push(params T[] elements)
        {
            if (this.Count == 0)
            {
                this.data = elements.ToList();
            }
            else
            {
                this.data.InsertRange(this.Count, elements);
            }
        }

        public void Pop()
        {
            if (this.Count > 0)
            {
                this.data.RemoveAt(this.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count-1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
