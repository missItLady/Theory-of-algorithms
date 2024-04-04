using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть текст:");
        string inputText = Console.ReadLine();

        // Розділяємо текст на речення за допомогою регулярного виразу
        string[] sentences = Regex.Split(inputText, @"(?<=[\.!\?])\s+");

        // Виводимо кількість слів у кожному реченні
        Console.WriteLine("Кількість слів у кожному реченні:");
        foreach (string sentence in sentences)
        {
            int wordCount = CountWords(sentence);
            Console.WriteLine($"Речення: \"{sentence}\" - {wordCount} слів");
        }

        // Знаходимо найдовше речення і виводимо його
        string longestSentence = sentences.OrderByDescending(s => CountWords(s)).FirstOrDefault();
        Console.WriteLine($"Найдовше речення: \"{longestSentence}\"");
    }

    // Метод для підрахунку кількості слів у реченні
    static int CountWords(string sentence)
    {
        // Видаляємо некоректні символи
        sentence = Regex.Replace(sentence, @"[^\w\s]", "");
        // Розділяємо речення на слова та підраховуємо їх кількість
        string[] words = sentence.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}
