using Pr._05.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, LogFile file)
        {
            this.Layout = layout;
            this.File = file;
        }
        public ILayout Layout { get; }
        public LogFile File { get; set; }

        public void Append(string time, string reportLevel, string message)
        {
            string formatMessage = this.Layout.FormatMessage(time, reportLevel, message);
            this.File.Write(formatMessage);
        }
    }
}
