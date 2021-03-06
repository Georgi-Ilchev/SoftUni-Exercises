using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger.Interfaces
{
    public interface ILogger
    {
        void Warning(string time, string message);
        void Error(string time, string message);
        void Info(string time, string message);
    }
}
