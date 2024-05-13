using System;
using System.Collections.Generic;
using System.Linq;
//Emanuel Carias, Learning Activity - C# Prep 4
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        List<int> positiveNumbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
            {
                break;
            }

            numbers.Add(input);

            if (input > 0)
            {
                positiveNumbers.Add(input);
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        // Calcular la suma
        int sum = numbers.Sum();

        // Calcular el promedio
        double average = numbers.Average();

        // Encontrar el número máximo
        int max = numbers.Max();

        // Encontrar el número positivo más pequeño
        int minPositive = positiveNumbers.Min();

        // Ordenar la lista
        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {minPositive}");
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
