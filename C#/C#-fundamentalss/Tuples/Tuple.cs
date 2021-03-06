using System;
using System.Collections.Generic;
using System.Text;

namespace Tuples
{
    public class Tuple<TFirst,TSecond>
    {
        public TFirst Item1 { get; set; }
        public TSecond Item2 { get; set; }

        public Tuple(TFirst firstItem, TSecond secondItem)
        {
            this.Item1 = firstItem;
            this.Item2 = secondItem;
        }
        public override string ToString()
        {
            //return $"{Item1} -> {Item2}";
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Item1} -> {this.Item2}");
            return sb.ToString().TrimEnd();
        }

        //public override string ToString()
        //{
        //    return $"{Item1} -> {Item2}";
        //}
    }
}
