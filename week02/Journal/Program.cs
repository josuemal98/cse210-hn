using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();

        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random randomGenerator = new Random();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                int randomIndex = randomGenerator.Next(prompts.Count);
                string randomPrompt = prompts[randomIndex];

                Console.WriteLine($"\nPrompt: {randomPrompt}");
                Console.Write("> ");
                string userResponse = Console.ReadLine();

                // EXCEEDING REQUIREMENTS. Added a feature to track the user's current mood.
                // This saves more information in the journal entry to help recognize emotional patterns.  
                Console.Write("How is your mood right now? (e.g., Happy, Tired, Excited): ");
                string userMood = Console.ReadLine();
                
                string finalPromptText = $"{randomPrompt} [Mood: {userMood}]";

                string currentDate = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry();
                newEntry._date = currentDate;
                newEntry._promptText = finalPromptText;
                newEntry._entryText = userResponse;

                myJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nGoodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}