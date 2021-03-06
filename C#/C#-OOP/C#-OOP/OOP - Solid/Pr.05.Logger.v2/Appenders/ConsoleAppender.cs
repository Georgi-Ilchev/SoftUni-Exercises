using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Interfaces;
using System;

namespace Pr._05.Logger.v2.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {

        }

        public override void Append(string time, ReportLevel reportLevel, string message)
        {
            this.Count++;
            string formatMessage = this.Layout.FormatMessage(time, reportLevel, message);
            Console.WriteLine(formatMessage);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
