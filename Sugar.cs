using System;
using System.Collections.Generic;
using System.Linq;


namespace Proga2Semester1Sem
{
    public static class Sugar
    {
        public static void LogAmerica(this IEnumerable<WeatherDataChunk> target)
        {
            Console.WriteLine($"Count of weather situations in USA 2018: {target.Count()}");
        }
        
        
        public static void LogCounting(this IEnumerable<string> cities, IEnumerable<string> states)
        {
            Console.WriteLine($"Count of cities: {cities.Count()}, count of states: {states.Count()}");
        }
        
        
        public static void LogTopRainy(this TopRainyChunk[] data)
        {
            Console.WriteLine("Top rainy cities:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1}. City: {data[i].Name}, rains: {data[i].Count}");
            }
        }
        
        
        public static void LogTopSnowfallsSolver(this IEnumerable<WeatherDataChunk> output)
        {
            foreach (var i in output)
            {
                Console.WriteLine($"For the year: {i.startTime.Year} most snowy is {i.city} with duration (in days): {(int)i.endTime.Subtract(i.startTime).TotalDays}, beggining at : {i.startTime} and ending at: {i.endTime}");
            }
        }
    }
}
