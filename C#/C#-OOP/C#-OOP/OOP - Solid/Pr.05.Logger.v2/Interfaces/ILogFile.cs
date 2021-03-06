using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger.v2.Interfaces
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}
