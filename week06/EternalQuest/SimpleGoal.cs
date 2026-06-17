using System;

public class SimpleGoal : Goal
{
    private bool _statusComplete;

    public SimpleGoal(string goalTitle, string goalInfo, int goalPoints) : base(goalTitle, goalInfo, goalPoints)
    {
        _statusComplete = false;
    }

    public SimpleGoal(string goalTitle, string goalInfo, int goalPoints, bool finished) : base(goalTitle, goalInfo, goalPoints)
    {
        _statusComplete = finished;
    }

    public override int RecordEvent()
    {
        _statusComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _statusComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_statusComplete}";
    }
}