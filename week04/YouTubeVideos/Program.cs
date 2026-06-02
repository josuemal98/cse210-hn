using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videoList = new List<Video>();

            Video video1 = new Video("Learn C# in 15 Minutes", "Code Academy", 900);
            video1.AddComment(new Comment("John_Doe", "Great video! It helped me a lot."));
            video1.AddComment(new Comment("Alice_Dev", "Now I understand classes and objects."));
            video1.AddComment(new Comment("Bob99", "Can you make a part 2 soon?"));
            videoList.Add(video1);

            Video video2 = new Video("Software Design Basics", "Tech Talk", 1200);
            video2.AddComment(new Comment("Sam_Smith", "Abstraction is very important."));
            video2.AddComment(new Comment("Emma_W", "Nice explanation of the diagram."));
            video2.AddComment(new Comment("Chris_P", "A bit long, but it is good."));
            videoList.Add(video2);

            Video video3 = new Video("How to Build an Indie Game", "Game Studio", 1850);
            video3.AddComment(new Comment("Gamer101", "This makes me want to build my own game."));
            video3.AddComment(new Comment("ArtFan", "The music in this video is nice."));
            video3.AddComment(new Comment("Luke_K", "What game engine did you use?"));
            videoList.Add(video3);

            Console.WriteLine("--- YOUTUBE VIDEOS REPORT ---\n");
            foreach (Video video in videoList)
            {
                video.DisplayVideoDetails();
            }
        }
    }
}