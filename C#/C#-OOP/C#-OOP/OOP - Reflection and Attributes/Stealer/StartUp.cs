using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            //1
            string result1 = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            //2
            string result2 = spy.AnalyzeAcessModifiers("Stealer.Hacker");
            //3
            string result3 = spy.RevealPrivateMethods("Stealer.Hacker");
            //4
            string result4 = spy.CollectGettersAndSetters("Stealer.Hacker");

            Console.WriteLine(result4);
        }
    }
}
