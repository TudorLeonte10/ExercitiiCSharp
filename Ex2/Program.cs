using Ex2;
using Ex2.Models;
using System;
using System.Collections;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Grade Evaluator");
        Console.Write("Enter student name: ");
        var student = new Student { Name = Console.ReadLine() ?? "Unknown" };

        bool addMoreSubjects = true;
        while (addMoreSubjects)
        {
            Console.Write("\nEnter subject name: ");
            var subject = new Subject { Name = Console.ReadLine() ?? "Unknown" };

            Console.Write("Enter grades separated by space (0–100): ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(" No grades entered.");
                continue;
            }

            subject.Grades = input.Split(' ')
                .Select(g => double.TryParse(g, out var n) && n >= 0 && n <= 100 ? n : 0)
                .ToList();

            student.Subjects.Add(subject);

            Console.Write("Add another subject? (y/n): ");
            addMoreSubjects = (Console.ReadLine()?.Trim().ToLower() == "y");
        }

        // Afișăm strategiile disponibile
        Console.WriteLine("\nAvailable grading strategies:");
        foreach (var s in GradingFactory.GetStrategies())
            Console.WriteLine($"- {s.Name}");

        Console.Write("\nChoose strategy: ");
        var chosen = Console.ReadLine();
        var strategy = GradingFactory.GetByName(chosen ?? "") ?? GradingFactory.GetStrategies().First();

        Console.WriteLine($"\n Using strategy: {strategy.Name}\n");

        double total = 0;
        int subjectCount = 0;

        foreach (var subj in student.Subjects)
        {
            double avg = strategy.CalculateAverage(subj.Grades);
            Console.WriteLine($"{subj.Name,-15} → {avg:F2}");
            total += avg;
            subjectCount++;
        }

        double generalAvg = subjectCount > 0 ? total / subjectCount : 0;
        Console.WriteLine($"\n General Average: {generalAvg:F2}");
    }
}

