using System;

namespace OOP___Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                CheckForNegative(number);
                int sum = number * number;
                Console.WriteLine(sum);
            }
            catch (NegativeNumberNotAllowed e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Your input cannot be null");
            }
            catch (FormatException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
        static void CheckForNegative(int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberNotAllowed("Invalid number");
            }
        }
        class NegativeNumberNotAllowed : Exception
        {
            public NegativeNumberNotAllowed(string message) : base(message)
            {

            }
        }
    }
}
