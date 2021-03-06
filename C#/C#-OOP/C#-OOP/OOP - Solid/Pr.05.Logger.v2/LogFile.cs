using Pr._05.Logger.v2.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Pr._05.Logger.v2
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";
        private StringBuilder stringBuilder;

        public LogFile()
        {
            this.stringBuilder = new StringBuilder();
        }

        //public int Size { get; private set; }
        public int Size
            => File.ReadAllText(FilePath).Where(char.IsLetter).Sum(x => x);
        public void Write(string formatMessage)
        {
            this.stringBuilder.AppendLine(formatMessage);
            File.AppendAllText(FilePath, formatMessage + Environment.NewLine);
            //this.Size = this.GetMessageSum(formatMessage);
        }

        private int GetMessageSum(string formatMessage)
        {
            int sum = formatMessage.Where(c => char.IsLetter(c)).Sum(c => c);
            return sum;
        }
    }
}
