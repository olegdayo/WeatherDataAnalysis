using System;
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
    }
}