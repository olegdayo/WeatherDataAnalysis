using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Proga2Semester1Sem
{
    public class TopRainySolver : SolverBase
    {
        public TopRainySolver(WeatherDataChunk[] data) : base(data)
        {
        }
        
        
        public override void Run()
        {
            var towns = Data
                .Where(d => d.startTime.Year == 2019 && d.type == WeatherType.Rain)
                .GroupBy(d => d.city)
                .Select(x => new {Count = x.Count(), Name = x.Key})
                .OrderByDescending(x => x.Count)
                .ToArray();
            Console.WriteLine("Top rainy cities:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1}. City: {towns[i].Name}, rains: {towns[i].Count}");
            }
        }
        
        
        public override void Sel()
        {
            var towns =
                from d in Data
                where d.startTime.Year == 2019 && d.type == WeatherType.Rain
                group d by d.city;
            var groupedTowns =
                from d in towns
                select new {Count = d.Count(), Name = d.Key};
            var sortedTowns =
                from d in groupedTowns
                orderby d.Count descending
                select d;
            Console.WriteLine("Top rainy cities:");
            var t = sortedTowns.ToArray();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1}. City: {t[i].Name}, rains: {t[i].Count}");
            }
        }
    }
}
