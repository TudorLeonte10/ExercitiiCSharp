using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Introduceți un an (ex: 2028): ");
        int an;
        while (!int.TryParse(Console.ReadLine(), out an) || an < 1)
        {
            Console.Write("Valoare invalidă. Introduceți un an valid (>0): ");
        }

        bool esteBisect = DateTime.IsLeapYear(an);
        int zileAn = esteBisect ? 366 : 365;
        int saptamani = zileAn / 7;

        Console.WriteLine($"\nAnul {an} {(esteBisect ? "este" : "nu este")} bisect.");
        Console.WriteLine($"Are {zileAn} zile ({saptamani} săptămâni complete).");

        var sarbatori = GetSarbatori(an);

        Console.WriteLine("\nSărbători legale:");
        foreach (var s in sarbatori)
            Console.WriteLine($"- {s:dd MMMM yyyy} ({s.DayOfWeek})");

        int zileLucratoare = CalcZileLucratoare(an, sarbatori);

        Console.WriteLine($"\nZile lucrătoare în anul {an}: {zileLucratoare}");
    }

    static List<DateTime> GetSarbatori(int an)
    {
        var sarb = new List<DateTime>()
        {
            new DateTime(an, 1, 1),   // Anul Nou
                new DateTime(an, 1, 2),   // A doua zi de An Nou
                new DateTime(an, 1, 24),  // Ziua Unirii
                new DateTime(an, 5, 1),   // Ziua Muncii
                new DateTime(an, 6, 1),   // Ziua Copilului
                new DateTime(an, 8, 15),  // Adormirea Maicii Domnului
                new DateTime(an, 11, 30), // Sf. Andrei
                new DateTime(an, 12, 1),  // Ziua Națională
                new DateTime(an, 12, 25), // Crăciunul
                new DateTime(an, 12, 26), // A doua zi de Crăciun
        };
        return sarb;
    }

    static int CalcZileLucratoare(int an, List<DateTime> sarbatori)
    {
        DateTime start = new DateTime(an, 1, 1);
        DateTime end = new DateTime(an, 12, 31);
        int days = 0;

        for (var day = start; day <= end; day = day.AddDays(1))
        {
            if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                continue;

            if (sarbatori.Any(s => s.Date == day.Date))
                continue;

            days++;
        }
        return days;
    }
}
