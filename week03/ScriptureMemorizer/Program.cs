using System;

class Program
{
    static void Main(string[] args)
    {
       Reference reference = new Reference("John", 3, 16);
       string text = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
       
       Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}