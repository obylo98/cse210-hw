using System;

public abstract class Activity
{
    protected string _date;
    protected int _lengthInMinutes;

    public Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} Activity ({_lengthInMinutes} min)";
    }
}
