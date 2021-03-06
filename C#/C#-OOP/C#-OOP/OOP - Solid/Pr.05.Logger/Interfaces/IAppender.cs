using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._05.Logger.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string time, string reportLevel, string message);
    }
}
