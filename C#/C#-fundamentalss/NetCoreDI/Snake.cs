using SillyGame.IO.Contracts;

namespace NetCoreDI
{
    public class Snake
    {
        private IWriter writer;

        public Snake(IWriter writer)
        {
            this.writer = writer;
        }

        public void DrawSnake()
        {
            writer.Write("Snake");
        }
    }
}
