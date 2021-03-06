using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Interfaces;

namespace Pr._05.Logger.v2.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string time, ReportLevel reportLevel, string message)
        {
            return $"{time} - {reportLevel.ToString().ToUpper()} - {message}"; 
        }
    }
}
