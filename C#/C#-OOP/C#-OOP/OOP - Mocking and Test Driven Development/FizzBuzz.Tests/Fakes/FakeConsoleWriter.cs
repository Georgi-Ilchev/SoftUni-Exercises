using FizzBuzz.Contracts;

namespace FizzBuzz.Tests.Fakes
{
    public class FakeConsoleWriter : IWriter
    {
        public void WirteLine(string input)
        {
            Result += input;
        }
        public string Result { get; set; }
    }
}
