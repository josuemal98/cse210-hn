using System;

public class ListingActivity : Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(0, _prompts.Length)];

        Console.WriteLine("\nList as many items as you can as they relate to the following prompt:");
        Console.WriteLine("--- " + prompt + " ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        int itemCount = 0;
        int itemsToAsk = _duration / 4; 
        if (itemsToAsk < 2)
        {
            itemsToAsk = 2;
        }

        for (int i = 0; i < itemsToAsk; i++)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (item != "")
            {
                itemCount++;
            }
        }

        Console.WriteLine("\nYou listed " + itemCount + " items!");
        DisplayEndMessage();
    }
}