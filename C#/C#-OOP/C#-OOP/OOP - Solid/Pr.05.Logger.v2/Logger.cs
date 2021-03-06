using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Interfaces;
using System;
using System.Text;

namespace Pr._05.Logger.v2
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Error(string time, string message)
        {
            this.Log(time, ReportLevel.Error, message);
        }

        public void Info(string time, string message)
        {
            this.Log(time, ReportLevel.Info, message);
        }

        public void Warning(string time, string message)
        {
            this.Log(time, ReportLevel.Warning, message);
        }
        public void Critical(string time, string message)
        {
            this.Log(time, ReportLevel.Critical, message);
        }
        public void Fatal(string time, string message)
        {
            this.Log(time, ReportLevel.Fatal, message);
        }

        private void Log(string time, ReportLevel reporLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                ReportLevel currentReportLevel = Enum.Parse<ReportLevel>(reporLevel.ToString());
                if (appender.ReportLevel <= currentReportLevel)
                {
                    appender.Append(time, reporLevel, message);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
