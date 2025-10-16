using Ex10.Services;
using System;

public class Program
{
    static void Main(string[] args)
    {
        var ui = new ConsoleUserInterface();
        var analyzer = new BasicTextAnalyzer();

        string text = ui.GetInput("Please enter the text to analyze:");
        int wordCount = analyzer.CountWords(text);
        int charCount = analyzer.CountCharacters(text);
        int vowelCount = analyzer.NumberOfVowels(text);
        int consonantCount = analyzer.NumberOfConsonants(text);

        ui.ShowMessage($"Word Count: {wordCount}");
        ui.ShowMessage($"Character Count: {charCount}");
        ui.ShowMessage($"Vowel Count: {vowelCount}");
        ui.ShowMessage($"Consonant Count: {consonantCount}");
    }
}