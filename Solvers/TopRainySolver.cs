using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Proga2Semester1Sem
{
    public class TopRainyChunk
    {
        public int Count { get; set; }
        public string Name { get; set; }
    }
    
    
    public class TopRainySolver : SolverBase
    {
        public TopRainySolver(WeatherDataChunk[] data) : base(data)
        {
        }
        
        
        public override void Run()
        {
            Data
                .Where(d => d.startTime.Year == 2019 && d.type == WeatherType.Rain)
                .GroupBy(d => d.city)
                .Select(x => new TopRainyChunk {Count = x.Count(), Name = x.Key})
                .OrderByDescending(x => x.Count)
                .ToArray()
                .LogTopRainy();
        }
        
        
        public override void Sel()
        {
            var towns =
                from d in Data
                where d.startTime.Year == 2019 && d.type == WeatherType.Rain
                group d by d.city;
            var groupedTowns =
                from d in towns
                select new TopRainyChunk{Count = d.Count(), Name = d.Key};
            var sortedTowns =
                from d in groupedTowns
                orderby d.Count descending
                select d;
            sortedTowns.ToArray().LogTopRainy();
        }
    }
}
