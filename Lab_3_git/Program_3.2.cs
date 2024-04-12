using System;
using System.IO;
using System.Text; //для використання класу Encoding

namespace ExamResults
{
    class Program_2
    {
        static string fileName = "Result.txt";// оголошення статичної змінни

        static void Main(string[] args)
        {
            //Змінюємо кодіровку на вхід і вихід на - Unicode
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            AddResultToFile();
            _ = Console.ReadKey(true);
            ReadResultsFromFile();
            _ = Console.ReadKey(true);// функції для додавання результатів до файлу та читання результатів з файл
        }

        //методи для додавання результатів до файлу та читання результатів з файлу відповідно.
        static void AddResultToFile()
        {
            Console.WriteLine("Введіть прізвище студента:");
            string studentName = Console.ReadLine();
            Console.WriteLine("Введіть предмет:");
            string subject = Console.ReadLine();
            Console.WriteLine("Введіть оцінку студента:");
            string grade = Console.ReadLine();

            string record = $"{studentName},{subject},{grade}";// рядок, який містить дані про студента

            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine(record);
            } // конструкція для відкриття файлу

            Console.WriteLine("Результат іспиту успішно додано!");
        }

        
        static void ReadResultsFromFile()
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine($"Результати іспиту зчитані з файлу \"{fileName}\":");
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл з результатами іспиту порожній або не існує.");
            }
        }
    }
}
