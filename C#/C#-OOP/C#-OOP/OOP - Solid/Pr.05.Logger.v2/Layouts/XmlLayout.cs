using Pr._05.Logger.v2.Enums;
using Pr._05.Logger.v2.Interfaces;
using System.Text;

namespace Pr._05.Logger.v2.Layouts
{
    class XmlLayout : ILayout
    {
        public string FormatMessage(string time, ReportLevel reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>")
                .AppendLine($"   <data>{time}</data>")
                .AppendLine($"   <level>{reportLevel.ToString().ToUpper()}</level>")
                .AppendLine($"   <message>{message}</message>")
                .Append("</log>");

            return sb.ToString();
        }
    }
}
