using System;

namespace Pr._02.Graphic_Editor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.DrawShape(new Circle());
            graphicEditor.DrawShape(new Rectangle());
            graphicEditor.DrawShape(new Square());
        }
    }
}
