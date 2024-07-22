using System;
using System.Collections.Generic;

class Program
{
    static void Main()
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
