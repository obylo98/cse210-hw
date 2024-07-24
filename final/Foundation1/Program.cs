using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learning C#", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot!"));

        Video video2 = new Video("Understanding OOP", "Jane Smith", 450);
        video2.AddComment(new Comment("Dave", "Excellent explanation!"));
        video2.AddComment(new Comment("Eve", "Well done!"));
        video2.AddComment(new Comment("Frank", "Could you make a follow-up video?"));

        Video video3 = new Video("Mastering Design Patterns", "Jim Brown", 600);
        video3.AddComment(new Comment("Grace", "This is gold!"));
        video3.AddComment(new Comment("Heidi", "Thank you for this!"));
        video3.AddComment(new Comment("Ivan", "Best tutorial ever!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}
