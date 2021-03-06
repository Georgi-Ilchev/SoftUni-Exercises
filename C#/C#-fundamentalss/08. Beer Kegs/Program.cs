using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            float maxVolume = float.MinValue;
            string biggestModel = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                float volume = (float) (Math.PI * radius * radius * height);

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    biggestModel = model;
                }
                
            }
            Console.WriteLine(biggestModel);
        }
    }
}
