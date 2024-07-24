public abstract class BaseActivity
{
    private DateTime _date;
    private int _lengthInMinutes;

    protected BaseActivity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public DateTime Date => _date;
    public int LengthInMinutes => _lengthInMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{GetType().Name} on {Date.ToShortDateString()}\n" +
               $"Duration: {LengthInMinutes} min\n" +
               $"Distance: {GetDistance():F2} km\n" +
               $"Speed: {GetSpeed():F2} km/h\n" +
               $"Pace: {GetPace():F2} min/km";
    }
}
