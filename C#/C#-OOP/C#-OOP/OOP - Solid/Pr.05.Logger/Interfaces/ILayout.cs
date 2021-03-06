using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string time, string reportLevel, string message);
    }
}
