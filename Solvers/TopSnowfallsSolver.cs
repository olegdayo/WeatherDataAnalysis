using System;
using System.Collections.Generic;
using System.Linq;


namespace Proga2Semester1Sem
{
    public class TopSnowfallsSolver : SolverBase
    {
        public TopSnowfallsSolver(WeatherDataChunk[] data) : base(data)
        {
        }
        
        
        public override void Run()
        {
            var townsByYears = Data
                .Where(d => d.type == WeatherType.Snow)
                .GroupBy(d => d.startTime.Year);
            foreach (var group in townsByYears)
            {
                var topSnowyTowns = group
                    .Select(g => new {Year = group.Key, City = g.city, From = g.startTime, To = g.endTime})
                    .OrderByDescending(g => g.To.Subtract(g.From))
                    .ToArray();
                var top = topSnowyTowns[0];
                Console.WriteLine($"For the year: {group.Key} most snowy is {top.City} with duration (in days): {(int)top.To.Subtract(top.From).TotalDays}, beggining at : {top.From} and ending at: {top.To}");
            }
        }
        
        
        public override void Sel()
        {
            var townsByYears =
                from d in Data
                where d.type == WeatherType.Snow
                group d by d.startTime.Year;
            foreach (var g in townsByYears)
            {
                var groupedTowns =
                    from d in g
                    select new {Year = g.Key, City = d.city, From = d.startTime, To = d.endTime};
                var sortedTowns =
                    from d in groupedTowns
                    orderby d.To.Subtract(d.From) descending
                    select d;
                var t = sortedTowns.ToArray();
                var top = t[0];
                Console.WriteLine($"For the year: {g.Key} most snowy is {top.City} with duration (in days): {(int)top.To.Subtract(top.From).TotalDays}, beggining at : {top.From} and ending at: {top.To}");
            }
        }
    }
}
