using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._09.ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get; }
        public string Country { get; }

        public void GetName()
        {
            //return $"Mr/Ms/Mrs { this.Name}";
        }
    }
}
