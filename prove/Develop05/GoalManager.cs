using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    class GoalManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public void Start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest");
                Console.WriteLine("1. Display Player Info");
                Console.WriteLine("2. List Goal Names");
                Console.WriteLine("3. List Goal Details");
                Console.WriteLine("4. Create Goal");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Save Goals");
                Console.WriteLine("7. Load Goals");
                Console.WriteLine("8. Search Goals");
                Console.WriteLine("9. Filter Goals");
                Console.WriteLine("10. Display Achievements");
                Console.WriteLine("11. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayPlayerInfo();
                        break;
                    case "2":
                        ListGoalNames();
                        break;
                    case "3":
                        ListGoalDetails();
                        break;
                    case "4":
                        CreateGoal();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        SaveGoals();
                        break;
                    case "7":
                        LoadGoals();
                        break;
                    case "8":
                        SearchGoals();
                        break;
                    case "9":
                        FilterGoals();
                        break;
                    case "10":
                        DisplayAchievements();
                        break;
                    case "11":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void DisplayPlayerInfo()
        {
            Console.WriteLine($"Player Score: {_score}");
            Console.WriteLine($"Total Goals: {_goals.Count}");
            Console.WriteLine($"Completed Goals: {_goals.Count(g => g.IsComplete())}");
        }

        private void ListGoalNames()
        {
            Console.WriteLine("Goals:");
            foreach (var goal in _goals)
            {
                Console.WriteLine($"- {goal.GetDetailsString()}");
            }
        }

        private void ListGoalDetails()
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("Create a Goal:");
            Console.Write("Enter Goal Type (Simple, Eternal, Checklist): ");
            string type = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Points: ");
            int points = int.Parse(Console.ReadLine());

            if (type.Equals("Simple", StringComparison.OrdinalIgnoreCase))
            {
                _goals.Add(new SimpleGoal(name, description, points));
            }
            else if (type.Equals("Eternal", StringComparison.OrdinalIgnoreCase))
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type.Equals("Checklist", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter Target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            }
            else
            {
                Console.WriteLine("Invalid Goal Type.");
            }
        }

        private void RecordEvent()
        {
            Console.WriteLine("Record Event:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }

            Console.Write("Select a goal to record: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _goals.Count)
            {
                _goals[index - 1].RecordEvent();
                _score += _goals[index - 1].Points;
            }
            else
            {
                Console.WriteLine("Invalid Goal.");
            }
        }

        public void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }

        public void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                string[] lines = File.ReadAllLines("goals.txt");
                _score = int.Parse(lines[0]);
                _goals.Clear();
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(",");
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    if (type == "Simple")
                    {
                        bool isComplete = bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(name, description, points, isComplete));
                    }
                    else if (type == "Eternal")
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type == "Checklist")
                    {
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                    }
                }
                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }

        private void SearchGoals()
        {
            Console.Write("Enter search term: ");
            string searchTerm = Console.ReadLine();
            var results = _goals.Where(g => g.GetDetailsString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            Console.WriteLine("Search Results:");
            if (results.Count > 0)
            {
                foreach (var goal in results)
                {
                    Console.WriteLine(goal.GetDetailsString());
                }
            }
            else
            {
                Console.WriteLine("No matching goals found.");
            }
        }

        private void FilterGoals()
        {
            Console.WriteLine("Filter Goals:");
            Console.WriteLine("1. Completed Goals");
            Console.WriteLine("2. Incomplete Goals");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            List<Goal> filteredGoals = new List<Goal>();
            if (choice == "1")
            {
                filteredGoals = _goals.Where(g => g.IsComplete()).ToList();
            }
            else if (choice == "2")
            {
                filteredGoals = _goals.Where(g => !g.IsComplete()).ToList();
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("Filtered Goals:");
            foreach (var goal in filteredGoals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        private void DisplayAchievements()
        {
            Console.WriteLine("Achievements:");
            Console.WriteLine("Earned 100 points: Beginner");
            Console.WriteLine("Completed 10 goals: Goal Achiever");
    
        }
    }
}
