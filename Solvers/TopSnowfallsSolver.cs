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
            Data
                .Where(d => d.type == WeatherType.Snow)
                .GroupBy(d => d.startTime.Year)
                .TopSnowfallsSolverCycle();
        }
        
        
        public override void Sel()
        {
            var townsByYears =
                from d in Data
                where d.type == WeatherType.Snow
                group d by d.startTime.Year;
            townsByYears.TopSnowfallsSolverCycle();
        }
    }
}
