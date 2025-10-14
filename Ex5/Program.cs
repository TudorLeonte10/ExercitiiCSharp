using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Introdu orasul unde vrei sa vezi temperatura:");
        string city = Console.ReadLine();
        string data = await GetCurrentTemp(city);
        double.TryParse(data, out double temp);

        Console.WriteLine($"Introdu temperatura medie (celsius) in orasul introdus la aceasta data:");
        double avgTemp = double.Parse(Console.ReadLine());
        
        if(temp > avgTemp && (temp - avgTemp<=10) )
            Console.WriteLine("E mai cald");
        else if(temp > avgTemp)
            Console.WriteLine("Foarte cald");
        else if(temp < avgTemp && (avgTemp - temp <= 10))
            Console.WriteLine("E mai rece");
        else if(temp < avgTemp)
            Console.WriteLine("Foarte rece");
        else
            Console.WriteLine("Temperatura este egala cu media.");

        Console.WriteLine($"Temperatura actuala este {data}");
        

    }

    static async Task<string> GetCurrentTemp(string city)
    {
        string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        var client = new HttpClient();
        string response = await client.GetStringAsync(url);

        var json = JObject.Parse(response);
        var temperature = json["main"]["temp"];
        return $"{temperature}";
    }
}