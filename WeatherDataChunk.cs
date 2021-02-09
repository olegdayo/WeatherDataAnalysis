using System;


namespace Proga2Semester1Sem
{
    public enum WeatherType
    {
        Cold,
        Fog,
        Rain,
        Snow
    }
    
    
    public enum WeatherCondition
    {
        Light,
        Moderate,
        Heavy,
        Severe,
    }
    
    
    public struct WeatherDataChunk
    {
        public int eventId;
        public WeatherType type;
        public WeatherCondition condition;
        public DateTime startTime;
        public DateTime endTime;
        public string timeZone;
        public string airportCode;
        public double locationLatitude;
        public double locationLongitude;
        public string city;
        public string country;
        public string state;
        public int zipCode;
    }
}