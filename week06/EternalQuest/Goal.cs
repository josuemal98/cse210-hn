using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string title, string info, int scoreValue)
    {
        _shortName = title;
        _description = info;
        _points = scoreValue;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string marker = IsComplete() ? "X" : " ";
        return $"[{marker}] {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}