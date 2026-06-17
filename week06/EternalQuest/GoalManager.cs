using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Total Score: {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save data: ");
        string fileDest = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileDest))
        {
            writer.WriteLine(_score);
            foreach (Goal item in _goals)
            {
                writer.WriteLine(item.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load data: ");
        string sourceFile = Console.ReadLine();

        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Target file does not exist.");
            return;
        }

        _goals.Clear();
        string[] dataLines = File.ReadAllLines(sourceFile);
        
        _score = int.Parse(dataLines[0]);

        for (int idx = 1; idx < dataLines.Length; idx++)
        {
            string currentLine = dataLines[idx];
            if (string.IsNullOrWhiteSpace(currentLine)) continue;

            string[] sections = currentLine.Split('|');
            string goalType = sections[0];

            if (goalType == "SimpleGoal")
            {
                string title = sections[1];
                string info = sections[2];
                int points = int.Parse(sections[3]);
                bool finished = bool.Parse(sections[4]);
                _goals.Add(new SimpleGoal(title, info, points, finished));
            }
            else if (goalType == "EternalGoal")
            {
                string title = sections[1];
                string info = sections[2];
                int points = int.Parse(sections[3]);
                _goals.Add(new EternalGoal(title, info, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string title = sections[1];
                string info = sections[2];
                int points = int.Parse(sections[3]);
                int doneTimes = int.Parse(sections[4]);
                int totalTimes = int.Parse(sections[5]);
                int extraPoints = int.Parse(sections[6]);
                _goals.Add(new ChecklistGoal(title, info, points, doneTimes, totalTimes, extraPoints));
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Goal Types Available:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Select a type of goal: ");
        string selection = Console.ReadLine();

        Console.Write("Enter goal title: ");
        string title = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string info = Console.ReadLine();
        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        if (selection == "1")
        {
            _goals.Add(new SimpleGoal(title, info, points));
        }
        else if (selection == "2")
        {
            _goals.Add(new EternalGoal(title, info, points));
        }
        else if (selection == "3")
        {
            Console.Write("How many target repetitions? ");
            int totalTimes = int.Parse(Console.ReadLine());
            Console.Write("What is the final bonus reward? ");
            int extraPoints = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(title, info, points, totalTimes, extraPoints));
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("[Empty List]");
            return;
        }
        
        foreach (Goal entry in _goals)
        {
            Console.WriteLine(entry.GetDetailsString());
        }
    }

    public void ListGoalNames()
    {
        for (int counter = 0; counter < _goals.Count; counter++)
        {
            Console.WriteLine($"{counter + 1}. {_goals[counter].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Current Goals:");
        for (int counter = 0; counter < _goals.Count; counter++)
        {
            string marker = _goals[counter].IsComplete() ? "X" : " ";
            Console.WriteLine($"{counter + 1}. [{marker}] {_goals[counter].GetDetailsString()}");
        }

        Console.Write("Which goal did you complete? ");
        int selectionIndex = int.Parse(Console.ReadLine()) - 1;

        if (selectionIndex >= 0 && selectionIndex < _goals.Count)
        {
            if (_goals[selectionIndex].IsComplete() && _goals[selectionIndex] is SimpleGoal)
            {
                Console.WriteLine("Action invalid. Goal already finished.");
                return;
            }

            int standardPoints = _goals[selectionIndex].RecordEvent();
            _score += standardPoints;
            Console.WriteLine($"Success! You received {standardPoints} points!");
            Console.WriteLine($"Current Total: {_score} points.");
        }
    }

    public void Start()
    {
        bool showMenu = true;
        while (showMenu)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("=== MAIN MENU ===");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Enter selection number: ");
            
            string menuInput = Console.ReadLine();

            if (menuInput == "1")
            {
                CreateGoal();
            }
            else if (menuInput == "2")
            {
                ListGoalDetails();
            }
            else if (menuInput == "3")
            {
                SaveGoals();
            }
            else if (menuInput == "4")
            {
                LoadGoals();
            }
            else if (menuInput == "5")
            {
                RecordEvent();
            }
            else if (menuInput == "6")
            {
                showMenu = false;
            }
        }
    }
}