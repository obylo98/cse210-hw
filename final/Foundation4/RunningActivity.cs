public class RunningActivity : BaseActivity
{
    private double _distanceInKm;

    public RunningActivity(DateTime date, int lengthInMinutes, double distanceInKm)
        : base(date, lengthInMinutes)
    {
        _distanceInKm = distanceInKm;
    }

    public override double GetDistance() => _distanceInKm;

    public override double GetSpeed() => _distanceInKm / (LengthInMinutes / 60.0);

    public override double GetPace() => LengthInMinutes / _distanceInKm;
}
