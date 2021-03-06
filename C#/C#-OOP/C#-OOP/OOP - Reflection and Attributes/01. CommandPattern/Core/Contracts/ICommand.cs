namespace _01._CommandPattern.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
