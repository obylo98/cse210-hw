using System;
using System.Collections.Generic;

class Video
{
    private string _title;
    private string _author;
    private int _length; // in seconds
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");

        Console.WriteLine("Comments:");
        foreach (var comment in _comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine();
    }
}

class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"{_name}: {_text}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Very informative."));
        video1.AddComment(new Comment("User3", "Thanks for sharing."));

        Video video2 = new Video("Video 2", "Author 2", 600);
        video2.AddComment(new Comment("User4", "Nice content."));
        video2.AddComment(new Comment("User5", "Helpful tips!"));
        video2.AddComment(new Comment("User6", "Awesome!"));

        Video video3 = new Video("Video 3", "Author 3", 450);
        video3.AddComment(new Comment("User7", "Well done!"));
        video3.AddComment(new Comment("User8", "Very useful."));
        video3.AddComment(new Comment("User9", "Loved it!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}