namespace Proga2Semester1Sem
{
    public abstract class SolverBase
    {
        public WeatherDataChunk[] Data { get; }
        
        
        public SolverBase(WeatherDataChunk[] data)
        {
            Data = data;
        }
        
        
        public abstract void Run();
    }
}