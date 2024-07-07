using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
        : base("Breathing", "This activity will help you relax by guiding you through slow breathing exercises. Clear your mind and focus on your breathing.", duration)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        for (int i = 0; i < _duration; i += 4)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(2);
            Console.WriteLine("Breathe out...");
            ShowCountDown(2);
        }
        DisplayEndingMessage();
    }
}
