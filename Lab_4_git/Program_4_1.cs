using System;// Підключення основного простору імен
using System.IO;// Підключення основного простору імен для роботи з файлами

namespace Lab4
{
    class Program_4_1
    {
        private static string FILE_NAME;  // для збереження імені файла з яким потрібно працювати
        public static int CheckSizeArray() // провірка який розмір має мати масив
        {
            int size = 0; // змінна для збереження кількості рядків
            StreamReader f = new StreamReader(FILE_NAME);//об'єкт для зчитування файлу
            while ((_ = f.ReadLine()) != null) { ++size; }//зчитування кожного рядка
            f.Close();
            return size;
        }

        //Основний метод програми
        public static void Program(string FILE)
        {
            try//початок обробки можливих випадків
            {
                if (FILE == null) // перевірка чи файл не є пустим
                {
                    FILE_NAME = "Meteorological_Observations.txt";
                }
                else // інакше працювати з файлом який передали програмі
                {
                    if (FILE.Length > 150)
                    {
                        throw new Exception("Кількість символів в назві файла не може перевищювати 150 символів.\nВказана назва файла: " + FILE);
                    }
                    FILE_NAME = FILE;
                }

                // створення масива для роботи з базою даних, розміром - кількість записів (рядків) в базі
                MeteorologicalObservations[] metObs = new MeteorologicalObservations[CheckSizeArray()];

                string s; // для збереження рядка з файлу
                int i = 0; // індекс для масива
                using (StreamReader f = new StreamReader(FILE_NAME))
                {
                    while ((s = f.ReadLine()) != null) // запис рядка з бази в масив
                    {
                        metObs[i] = new MeteorologicalObservations(s);
                        ++i;
                    }
                    f.Close(); // закриття файла
                }

                //Виведення масиву на екран в консолі
                Console.WriteLine("\n       Метеорологічні спостереження.\n");
                MeteorologicalObservations.ViewArray(metObs); // вивід масива в консоль

                // Обчислення середнього значення тиску та виведення днів з тиском вищим за середнє значення
                var averagePressure = MeteorologicalObservations.CalculateAveragePressure(metObs);

                Console.WriteLine("\n  Дні з атмосферним тиском,\nбільшим від середнього начення (" + averagePressure + "):");
                MeteorologicalObservations.ViewArray //  виводить масив в консоль
                (   // повертає дні з атмосферним тиском, що перевищує середнє значення
                    MeteorologicalObservations.FilterPressureAboveAverage(metObs, averagePressure)
                );

                _ = Console.ReadKey(true); // пауза
            }
            catch (FileNotFoundException) //якщо файл відсутній
            {
                Console.WriteLine("Файл створено, наповніть його даними!");
                // Створення порожнього файлу
                File.Create(FILE_NAME).Close();//створення порожнього файлу
                _ = Console.ReadKey(true); return;
            }
            catch (Exception e) // виводить причину помилки в консоль
            {
                Console.WriteLine("Помилка: " + e.Message);
                _ = Console.ReadKey(true); return;
            }
        }
    }
}
