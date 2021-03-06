using System;

namespace Pr._01.Stream_Progress
{
    class StartUp
    {
        static void Main(string[] args)
        {
            File file = new File("ABBA", 125, 10);
            Music music = new Music("Queen", "The Game", 1000, 220);

            StreamProgressInfo firstStreamProgress = new StreamProgressInfo(file);
            StreamProgressInfo secondStreamProgress = new StreamProgressInfo(music);

            Console.WriteLine(firstStreamProgress.CalculateCurrentPercent());
            Console.WriteLine(secondStreamProgress.CalculateCurrentPercent());
        }
    }
}
