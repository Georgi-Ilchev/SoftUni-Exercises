using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Interfaces;

namespace Pr._05.Logger.v2.Appenders
{
    public abstract class Appender : IAppender

    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }
        protected int Count { get; set; }

        public abstract void Append(string time, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.Count}";
        }
    }
}
