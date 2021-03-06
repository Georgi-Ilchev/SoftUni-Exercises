using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;
            GameEngine engine = new GameEngine();
            engine.Start();
        }
    }
}
