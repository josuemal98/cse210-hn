using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        int rounds = _duration / 10;
        if (rounds < 1) 
        {
            rounds = 1;
        }

        for (int i = 0; i < rounds; i++)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            
            Console.Write("\nBreathe out... ");
            ShowCountDown(6);
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}