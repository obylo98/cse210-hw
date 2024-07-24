public class CyclingActivity : BaseActivity
{
    private double _speedInKmh;

    public CyclingActivity(DateTime date, int lengthInMinutes, double speedInKmh)
        : base(date, lengthInMinutes)
    {
        _speedInKmh = speedInKmh;
    }

    public override double GetDistance() => _speedInKmh * (LengthInMinutes / 60.0);

    public override double GetSpeed() => _speedInKmh;

    public override double GetPace() => 60.0 / _speedInKmh;
}
