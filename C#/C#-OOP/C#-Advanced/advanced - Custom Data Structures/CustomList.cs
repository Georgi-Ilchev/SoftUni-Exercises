using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading;

namespace advanced___Custom_Data_Structures
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;
        private int[] items;

        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (!this.IsValideIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (!IsValideIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index] = value;
            }
        }
        public int RemoveAt(int index)
        {
            if (!this.IsValideIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            //physically remove the item
            int removedItem = this.items[index];
            this.items[index] = default;
            this.ShiftToLeft(index);

            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            return removedItem;
        }
        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            items = copy;
        }
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            items = copy;
        }
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            //for (int i = this.Count - 1; i < this.items.Length; i++)
            //{
            //    this.items[i] = default;
            //}
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i < index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public void Insert(int index, int item)
        {
            if (!IsValideIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);
            this.items[index] = item;
            this.Count++;
        }
        public bool Contains(int searchedItem)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int currentEl = this.items[i];

                if (currentEl == searchedItem)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (!this.IsValideIndex(firstIndex) || !this.IsValideIndex(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            int elAtFirstIndex = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = elAtFirstIndex;

            //bitwise
            //x = x ^ y
            //y = x ^ y
            //x = x ^ y
            //this.items[firstIndex] = this.items[firstIndex] ^ this.items[secondIndex];
            //this.items[secondIndex] = this.items[firstIndex] ^ this.items[secondIndex];
            //this.items[firstIndex] = this.items[firstIndex] ^ this.items[secondIndex];
        }
        private bool IsValideIndex(int index)
    => index < this.Count;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                if (i == this.Count - 1)
                {
                    sb.Append($"{this.items[i]}");
                }
                else
                {
                    sb.Append($"{this.items[i]}, ");

                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
