using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._02.Graphic_Editor
{
    public class Square : IShape
    {
        //1 - without draw here
        //2 - with draw here
        public void Draw()
        {
            Console.WriteLine($"I drawing {this.GetType().Name}");
        }
    }
}
