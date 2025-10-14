using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Newtonsoft.Json.Linq;

namespace Ex5
{
        internal class WeatherService
        {
            private readonly string _apiKey;
            private readonly HttpClient _client;

            public WeatherService()
            {
                Env.Load();
                _apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY") ?? throw new Exception("API key missing");
                _client = new HttpClient();
            }

            public async Task<double> GetCurrentTemperatureAsync(string city)
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
                string response = await _client.GetStringAsync(url);

                var json = JObject.Parse(response);
                return (double)json["main"]["temp"];
            }
        }
    }
