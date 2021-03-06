using NetCoreDI;
using SillyGame.IO.Contracts;

namespace SillyGame
{
    public class Engine
    {
        private IWriter writer;
        private IReader reader;
        private Snake snake;

        
        public Engine(IReader reader, IWriter writer, Snake snake)
        {
            this.writer = writer;
            this.reader = reader;
            this.snake = snake;
        }

        public void Start()
        {
            while (true)
            {
                snake.DrawSnake();
                writer.Write("working");
            }
        }
    }
}
