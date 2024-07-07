using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        List<string> reflectingPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        List<string> reflectingQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        while (true)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            if (choice == "4") break;

            Console.Write("Enter the duration in seconds: ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Please enter a valid positive number for duration: ");
            }

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity(duration);
                    breathing.Run();
                    break;
                case "2":
                    ListingActivity listing = new ListingActivity(duration, listingPrompts);
                    listing.Run();
                    break;
                case "3":
                    ReflectingActivity reflecting = new ReflectingActivity(duration, reflectingPrompts, reflectingQuestions);
                    reflecting.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

// Creativity and Exceeding Core Requirements:
// 1. The program ensures that the user inputs a valid positive number for duration, to help provide feedback and re-prompting if necessary.
// 2. Lists of prompts and questions for activities are stored in lists, this will make it easy to modify or extend the program with new content.
// 3. A menu system is implemented to guide the user through selecting different activities, so as to make the user experience more interactive and user-friendly.
// 4. The structure of the program is designed to be easily extendable, so  as to allow the addition of new types of activities in the future without major changes to existing code.
// 5. The program includes a spinner and countdown animation to enhance the user experience, so as to make the pauses more engaging and visually appealing.