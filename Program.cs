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
            StreamWriter sw = new StreamWriter("test.txt");
            sw.WriteLine("test");
            sw.Close();
            string filepath = "data.csv";
            parser.ReadingFile(filepath);
            Console.WriteLine("OK");
            Console.WriteLine(parser.numOfRows);
            Console.WriteLine(parser.numOfCols);
            var data = parser.data.ToArray();
            new AmericaSolver(data).Run();
            new CountingSolver(data).Run();
            new TopRainySolver(data).Run();
            new TopSnowfallsSolver(data).Run();
        }
    }
}