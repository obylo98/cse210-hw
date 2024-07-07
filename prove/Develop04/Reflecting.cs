using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(int duration, List<string> prompts, List<string> questions)
        : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
    {
        _prompts = prompts;
        _questions = questions;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        ShowSpinner(3);
        while (_duration > 0)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            DisplayQuestions();
            _duration -= 10; // Assuming each question reflection takes 10 seconds
        }
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayQuestions()
    {
        ShowSpinner(10); // Pausing for 10 seconds to reflect on each question
    }
}
