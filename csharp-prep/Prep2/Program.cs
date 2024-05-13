using System;
//Emanuel Carias, Learning Activity - C# Prep 2
class Program
{
    static void Main(string[] args)
    {
        // Solicitar al usuario su porcentaje de calificación
        Console.WriteLine("Enter your grade percentage:");
        int gradePercentage = int.Parse(Console.ReadLine());

        // Variable para almacenar la calificación de letra
        string letter = "";

        // Determinar la calificación de letra
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determinar el signo de la calificación de letra
        string sign = "";
        int lastDigit = gradePercentage % 10;
        if (lastDigit >= 7 && gradePercentage != 100)
        {
            sign = "+";
        }
        else if (lastDigit < 3 && gradePercentage != 0)
        {
            sign = "-";
        }

        // Manejar casos especiales de A+ y F+
        if (letter == "A" && sign == "+" && gradePercentage != 100)
        {
            letter += "-";
            sign = "";
        }
        else if (letter == "F" && sign == "+")
        {
            letter = "F";
            sign = "";
        }

        // Mostrar la calificación de letra y el signo
        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        // Determinar si el usuario pasó el curso y mostrar un mensaje apropiado
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
