using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodString
{
    public class SwapMe<T>
    {
        public List<T> Values { get; set; } = new List<T>();
        public SwapMe(List<T> value)
        {
            this.Values = value;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            //range 
            //bool isInRange = firstIndex >= 0 && firstIndex < this.Values.Count &&
            //                secondIndex >= 0 && secondIndex < this.Values.Count;
            //if (!isInRange)
            //{
            //    throw new InvalidOperationException("Values is not in range!");
            //}

            T tempValue = this.Values[firstIndex];
            this.Values[firstIndex] = this.Values[secondIndex];
            this.Values[secondIndex] = tempValue;
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
