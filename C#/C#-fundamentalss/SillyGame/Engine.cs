using OOP___Workshop.Attributes;
using SillyGame.IO;
using SillyGame.IO.Contracts;

namespace SillyGame
{
    public class Engine
    {
        private IWriter writer;
        private IReader reader;

        [Inject]
        public Engine(IReader reader, [Named(typeof(WeirConsoleWriter))]IWriter writer)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Start()
        {
            while (true)
            {
                writer.Write("working");
            }
        }
    }
}
