using System;

class Program
{
    
    static void Main(string[] args)
    {
            Random randomgenerator = new Random();
            int magicnumber = randomgenerator.Next(1, 100);

            int guess = 0;
            while (guess != magicnumber)
            {
                Console.WriteLine("Guess the magic number between 1 and 100:");
                guess = int.Parse(Console.ReadLine());

                if (guess < magicnumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > magicnumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed the magic number!");
                }
            }
     }
}


