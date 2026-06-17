using System;

public class EternalGoal : Goal
{
    public EternalGoal(string goalTitle, string goalInfo, int goalPoints) : base(goalTitle, goalInfo, goalPoints)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}";
    }
}