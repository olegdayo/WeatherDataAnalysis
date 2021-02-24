using System;
using System.Collections.Generic;
using System.Linq;


namespace Proga2Semester1Sem
{
    public class TopSnowfallsChunk
    {
        public int Year { get; set; }
        public string City { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    
    
    public class TopSnowfallsSolver : SolverBase
    {
        public TopSnowfallsSolver(WeatherDataChunk[] data) : base(data) { }
        
        
        public override void Run()
        {
            Data.Where(d => d.type == WeatherType.Snow)
                .OrderByDescending(d => d.endTime.Subtract(d.startTime))
                .ToArray()
                .GroupBy(d => d.startTime.Year)
                .Select(d => d.First())
                .OrderBy(d => d.startTime.Year)
                .LogTopSnowfallsSolver();
        }
        
        
        public override void Sel()
        {
            var sortedSnow =
                from d in Data
                where d.type == WeatherType.Snow
                orderby d.endTime.Subtract(d.startTime) descending
                select d;
            var groupedSortedSnow =
                from d in sortedSnow
                group d by d.startTime.Year;
            var topGroupedSnow =
                from d in groupedSortedSnow
                select d.First();
            sortedSnow =
                from d in topGroupedSnow
                orderby d.startTime.Year
                select d;
            sortedSnow.LogTopSnowfallsSolver();
        }
    }
}
