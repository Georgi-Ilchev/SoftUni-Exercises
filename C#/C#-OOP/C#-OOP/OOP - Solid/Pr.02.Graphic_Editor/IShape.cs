using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._02.Graphic_Editor
{
    public interface IShape
    {
        //1
        //void Draw()
        //{
        //    Console.WriteLine($"I drawing {this.GetType().Name}");
        //}

        //2
        void Draw();
    }
}
