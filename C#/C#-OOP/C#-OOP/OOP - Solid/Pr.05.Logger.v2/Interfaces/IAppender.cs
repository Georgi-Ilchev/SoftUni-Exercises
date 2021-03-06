using Pr._05.Logger.v2.Enums;

namespace Pr._05.Logger.v2.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }

        abstract void Append(string time, ReportLevel reportLevel, string message);
    }
}
