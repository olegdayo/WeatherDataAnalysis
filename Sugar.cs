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
        
        
        public static void LogTopSnowfallsSolver(this IGrouping<int, WeatherDataChunk> group, TopSnowfallsChunk top)
        {
            Console.WriteLine($"For the year: {group.Key} most snowy is {top.City} with duration (in days): {(int)top.To.Subtract(top.From).TotalDays}, beggining at : {top.From} and ending at: {top.To}");
        }
        
        
        public static void TopSnowfallsSolverCycle(this IEnumerable<IGrouping<int, WeatherDataChunk>> townsByYears)
        {
            foreach (IGrouping<int, WeatherDataChunk> group in townsByYears)
            {
                var topSnowyTowns = group
                    .Select(g => new TopSnowfallsChunk {Year = group.Key, City = g.city, From = g.startTime, To = g.endTime})
                    .OrderByDescending(g => g.To.Subtract(g.From))
                    .ToArray();
                
                group.LogTopSnowfallsSolver(topSnowyTowns[0]);
            }
        }
    }
}
