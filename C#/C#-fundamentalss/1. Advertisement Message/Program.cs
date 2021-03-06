using System;

namespace _1._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            AdvertisementMessage ad = new AdvertisementMessage();
            Console.WriteLine(ad.GenerateMessage());


        }
        public class AdvertisementMessage
        {
            public static string[] Phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            public static string[] Events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            public static string[] Authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            public static string[] Cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };


            public string GenerateMessage()
            {
                Random rand = new Random();
                string currentPhrase = Phrases[rand.Next(0, Phrases.Length)];
                string currentEvent = Events[rand.Next(0, Events.Length)];
                string currentAuthor = Authors[rand.Next(0, Authors.Length)];
                string currentCitie = Cities[rand.Next(0, Cities.Length)];

                return $"{currentPhrase} {currentEvent} {currentAuthor} - {currentCitie}";
            }
        }

    }
}
