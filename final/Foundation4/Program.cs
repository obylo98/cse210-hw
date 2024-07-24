using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<BaseActivity> activities = new List<BaseActivity>
        {
            new RunningActivity(DateTime.Now.AddDays(-1), 30, 5.0),
            new CyclingActivity(DateTime.Now.AddDays(-2), 45, 20.0),
            new SwimmingActivity(DateTime.Now.AddDays(-3), 60, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
