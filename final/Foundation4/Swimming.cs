public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0 * 0.62; // converting meters to miles
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
