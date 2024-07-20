using System;
using System.Collections.Generic;

abstract class Activity
{
    protected string _date;
    protected int _lengthInMinutes;

    public Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{_date} Activity ({_lengthInMinutes} min)";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(string date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / _lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / _distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {_distance} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * _lengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():0.0} miles, Speed: {_speed:0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0 * 0.62; 
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min/mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("2024-07-20", 30, 3.0),
            new Cycling("2024-07-21", 45, 15.0),
            new Swimming("2024-07-22", 60, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}