using System;


namespace Proga2Semester1Sem
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            string filepath = "data.csv";
            parser.ReadingFile(filepath);
            Console.WriteLine("OK");
            Console.WriteLine(parser.numOfRows);
            Console.WriteLine(parser.numOfCols);
            WeatherDataChunk[] data = parser.data.ToArray();


            new AmericaSolver(data).Run();
            new AmericaSolver(data).Sel();


            LogSeparator();


            new CountingSolver(data).Run();
            new CountingSolver(data).Sel();


            LogSeparator();


            new TopRainySolver(data).Run();
            new TopRainySolver(data).Sel();


            LogSeparator();


            new TopSnowfallsSolver(data).Run();
            new TopSnowfallsSolver(data).Sel();
        }


        private static void LogSeparator()
        {
            Console.WriteLine(new string('-', 220));
        }
    }
}
