using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Generic_Count_Method_Double
{
    public class Box<T> where T: IComparable
    {
        public List<T> Values { get; set; } = new List<T>();
        public Box(List<T> value)
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
