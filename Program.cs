using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


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
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            new CountingSolver(data).Run();
            new CountingSolver(data).Sel();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            new TopRainySolver(data).Run();
            new TopRainySolver(data).Sel();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            new TopSnowfallsSolver(data).Run();
            new TopSnowfallsSolver(data).Sel();
        }
    }
}
