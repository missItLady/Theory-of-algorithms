using System;
using System.Text;

namespace Lab4
{
    class Menu
    {
        public static void Main(string[] args)
        {
            // Кодування для вводу та виводу в консолі
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string FILE; // для збереження імя файла
            if (args.Length != 1) // якщо передали більше одного, або жодного файла, працює з стандартними іменами файлів
            {
                FILE = null;
            }
            else // інакше працює з іншим файлом
            {
                FILE = args[0];
            }

            char task; // для збереження натиснутої клавіші
            do
            {
                Console.WriteLine("Виберіть завдання для запуску:\n");

                Console.WriteLine("[1] Програма 1");
                Console.WriteLine("[2] Програма 2");

                Console.WriteLine("\n[ESC] Вихід\n");

                Console.Write(">");
                task = Console.ReadKey(true).KeyChar; // присвоєння натиснутої клавіші
                Console.Clear(); // очистка вмісту консолі
                switch (task)
                {
                    case (char)ConsoleKey.Escape: // якщо нажали ESC виходить з програми
                        break;

                    case '1':
                        Program_4_1.Program(FILE);
                        Console.Clear();
                        break;

                    case '2':
                        Program_4_2.Program(FILE);
                        Console.Clear();
                        break;

                        //повідомлення про помилку
                    default:
                        Console.Clear();
                        Console.WriteLine("\nПомилка: Такого пункта немає\n\n");
                        break;
                }
            } while (task != (char)ConsoleKey.Escape); // якщо нажали ESC виходить з програми
        }
    }
}
