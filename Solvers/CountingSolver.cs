using System;
using System.Linq;


namespace Proga2Semester1Sem
{
    public class CountingSolver : SolverBase
    {
        public CountingSolver(WeatherDataChunk[] data) : base(data)
        {
        }
        
        
        public override void Run()
        {
            var cities = Data.Select(d => d.city).Distinct().ToArray();
            var states = Data.Select(d => d.state).Distinct().ToArray();
            Console.WriteLine($"Count of cities: {cities.Length}, count of states: {states.Length}");
        }
    }
}