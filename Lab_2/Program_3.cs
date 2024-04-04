using System;

class Program
{
    static void Main(string[] args)
    {
        // Запит на введення розміру масиву
        Console.WriteLine("Введіть розмір масиву:");
        int n;

        // Перевірка коректності введення розміру масиву
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Введіть коректне ціле додатне число для розміру масиву:");
        }

        // Генеруємо масив випадкових чисел заданого розміру
        int[] array = GenerateRandomArray(n);
        Console.WriteLine("Згенерований масив:");

        // Виводимо згенерований масив на консоль
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();

        // Обчислюємо кількість нулів у масиві
        int countZeros = CountZeros(array);
        // Обчислюємо добуток елементів після максимального за модулем елемента
        int productAfterMaxAbs = ProductAfterMaxAbs(array);

        // Виводимо результати обчислень на консоль
        Console.WriteLine($"Кількість нульових елементів: {countZeros}");
        Console.WriteLine($"Добуток елементів після максимального за модулем елемента: {productAfterMaxAbs}");
    }

    // Метод для генерації масиву випадкових чисел
    static int[] GenerateRandomArray(int n)
    {
        Random rnd = new Random();
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = rnd.Next(-100, 101); // Генеруємо випадкове число в діапазоні [-100, 100]
        }
        return array;
    }

    // Метод для підрахунку кількості нулів у масиві
    static int CountZeros(int[] array)
    {
        int count = 0;
        foreach (int element in array)
        {
            if (element == 0)
            {
                count++;
            }
        }
        return count;
    }

    // Метод для обчислення добутку елементів після максимального за модулем елемента
    static int ProductAfterMaxAbs(int[] array)
    {
        int maxAbsIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) > Math.Abs(array[maxAbsIndex]))
            {
                maxAbsIndex = i;
            }
        }

        int product = 1;
        for (int i = maxAbsIndex + 1; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }
}
