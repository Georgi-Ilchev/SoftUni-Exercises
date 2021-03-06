using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
{
    public class Counter<T> where T : IComparable
    {
        public List<T> Values { get; set; } = new List<T>();
        public Counter(List<T> value)
        {
            this.Values = value;
        }
        public int GetCountOfGreaterValues(T value)
        {
            int counter = 0;

            foreach (T currentValue in this.Values)
            {
                if (value.CompareTo(currentValue) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T value in this.Values)
            {
                sb.AppendLine($"{value.GetType()}: {value}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
