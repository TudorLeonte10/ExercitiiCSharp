using DotNetEnv;
using Ex5;
using Ex5.Strategies;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Introdu orasul unde vrei sa vezi temperatura:");
        string city = Console.ReadLine() ?? "";

        var service = new WeatherService();
        double currentTemp = await service.GetCurrentTemperatureAsync(city);

        Console.WriteLine("Introdu temperatura medie (Celsius):");
        double averageTemp = double.Parse(Console.ReadLine() ?? "0");

        var context = new TemperatureContext();
        string message = context.Evaluate(currentTemp, averageTemp);

        Console.WriteLine($"\nIn {city}:");
        Console.WriteLine($" - Temperatura actuala: {currentTemp}°C");
        Console.WriteLine($" - Temperatura medie: {averageTemp}°C");
        Console.WriteLine($" - Concluzie: {message}");
    }
}