using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Introduceti un text cu diacritice:");
        string input = Console.ReadLine();
        Console.WriteLine($"Numarul de caractere: {NumberOfCharacters(input)}");
        Console.WriteLine($"Numarul de cuvinte: {NumberOfWords(input)}");
        Console.WriteLine($"Numarul de vocale: {NumberOfVowels(input)}");
        Console.WriteLine($"Numarul de consoane: {NumberOfConsonants(input)}");

    }

    static int NumberOfCharacters(string text)
    {
        int count = 0;
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                count++;
            }
        }
        return count;
    }

    static int NumberOfWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    static int NumberOfVowels(string text)
    {
        int count = 0;
        string vowels = "aeiouAEIOUăĂâÂîÎ";
        foreach (char c in text)
        {
            if (vowels.Contains(c))
            {
                count++;
            }
        }
        return count;
    }

    static int NumberOfConsonants(string text)
    {
        int count = 0;
        string consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
        foreach (char c in text)
        {
            if (consonants.Contains(c))
            {
                count++;
            }
        }
        return count;
    }
}