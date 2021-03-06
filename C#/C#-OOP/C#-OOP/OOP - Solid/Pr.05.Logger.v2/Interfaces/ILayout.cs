using Pr._05.Logger.v2.Enums;

namespace Pr._05.Logger.v2.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string time, ReportLevel reportLevel, string message);
    }
}
