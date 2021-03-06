using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}
