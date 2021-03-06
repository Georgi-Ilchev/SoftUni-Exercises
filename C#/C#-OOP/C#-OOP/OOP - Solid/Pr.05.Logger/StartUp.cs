using Pr._05.Logger.Appenders;
using Pr._05.Logger.Layouts;
using System;

namespace Pr._05.Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout, file);
            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
