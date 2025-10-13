using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Program
{
    static async Task Main(string[] args)
    {
        var data = await GetCurrentTemp("Bucharest");
        Console.WriteLine(data);
        

    }

    static async Task<string> GetCurrentTemp(string city)
    {
        string apiKey = "cf00264d98a4af3193cb6edf8b270975";
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

        var client = new HttpClient();
        string response = await client.GetStringAsync(url);

        var json = JObject.Parse(response);
        return json.ToString();
    }
}