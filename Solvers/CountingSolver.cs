using System;
using System.Collections.Generic;
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


        public override void Sel()
        {
            IEnumerable<string> numberOfCities =
                from d in Data
                select d.city;
            IEnumerable<string> cities = numberOfCities.Distinct();
            IEnumerable<string> numberOfStates =
                from d in Data
                select d.state;
            IEnumerable<string> states = numberOfStates.Distinct();
            Console.WriteLine($"Count of cities: {cities.Count()}, count of states: {states.Count()}");
        }
    }
}
