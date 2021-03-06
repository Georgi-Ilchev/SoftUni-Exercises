using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;
        public List<T> myList { get; set; }
        public ListyIterator(params T[] arr)
        {
            this.myList = arr.ToList();
        }

        public void Print()
        {
            if (this.myList.Any())
            {
                Console.WriteLine(this.myList[this.index]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public bool Move()
        {
            if (this.index < this.myList.Count - 1)
            {
                this.index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            return this.index < this.myList.Count - 1;
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", myList));
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.myList.Count; i++)
            {
                yield return this.myList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
