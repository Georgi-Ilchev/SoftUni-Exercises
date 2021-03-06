using Pr._05.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger
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
            this.Log(time, "Error", message);
        }

        public void Info(string time, string message)
        {
            this.Log(time, "Info", message);
        }

        public void Warning(string time, string message)
        {
            this.Log(time, "Warning", message);
        }

        private void Log(string time, string reporLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(time, reporLevel, message);
            }
        }
    }
}
