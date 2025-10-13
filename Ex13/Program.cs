using System;
using System.Collections.Generic;
using System.Globalization;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Introduceti numele angajatului: ");
        string nume = Console.ReadLine();

        Console.Write("Data angajarii (ex: 2022-03-15): ");
        DateTime dataAngajare;
        DateTime.TryParse(Console.ReadLine(), out dataAngajare);

        Console.Write("Numarul de ore lucrate pe saptamana: ");
        int oreSapt;
        int.TryParse(Console.ReadLine(), out oreSapt);

        var tarife = new Dictionary<int, double>
        {
            {2022, 30},
            {2023, 35},
            {2024, 40},
            {2025, 45}
        };

        int anulCurent = DateTime.Now.Year;
        double tarifCurent = GetTarifCurent(tarife, anulCurent);
        double salariuBrut = CalculeazaSalariuBrut(oreSapt, tarifCurent);
        double salariuNet = CalculeazaSalariuNet(salariuBrut);
        double totalCastig = CalculeazaTotalVenituri(dataAngajare, oreSapt, tarife);

        Console.WriteLine($"Angajat: {nume}");
        Console.WriteLine($"Data angajarii: {dataAngajare:dd.MM.yyyy}");
        Console.WriteLine($"Tarif actual: {tarifCurent} lei/oră");
        Console.WriteLine($"Ore lucrate / saptamana: {oreSapt}");
        Console.WriteLine($"Salariu brut lunar: {salariuBrut} lei");
        Console.WriteLine($"Deduceri (45%): {salariuBrut * 0.45} lei");
        Console.WriteLine($"Salariu net lunar: {salariuNet} lei");
        Console.WriteLine($"Total primit până azi: {totalCastig} lei");

    }

    static double GetTarifCurent(Dictionary<int, double> tarife, int anulCurent)
    {
        double tarif = 0;
        foreach (var entry in tarife)
        {
            if (entry.Key <= anulCurent && entry.Value > tarif)
                tarif = entry.Value;
        }
        return tarif;
    }

    static double CalculeazaSalariuBrut(int oreSapt, double tarif)
    {
        double oreLunare = oreSapt * 4.33;
        return oreLunare * tarif;
    }

    static double CalculeazaSalariuNet(double brut)
    {
        return Math.Round(brut * (1 - 0.45), 2, MidpointRounding.ToEven);
    }

    static double CalculeazaTotalVenituri(DateTime dataAngajare, int oreSapt, Dictionary<int, double> tarife)
    {
        double total = 0;
        DateTime azi = DateTime.Today;

        for (DateTime luna = dataAngajare; luna <= azi; luna = luna.AddMonths(1))
        {
            int an = luna.Year;
            double tarif = 0;
            if (tarife.ContainsKey(an))
            {
                tarif = tarife[an];
            }
            else
            {
                tarif = GetTarifCurent(tarife,an);
            }
            double brut = CalculeazaSalariuBrut(oreSapt, tarif);
            double net = CalculeazaSalariuNet(brut);
            total += net;
        }

        return Math.Round(total, 2, MidpointRounding.ToEven);
    }
}
