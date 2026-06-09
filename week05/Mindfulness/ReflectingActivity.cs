using System;

public class ReflectingActivity : Activity
{
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?"
    };

    public ReflectingActivity() : base("Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(0, _prompts.Length)];
        
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine("--- " + prompt + " --- \n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        int questionsCount = _duration / 5;
        if (questionsCount < 1)
        {
            questionsCount = 1;
        }

        for (int i = 0; i < questionsCount; i++)
        {
            string question = _questions[random.Next(0, _questions.Length)];
            Console.Write("\n> " + question + " ");
            ShowSpinner(5);
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}