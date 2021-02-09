using System;
using System.Linq;


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
    }
}