using System;// підключення основного простору імен
using System.Collections.Generic;//для використання списків
using System.Linq;//для роботи з даними

namespace Lab4
{
    public class MeteorologicalObservations
    {
        //змінні
        private string date;
        private double temperature;
        private double atmosphericPressure;

        //Перевірка правильності формату дати
        public string Date
        {
            get => date;//зчитування змінної
            set//присвоєння змінної value
            {
                TestIsDate(value);
                date = value;
            }
        }
        //Перевірка правильності формату температури
        public double Temperature
        {
            get => temperature;
            set => temperature = value;
        }
        //Перевірка правильності формату атмосферного тиску
        public double AtmosphericPressure
        {
            get => atmosphericPressure;
            set => atmosphericPressure = value;
        }

        //Змінні за замовчуванням
        public MeteorologicalObservations()
        {
            Date = "01.01.0001";
            Temperature = 0;
            AtmosphericPressure = 0;
        }

        public MeteorologicalObservations(string s)
        {
            // Створення масива "х" в якому зберігаються дані студента та розбиття ел. на окремі елементи і видалення пробілів
            string[] x = s.Split(';').Select(tag => tag.Trim()).ToArray();

            //Перевірка правильності формату вхідних даних
            if (x.Length != 3)
            {
                throw new Exception("Дані в базі мають бути в такому форматі: \n" +
                "         дата, температура, атмосферний тиск \n");
            }

            //Повідомлення про помилку
            TestIsNumber(x[1], "Невірно введено температуру, використано заборонені символи");
            TestIsNumber(x[2], "Невірно введено атмосферний тиск, використано заборонені символи");

            //Зчитування даних
            Date = x[0];
            Temperature = double.Parse(x[1]);
            AtmosphericPressure = double.Parse(x[2]);
        }

        public override string ToString() // в якому форматі виводити дані на екран
        {
            const int size = -12;
            return string.Format($"{"|"}{Date,size} {"|"}{Temperature + "°",size} {"|"}{AtmosphericPressure + "мм",size}|\n" +
                                 "==========================================");
        }

        // метод порівняння дати
        public static int CompareDate(MeteorologicalObservations a, MeteorologicalObservations b)
        {
            return a.Date.CompareTo(b.Date);
        }

        //метод порівняння атмосферного тиску
        public static int CompareAtmosphericPressure(MeteorologicalObservations a, MeteorologicalObservations b)
        {
            return a.AtmosphericPressure.CompareTo(b.AtmosphericPressure);
        }

        //Метод для виведення масиву
        public static void ViewArray(MeteorologicalObservations[] metObs)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("|    Дата     | Температура |    Тиск    |");
            Console.WriteLine("==========================================");
            foreach (MeteorologicalObservations item in metObs)
            {
                Console.WriteLine(item);
            }
        }

        //Метлд для обчислення середнього значення атмосферного тиску
        public static double CalculateAveragePressure(MeteorologicalObservations[] metObs)
        {
            // Обчислює середнє значення атмосферного тиску за допомогою LINQ
            return metObs.Select(d => d.atmosphericPressure).Average();
        }

        //Відфільтрування днів
        public static MeteorologicalObservations[] FilterPressureAboveAverage(MeteorologicalObservations[] metObs, double averagePressure)
        {
            // Відфільтрує дні, де атмосферний тиск перевищує середнє значення
            return metObs.Where(d => d.atmosphericPressure > averagePressure).ToArray();
        }

        //Метод для перевірки формату дати
        private void TestIsDate(string s)
        {
            if (!DateTime.TryParseExact(s, "dd.mm.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                Console.WriteLine("Причина помилки: " + s);
                throw new Exception("Невірний формат дати\n" +
                                    "Дата має бути у форматі: \"dd.mm.yyyy\"");
            }
        }

        //Перевіряється чи  рядок числом
        private static void TestIsNumber(string str, string ErrorMessage)
        {
            // Перевірка чи str є числом
            if (!double.TryParse(str, out _))
            {
                Console.WriteLine("Причина помилки: \"{0}\"", str);
                throw new Exception(ErrorMessage);
            }
        }
    }
}
