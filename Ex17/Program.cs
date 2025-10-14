using Ex17;
using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Numele filmului: ");
        string title = Console.ReadLine() ?? "Film necunoscut";

        Console.Write("Tip ecranizare (2D / 3D / 4D): ");
        string typeInput = Console.ReadLine()?.Trim().ToLower() ?? "2d";
        ScreenType type = typeInput switch
        {
            "3d" => ScreenType.ThreeD,
            "4d" or "4dx" => ScreenType.FourD,
            _ => ScreenType.TwoD
        };

        double basePrice = 20;

        var movie = new Movie(title, type, basePrice);
        var sales = new CinemaSales();

        Console.WriteLine("\nIntrodu biletele pe care vrei sa le cumperi (scrie 'stop' când ai terminat)\n");

        while (true)
        {
            Console.Write("Zona (fata / mijloc / spate / stop): ");
            string zone = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (zone == "stop")
                break;

            Console.Write("Cate bilete doresti pentru aceasta zona? ");
            int count = int.TryParse(Console.ReadLine(), out var n) ? n : 1;

            for (int i = 0; i < count; i++)
            {
                var ticket = new Ticket(movie, zone);
                sales.AddTicket(ticket);
            }

            Console.WriteLine($"Adaugate {count} bilete la zona {zone}.");
        }

        sales.ShowReport();

    }
}
