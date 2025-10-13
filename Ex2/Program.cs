using System;
using System.Collections;

public class Program
{

    static void Main (string[] args)
    {
        var dict = new Dictionary<string, List<int>>();
        Console.WriteLine("Introdu numarul de materii:");
        int nrObj;
        int.TryParse(Console.ReadLine(), out nrObj);

        while (nrObj > 0)
        {
            var gradesList = new List<int>();
            Console.WriteLine("Introdu numele unei materii:");
            string? obj = Console.ReadLine();

            Console.WriteLine("Introdu numarul de note la aceasta materie:");
            int nrGrades;
            int.TryParse(Console.ReadLine(), out nrGrades);
            nrObj--;
            while (nrGrades > 0)
            {
                Console.WriteLine("Introdu notele la aceasta materie");
                int grade;
                int.TryParse(Console.ReadLine(), out grade);
                gradesList.Add(grade);
                nrGrades--;
            }

            dict.Add(obj, gradesList);
        }

        var allMeans = new List<double>();
        foreach (var pair in dict)
        {
            string obj = pair.Key;
            List<int> grades = pair.Value;

            double mean = grades.Average();
            allMeans.Add(mean);
            Console.WriteLine($"Materia: {obj} -> Media: {mean}");
        }

        var totalMean = allMeans.Average();
        Console.WriteLine($"Media totala este: {totalMean}");
    }
}
