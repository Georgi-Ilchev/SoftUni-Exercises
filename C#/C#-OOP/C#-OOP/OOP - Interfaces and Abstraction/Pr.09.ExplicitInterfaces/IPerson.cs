using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._09.ExplicitInterfaces
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }

        public void GetName()
        {
            //return $"{ this.Name}";
        }
    }
}
