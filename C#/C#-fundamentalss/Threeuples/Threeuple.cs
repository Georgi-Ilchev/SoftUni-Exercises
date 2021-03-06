using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuples
{
    public class Threeuple<TFirst,TSecond,TThird>
    {
        public Threeuple(TFirst first, TSecond second, TThird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        public TThird Third { get; set; }
        public override string ToString()
        {
            //return $"{this.First} -> {this.Second} -> {this.Third}".ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.First} -> {this.Second} -> {this.Third}");
            return sb.ToString().TrimEnd();
        }
    }
}
