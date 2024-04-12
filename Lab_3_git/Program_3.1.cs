using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
 

        Console.WriteLine("Введіть текстовий рядок:");
        string input = Console.ReadLine();

        // Перевірка на null перед викликом методу Split
        string[] sentences = input?.Split(new string[] { ". ", "! ", "? " }, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

        // Змінні для найбільшого речення та його довжини
        string longestSentence = "";
        int maxLength = 0;

        // Перебираємо кожне речення
        foreach (string sentence in sentences)
        {
            // Розділяємо речення на слова за допомогою пробілів
            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Виводимо кількість слів у кожному реченні
            Console.WriteLine($"Речення \"{sentence}\": {words.Length} сл?в");

            // Оновлюємо найдовше речення, якщо поточне речення довше
            if (words.Length > maxLength)
            {
                maxLength = words.Length;
                longestSentence = sentence;
            }
        }

        // Виводимо найдовше речення
        Console.WriteLine($"Найдовше речення: \"{longestSentence}\"");
    }
}
// А й правда, крилатим ґрунту не треба. Землі немає, то буде небо. Немає поля, то буде воля. Немає пари, то будуть хмари. В цьому, напевно, правда пташина...А як же людина? А що ж людина?
