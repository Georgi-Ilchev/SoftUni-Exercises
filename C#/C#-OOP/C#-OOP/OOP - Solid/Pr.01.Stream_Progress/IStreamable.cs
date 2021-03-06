using System;
using System.Collections.Generic;
using System.Text;

namespace Pr._01.Stream_Progress
{
    public interface IStreamable
    {
        public int BytesSent { get; set; }
        public int Length { get; set; }
    }
}
