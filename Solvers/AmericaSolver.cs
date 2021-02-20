using System;
using System.Collections.Generic;
using System.Linq;


namespace Proga2Semester1Sem
{
    public class AmericaSolver : SolverBase
    {
        public AmericaSolver(WeatherDataChunk[] data) : base(data)
        {
        }
        
        
        public override void Run()
        {
            var matches = 
                Data.Where(d => /* d.country == "USA" && */ d.startTime.Year == 2018);
            Console.WriteLine($"Count of weather situations in USA 2018: {matches.ToArray().Length}");
        }
        
        
        public override void Sel()
        {
            IEnumerable<WeatherDataChunk> matches =
                from d in Data
                where d.startTime.Year == 2018
                select d;
            Console.WriteLine($"Count of weather situations in USA 2018: {matches.Count()}");
        }
    }
}
