using System;

// Клас, який виконує конвертацію номера місяця в його назву
public class MonthConverter
{
    // Метод, який конвертує номер місяця в його назву
    public static string ConvertToMonthName(int monthNumber)
    {
        string monthName; // Змінна для збереження назви місяця

        // Використовуємо оператор switch для вибору назви місяця
        switch (monthNumber)
        {
            case 1:
                monthName = "січень"; // Якщо номер місяця 1, то назва "січень"
                break;
            case 2:
                monthName = "лютий"; 
                break;
            case 3:
                monthName = "березень";
                break;
            case 4:
                monthName = "квітень";
                break;
            case 5:
                monthName = "травень"; 
                break;
            case 6:
                monthName = "червень"; 
                break;
            case 7:
                monthName = "липень";
                break;
            case 8:
                monthName = "серпень"; 
                break;
            case 9:
                monthName = "вересень";
                break;
            case 10:
                monthName = "жовтень"; 
                break;
            case 11:
                monthName = "листопад";
                break;
            case 12:
                monthName = "грудень"; 
                break;
            default:
                monthName = "Невірний номер місяця!"; // Якщо номер місяця не відповідає жодному місяцю, повідомляємо про помилку
                break;
        }

        return monthName; // Повертаємо назву місяця
    }
}

// Головний клас програми
public class Program
{
    // Метод, що викликається при запуску програми
    public static void Main(string[] args)
    {
        while (true) // Безкінечний цикл для продовження введення
        {
            Console.Write("Введіть номер місяця (1-12): "); // Виводимо запит на введення номера місяця
            int monthNumber;
            if (int.TryParse(Console.ReadLine(), out monthNumber)) // Перевіряємо, чи введено коректне число
            {
                string monthName = MonthConverter.ConvertToMonthName(monthNumber); // Викликаємо метод для конвертації номера місяця в назву
                Console.WriteLine($"Назва місяця: {monthName}"); // Виводимо назву місяця
                break; // Завершуємо цикл
            }
            else
            {
                Console.WriteLine("Невірний ввід. Будь ласка, введіть число від 1 до 12."); // Повідомлення про некоректне введення
            }
        }
    }
}

