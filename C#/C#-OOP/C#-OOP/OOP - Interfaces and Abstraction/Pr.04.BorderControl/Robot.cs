using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._04.BorderControl
{
    public class Robot : IIdable
    {
        public string Model { get; set; }
        public string Id { get => this.Model; set { this.Model = value; } }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
