using System;

public class Program
{
    public static void Main(string[] args)
    {
        ScriptureLibrary scriptureLibrary = new ScriptureLibrary();

        //scriptures for demonstration
        Reference reference1 = new Reference("Proverbs", 3, 5, 6);
        string scriptureText1 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture1 = new Scripture(reference1, scriptureText1);
        scriptureLibrary.AddScripture(scripture1);

        Reference reference2 = new Reference("John", 3, 16);
        string scriptureText2 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture2 = new Scripture(reference2, scriptureText2);
        scriptureLibrary.AddScripture(scripture2);

        Reference reference3 = new Reference("Psalm", 23, 1, 2);
        string scriptureText3 = "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters.";
        Scripture scripture3 = new Scripture(reference3, scriptureText3);
        scriptureLibrary.AddScripture(scripture3);

    
        Scripture scripture = scriptureLibrary.GetRandomScripture();

        // Main loop to handle user interaction
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. The program will now end.");
                break;
            }

            Console.WriteLine("\nPress enter to hide a few words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3); 
        }
    }
}
