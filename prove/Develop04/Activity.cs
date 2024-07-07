using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed the {_name} activity.");
        Console.WriteLine($"You spent {_duration} seconds on this activity.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }

    public abstract void Run();
}
