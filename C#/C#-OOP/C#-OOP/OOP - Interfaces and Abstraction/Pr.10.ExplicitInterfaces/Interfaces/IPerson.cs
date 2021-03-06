using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._10.ExplicitInterfaces.Interfaces
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public string GetName();
    }
}
