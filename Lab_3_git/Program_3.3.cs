using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Lab3_3
{
    class Program
    {
        private const string FILE_NAME = "input.txt"; // назва вхідного файла
        private const string FILE_NAME_OUTPUT = "output.txt"; // назва вихідного файла

        static void Main(string[] args)
        {
            // Змінюємо кодіровку на вхід і вихід на - Unicode
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.WriteLine("Консольний застосунок, реалізує вказані дії:");
            Console.WriteLine("текстовий рядок імпортується з деякого наперед створеного файла {0}\nа результати роботи програми потрібно записати у новостворений під час виконання проекту файл {1}", FILE_NAME, FILE_NAME_OUTPUT);
            Console.WriteLine("виводить на екран частоту входження кожної літери та записує результат у файл 'output.txt'.\n");

            try
            {
                string text = InputFile(); // Зчитуємо текст з файла
                Dictionary<char, int> letterFrequency = GetLetterFrequency(text); //частота входження кожної літери
                PrintLetterFrequency(letterFrequency); // Виводимо на екран частоту входження кожної літери
                OutputFile(letterFrequency); // Записуємо частоту входження кожної літери у файл
            }
            catch (Exception ex)
            {
                Console.WriteLine("УВАГА: {0}", ex.Message); // Виводимо повідомлення про помилку
            }

            Console.WriteLine(); // Пауза
        }

        private static string InputFile() // Зчитує текст з файла
        {
            if (!File.Exists(FILE_NAME)) // Перевіряємо, чи існує файл
            {
                throw new Exception("Файл " + FILE_NAME + " не існує");
            }

            string text; // Рядок для збереження вмісту

            using (StreamReader sr = File.OpenText(FILE_NAME)) // Відкриваємо файл для читання
            {
                text = sr.ReadToEnd(); // Зчитуємо весь текст з файла
            }

            if (string.IsNullOrEmpty(text)) // Перевірка чи файл порожній
            {
                throw new Exception("Файл " + FILE_NAME + " порожній");
            }

            return text; // Повертаємо текст з файла
        }

        private static Dictionary<char, int> GetLetterFrequency(string text) // Отримує частоту входження кожної літери
        {
            Dictionary<char, int> letterFrequency = new Dictionary<char, int>(); // Створюємо словник для збереження частоти входження кожної літери

            foreach (char letter in text) // Проходимося по кожному символу у тексті
            {
                if (char.IsLetter(letter)) // Перевіряємо, чи символ є літерою
                {
                    char lowercaseLetter = char.ToLower(letter); // Перетворюємо символ на нижній регістр
                    if (letterFrequency.ContainsKey(lowercaseLetter)) // Перевіряємо, чи літера вже присутня в словнику
                    {
                        letterFrequency[lowercaseLetter]++; // Якщо так, то збільшуємо лічильник
                    }
                    else
                    {
                        letterFrequency.Add(lowercaseLetter, 1); // Якщо ні, додаємо літеру у словник з лічильником 1
                    }
                }
            }

            return letterFrequency; // Повертаємо словник з частотою входження кожної літери
        }

        private static void PrintLetterFrequency(Dictionary<char, int> letterFrequency) // Виводить частоту входження кожної літери на екран
        {
            foreach (KeyValuePair<char, int> pair in letterFrequency) // Проходимося по кожній парі ключ-значення у словнику
            {
                Console.WriteLine("Літера '{0}': {1} раз(ів)", pair.Key, pair.Value); // Виводимо літеру та її частоту входження
            }
        }

        private static void OutputFile(Dictionary<char, int> letterFrequency) // Записує частоту входження кожної літери у файл
        {
            using (StreamWriter sw = new StreamWriter(FILE_NAME_OUTPUT)) // Відкриваємо файл для запису
            {
                foreach (KeyValuePair<char, int> pair in letterFrequency) // Проходимося по кожній парі ключ-значення у словнику
                {
                    sw.WriteLine("Літера '{0}': {1} раз(ів)", pair.Key, pair.Value); // Записуємо літеру та її частоту входження у файл
                }
            }
        }
    }
}
