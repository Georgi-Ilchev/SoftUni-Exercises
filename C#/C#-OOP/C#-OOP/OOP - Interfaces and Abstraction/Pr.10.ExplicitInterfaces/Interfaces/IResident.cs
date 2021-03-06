using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._10.ExplicitInterfaces.Interfaces
{
    public interface IResident
    {
        public string Name { get; }
        public string Country { get; }
        public string GetName();
    }
}
