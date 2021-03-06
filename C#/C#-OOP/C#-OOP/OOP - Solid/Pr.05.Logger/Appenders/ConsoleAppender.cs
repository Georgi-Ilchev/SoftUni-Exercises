using Pr._05.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public void Append(string time, string reportLevel, string message)
        {
            string formatMessage = this.Layout.FormatMessage(time, reportLevel, message);
            Console.WriteLine(formatMessage);
        }
    }
}
