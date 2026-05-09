using System;

class Program
{
    static void Main(string[] args)
    {
    
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            Random randomgenerator = new Random();
            int magicnumber = randomgenerator.Next(1, 101);

            int guess = 0;
         
            int attempts = 0;

            while (guess != magicnumber)
            {
                Console.WriteLine("Guess the magic number between 1 and 100:");
                
                
                guess = int.Parse(Console.ReadLine());

                
                attempts = attempts + 1;

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
                    
                    Console.WriteLine("It took you " + attempts + " guesses.");
                }
            }

    
            Console.WriteLine("Do you want to play again? (yes/no)");
            playAgain = Console.ReadLine();
        }
    }
}

