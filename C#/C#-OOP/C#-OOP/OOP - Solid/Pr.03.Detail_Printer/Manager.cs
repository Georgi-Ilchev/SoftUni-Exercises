using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._03.Detail_Printer
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, Documents: {string.Join(", ",this.Documents)};";
        }
    }
}
