// SHOWS CREATIVITY AND EXCEEDS REQUIREMENTS:
// I added a feature to keep track of the session statistics. 
// The program counts the total number of activities performed during the current session 
// and displays a summary log message before the user exits the application.

using System;

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        int totalActivities = 0;

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                totalActivities++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                totalActivities++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                totalActivities++;
            }
        }

        Console.Clear();
        Console.WriteLine("Thank you for practicing mindfulness today!");
        Console.WriteLine("Total activities performed in this session: " + totalActivities);
        Console.WriteLine("Goodbye.");
    }
}