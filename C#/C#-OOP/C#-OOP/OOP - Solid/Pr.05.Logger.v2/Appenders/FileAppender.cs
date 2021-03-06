using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Interfaces;

namespace Pr._05.Logger.v2.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout) : base(layout)
        {
            this.File = new LogFile();
        }

        public LogFile File { get; set; }

        public override void Append(string time, ReportLevel reportLevel, string message)
        {
            this.Count++;
            string formatMessage = this.Layout.FormatMessage(time, reportLevel, message);
            this.File.Write(formatMessage);
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
