namespace _01._CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Read(string args);
    }
}
