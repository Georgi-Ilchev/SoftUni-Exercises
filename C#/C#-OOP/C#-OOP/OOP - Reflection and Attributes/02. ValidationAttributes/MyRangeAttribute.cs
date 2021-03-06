using System;

namespace _02._ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int min;
        private int max;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.min = minValue;
            this.max = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException();
            }

            int valueAsInt = (int)obj;

            //1
            //if (valueAsInt >= min && valueAsInt <= max)
            //{
            //    return true;
            //}
            //return false;

            //2
            if (valueAsInt < min || valueAsInt > max)
            {
                return false;
            }
            return true;
        }
    }
}
