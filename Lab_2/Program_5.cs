using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть розмірність матриці (nxm):");
        int n = ReadPositiveInteger("n"); // Зчитування кількості рядків матриці
        int m = ReadPositiveInteger("m"); // Зчитування кількості стовпців матриці

        int[,] matrix = new int[n, m]; // Створення матриці розмірності nxm

        // Введення значень елементів матриці
        Console.WriteLine("Введіть елементи матриці:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = ReadInteger($"Елемент [{i + 1},{j + 1}]: ");
            }
        }

        // Введення номерів стовпців, які треба поміняти
        Console.Write("Введіть номер першого стовпця (k): ");
        int k = ReadColumnNumber(m); // Зчитування номера першого стовпця
        Console.Write("Введіть номер другого стовпця (p): ");
        int p = ReadColumnNumber(m); // Зчитування номера другого стовпця

        // Виведення початкової матриці
        Console.WriteLine("Початкова матриця:");
        PrintMatrix(matrix);

        // Поміняти місцями вказані стовпці
        SwapColumns(matrix, k - 1, p - 1);

        // Виведення результату
        Console.WriteLine($"Результат: стовпці {k} та {p} були поміняні місцями.");
        PrintMatrix(matrix);
    }

    // Метод для зчитування додатнього цілого числа з консолі
    static int ReadPositiveInteger(string prompt)
    {
        int value;
        Console.Write($"Введіть значення {prompt}: ");
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine($"Введене значення для {prompt} не є додатнім цілим числом. Будь ласка, введіть додатнє ціле число.");
            Console.Write($"Введіть значення {prompt}: ");
        }
        return value;
    }

    // Метод для зчитування цілого числа з консолі
    static int ReadInteger(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Введіть ціле число.");
            Console.Write(prompt);
        }
        return value;
    }

    // Метод для зчитування номера стовпця
    static int ReadColumnNumber(int maxColumn)
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value < 1 || value > maxColumn)
        {
            Console.WriteLine($"Введіть ціле число в діапазоні від 1 до {maxColumn}.");
            Console.Write("Введіть номер стовпця: ");
        }
        return value;
    }

    // Метод для обміну місцями двох стовпців в матриці
    static void SwapColumns(int[,] matrix, int column1, int column2)
    {
        int rows = matrix.GetLength(0);
        for (int i = 0; i < rows; i++)
        {
            int temp = matrix[i, column1];
            matrix[i, column1] = matrix[i, column2];
            matrix[i, column2] = temp;
        }
    }

    // Метод для виведення матриці на екран
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
