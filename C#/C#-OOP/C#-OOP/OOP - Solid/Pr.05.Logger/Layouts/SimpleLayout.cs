using Pr._05.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string time, string reportLevel, string message)
        {
            return $"{time} - {reportLevel} - {message}"; 
        }
    }
}
