public class SwimmingActivity : BaseActivity
{
    private int _laps;
    private const double LapDistanceKm = 0.05;

    public SwimmingActivity(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapDistanceKm;

    public override double GetSpeed() => GetDistance() / (LengthInMinutes / 60.0);

    public override double GetPace() => LengthInMinutes / GetDistance();
}
