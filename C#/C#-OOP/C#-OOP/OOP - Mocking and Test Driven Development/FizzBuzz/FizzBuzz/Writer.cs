using FizzBuzz.Contracts;

namespace FizzBuzz
{
    public class Writer : IWriter
    {
        public void WirteLine(string input)
        {
            Result += input;
        }
        public string Result { get; set; }
    }
}
