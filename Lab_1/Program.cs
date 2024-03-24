
using System;

class Program
{
    static void Main(string[] args)
    {
        // Оголошуємо змінні
        int A, B, C;

        // Отримуємо введені значення від користувача
        Console.WriteLine("Введіть значення для A:");
        A = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введіть значення для B:");
        B = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введіть значення для C:");
        C = Convert.ToInt32(Console.ReadLine());

        // Виведення на екран початкових значень
        Console.WriteLine($"Початкові значення: A = {A}, B = {B}, C = {C}");

        // Викликаємо метод SwapValues
        SwapValues(ref A, ref B, ref C);

        // Виведення на екран змінених значенмь
        Console.WriteLine($"Змінені значення: A = {A}, B = {B}, C = {C}");

        Console.ReadLine();
    }

    // Метод для обміну значень
    public static void SwapValues(ref int A, ref int B, ref int C)
    {
        // Змінюємо значення
        int temp = A;
        A = C;
        C = B;
        B = temp;
    }
}
