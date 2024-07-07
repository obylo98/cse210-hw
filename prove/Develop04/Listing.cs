using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    public ListingActivity(int duration, List<string> prompts)
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
        _prompts = prompts;
        _count = 0;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(3);
        List<string> items = GetListFromUser();
        _count = items.Count;
        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                items.Add(item);
            }
        }
        return items;
    }
}
