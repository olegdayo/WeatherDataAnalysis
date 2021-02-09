using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace Proga2Semester1Sem
{
    public class Parser
    {
        public List<WeatherDataChunk> data;
        public int numOfRows;
        public int numOfCols;
        private int analyzeRows = 50;
        private const int LinesLimit = -1;
        
        
        public void ReadingFile(string filepath)
        {
            StreamReader sr = new StreamReader(filepath);
            numOfCols  = sr.ReadLine().Split(',').Length;
            data = new List<WeatherDataChunk>();
            string[] line;
            int nullcounter = 0;
            int currentLine = 0;
            while(!sr.EndOfStream)
            {
                currentLine++;
                WeatherDataChunk weather = new WeatherDataChunk();
                line = sr.ReadLine().Split(',');
                weather.eventId = int.Parse(line[0].Split('-')[1]);
                weather.type = line[1] switch
                {
                    "Cold" => WeatherType.Cold,
                    "Fog" => WeatherType.Fog,
                    "Rain" => WeatherType.Rain,
                    "Snow" => WeatherType.Snow,
                    _ => weather.type
                };
                weather.condition = line[2] switch
                {
                    "Light" => WeatherCondition.Light,
                    "Moderate" => WeatherCondition.Moderate,
                    "Heavy" => WeatherCondition.Heavy,
                    "Severe" => WeatherCondition.Severe,
                    _ => weather.condition
                        
                };
                string[] date = line[3].Split(' ')[0].Split('-');
                string[] time = line[3].Split(' ')[1].Split(':');
                weather.startTime = new DateTime(year: int.Parse(date[0]), month: int.Parse(date[1]), day: int.Parse(date[2]), hour: int.Parse(time[0]), minute: int.Parse(time[1]), second: int.Parse(time[2]));
                date = line[4].Split(' ')[0].Split('-');
                time = line[4].Split(' ')[1].Split(':');
                weather.endTime = new DateTime(year: int.Parse(date[0]), month: int.Parse(date[1]), day: int.Parse(date[2]), hour: int.Parse(time[0]), minute: int.Parse(time[1]), second: int.Parse(time[2]));
                weather.timeZone = line[5];
                weather.airportCode = line[6];
                weather.locationLatitude = Convert.ToDouble(line[7]);
                weather.locationLongitude = Convert.ToDouble(line[8]);
                weather.city = line[9];
                weather.country = line[10];
                weather.state = line[11];
                int a;
                bool b = int.TryParse(line[12], out a);
                a = b ? a : 0;
                weather.zipCode = a;
                data.Add(weather);
            }
            numOfRows = data.Count;
            sr.Close();
        }
    }
}