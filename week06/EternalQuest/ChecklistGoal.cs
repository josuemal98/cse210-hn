using System;

public class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetLimit;
    private int _bonusReward;

    public ChecklistGoal(string goalTitle, string goalInfo, int goalPoints, int totalTimes, int extraPoints) : base(goalTitle, goalInfo, goalPoints)
    {
        _currentCount = 0;
        _targetLimit = totalTimes;
        _bonusReward = extraPoints;
    }

    public ChecklistGoal(string goalTitle, string goalInfo, int goalPoints, int doneTimes, int totalTimes, int extraPoints) : base(goalTitle, goalInfo, goalPoints)
    {
        _currentCount = doneTimes;
        _targetLimit = totalTimes;
        _bonusReward = extraPoints;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount >= _targetLimit)
        {
            return _points + _bonusReward;
        }
        return _points;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetLimit;
    }

    public override string GetDetailsString()
    {
        string marker = IsComplete() ? "X" : " ";
        return $"[{marker}] {_shortName} ({_description}) -- Currently completed: {_currentCount}/{_targetLimit}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_currentCount}|{_targetLimit}|{_bonusReward}";
    }
}