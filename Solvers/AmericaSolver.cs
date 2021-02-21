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
            Data
                .Where(d => d.startTime.Year == 2018)
                .LogAmerica();
        }


        public override void Sel()
        {
            var matches =
                from d in Data
                where d.startTime.Year == 2018
                select d;
            matches.LogAmerica();
        }
    }
}
