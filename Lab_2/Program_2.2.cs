using System;

class Program
{
    static void Main(string[] args)
    {
        double pi = 3.14; // Значення числа Пі

        double a, b, dx, x;

        // Цикл введення початкового значення інтервалу з перевіркою коректності
        do
        {
            Console.WriteLine("Введіть початкове значення інтервалу a:");
        } while (!double.TryParse(Console.ReadLine(), out a) || a < 0 || a > pi);

        b = pi; // Кінцеве значення інтервалу
        dx = pi / 20; // Крок
        x = a; // Початкове значення аргументу x

        // Виведення заголовка та параметрів обчислення
        Console.WriteLine("Результати обчислення функції y = f(x) на проміжку [" + a + ", " + b.ToString("N2") + "] з кроком dx = " + dx.ToString("N2") + "\n");
        Console.WriteLine("x\t|\ty");
        Console.WriteLine("---------------------");

        // Цикл з передумовою для обчислення значень функції на вказаному інтервалі
        while (x <= b)
        {
            double y; // Змінна для збереження значення функції

            try
            {
                // Обчислення значення функції за формулою
                y = Math.Pow(Math.Sqrt(Math.Tan(x) + 13), 4);
                Console.WriteLine(x.ToString("N2") + "\t|\t" + y.ToString("N2")); // Виведення результатів
            }
            catch (Exception)
            {
                Console.WriteLine(x.ToString("N2") + "\t|\tНевизначене значення"); // Виведення у випадку помилки обчислення
            }

            x += dx;
        }

        Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
        Console.ReadKey(); // Зупинка консолі перед закриттям
    }
}
