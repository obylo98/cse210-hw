using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            goalManager.Start();
        }
    }
}


// Creativity and Exceeding Core Requirements:
// 1. Added more informative prompts and better display of information.
// 2. I ensured that the program handles invalid inputs gracefully, such as non-integer inputs for goal values or invalid menu selections.
// 3. I made sure the program allowed users to search for and filter goals based on various criteria.
// 4. The program keeps a history of events recorded for each goal.
// 5. Award users with achievements or badges based on their progress.