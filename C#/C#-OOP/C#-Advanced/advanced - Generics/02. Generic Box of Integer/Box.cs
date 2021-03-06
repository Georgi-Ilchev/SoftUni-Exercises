using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Generic_Box_of_Integer
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public override string ToString()
        {
            return $"{this.Value.GetType()}: {Value}";
        }
    }
}
