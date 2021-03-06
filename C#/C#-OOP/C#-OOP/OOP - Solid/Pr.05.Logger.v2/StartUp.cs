using Pr._05.Logger.v2.Appenders;
using Pr._05.Logger.v2.Core;
using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Layouts;
using System;

namespace Pr._05.Logger.v2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);
            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54", "No connection string found in App.config");

            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;
            //var logger = new Logger(consoleAppender);
            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            Engine engine = new Engine();
            engine.Run();
        }
    }
}
