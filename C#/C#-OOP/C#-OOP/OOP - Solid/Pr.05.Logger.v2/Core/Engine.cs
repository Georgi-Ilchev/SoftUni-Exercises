using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Factories;
using Pr._05.Logger.v2.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Pr._05.Logger.v2.Core
{
    public class Engine
    {
        private List<IAppender> appenders;
        private readonly LayoutFactory layoutFactory;
        private readonly AppenderFactory appenderFactory;

        public Engine()
        {
            this.appenders = new List<IAppender>();
            this.layoutFactory = new LayoutFactory();
            this.appenderFactory = new AppenderFactory();
        }

        public void Run()
        {
            this.ParseInput();
            this.PrintLogger();
        }
        private void PrintLogger()
        {
            Logger logger = new Logger(this.appenders.ToArray());

            string input = Console.ReadLine();
            while (input != "END")
            {
                //string[] splitted = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitted = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

                string methodName = this.GetTitleCase(splitted[0]);
                string date = splitted[1];
                string message = splitted[2];

                MethodInfo currentMethod = typeof(Logger).GetMethod(methodName);
                currentMethod.Invoke(logger, new object[] { date, message });

                input = Console.ReadLine();
            }
            Console.WriteLine(logger);
        }

        private void ParseInput()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string appenderType = input[0];
                string layoutType = input[1];
                ILayout layout = this.layoutFactory.CreateLayout(layoutType);
                IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);

                if (input.Length > 2)
                {
                    string reportLevel = this.GetTitleCase(input[2]);
                    appender.ReportLevel = Enum.Parse<ReportLevel>(reportLevel);
                }
                this.appenders.Add(appender);
            }
        }

        private string GetTitleCase(string text)
        {
            string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return titleCase;
        }
    }
}
