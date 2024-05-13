using System;
//Emanuel Carias, Learning Activity - C# Prep 3
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string playAgain;

        do
        {
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;

            Console.WriteLine("Guess the magic number between 1 and 100!");

            while (true)
            {
                Console.WriteLine("What is your guess?");
                int guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                    break;
                }
            }

            Console.WriteLine("Do you want to play again? (yes/no)");
            playAgain = Console.ReadLine();
        }
        while (playAgain.ToLower() == "yes");
    }
}
