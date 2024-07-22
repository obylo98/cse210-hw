using System;
using System.Collections.Generic;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>
            {
                new Video
                {
                    Title = "Video 1",
                    Author = "Author 1",
                    Length = 120,
                    Comments = new List<Comment>
                    {
                        new Comment { CommenterName = "User1", Text = "Great video!" },
                        new Comment { CommenterName = "User2", Text = "Thanks for sharing." }
                    }
                },
                new Video
                {
                    Title = "Video 2",
                    Author = "Author 2",
                    Length = 240,
                    Comments = new List<Comment>
                    {
                        new Comment { CommenterName = "User3", Text = "Very informative." },
                        new Comment { CommenterName = "User4", Text = "Loved it!" }
                    }
                }
            };

            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.Length} seconds, Comments: {video.GetNumberOfComments()}");
                foreach (var comment in video.Comments)
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine();
            }
        }
    }
}
