using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            DisplayMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournalToFile(journal);
                    break;
                case "4":
                    LoadJournalFromFile(journal);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // This will Display the main menu to the user
    static void DisplayMenu()
    {
        Console.WriteLine("Journal Menu");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display all entries");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.Write("Choose an option: ");
    }

    // this section Writes a new entry in the journal
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Entry entry = new Entry(DateTime.Now.ToShortDateString(), prompt, response);
        journal.AddEntry(entry);
    }

    //this is the part responsible for Saving the journal to a file
    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string saveFile = Console.ReadLine();
        journal.SaveToFile(saveFile);
    }

    // this part Loads the journal from a file
    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string loadFile = Console.ReadLine();
        journal.LoadFromFile(loadFile);
    }
}
