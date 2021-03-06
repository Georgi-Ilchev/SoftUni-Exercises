namespace Pr._05.Logger.v2.Interfaces
{
    public interface ILogger
    {
        void Warning(string time, string message);
        void Error(string time, string message);
        void Info(string time, string message);
        void Critical(string name, string message);
        void Fatal(string name, string message);
    }
}
