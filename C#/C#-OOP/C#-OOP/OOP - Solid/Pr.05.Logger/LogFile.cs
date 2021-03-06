using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pr._05.Logger
{
    public class LogFile
    {
        private const string FilePath = "log.txt";
        private StringBuilder stringBuilder;

        public LogFile()
        {
            this.stringBuilder = new StringBuilder();
        }

        public int Size { get; private set; }
        public void Write(string formatMessage)
        {
            this.stringBuilder.AppendLine(formatMessage);
            File.AppendAllText(FilePath, formatMessage + Environment.NewLine);
            this.Size = GetMessageSum(formatMessage);
        }

        private int GetMessageSum(string formatMessage)
        {
            int sum = formatMessage.Where(c => char.IsLetter(c)).Sum(c => c);
            return sum;
        }
    }
}
