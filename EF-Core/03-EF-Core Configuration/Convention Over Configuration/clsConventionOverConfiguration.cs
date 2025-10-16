using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_EF_Core_Configuration.Convention_Over_Configuration
{
    internal class clsConventionOverConfiguration
    {

        public class User
        {
            // Primary key convention [Id, id , ID] , [{Class}id], [{Class}Id], [{Class}ID]
            public int UserId { get; set; }
            public string Username { get; set; }
        }


        public class Tweet
        {
            public int TweetId { get; set; }
            public int UserId { get; set; }
            public string TweetText { get; set; }
            public DateTime CreatedAt { get; set; }
        }


        public class Comment
        {
            public int CommentId { get; set; }
            public int TweetId { get; set; }
            public int UserId { get; set; }
            public string CommentText { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class AppDbContext : DbContext
        {
            // 1 * DbSet Proberly Name match Table Name
            public DbSet<User> Users { get; set; } = null!;

            public DbSet<Tweet> Tweets { get; set; } = null!;

            public DbSet<Comment> Comments { get; set; } = null!;


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);

                var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = config.GetSection("constr").Value;

                optionsBuilder.UseSqlServer(connectionString);

            }


        }



        public static void ConventionOverConfiguration()
        {
            // Rules of convention : 

            // 1 * DbSet Proberly Name match Table Name

            // 2 * Primary key convention [Id, id , ID] , [{Class}id], [{Class}Id], [{Class}ID]


            // 3 * Column Property Mismatch




            using (var context = new AppDbContext())
            {
                Console.WriteLine("-------- Users -----------");
                Console.WriteLine();
                foreach (var user in context.Users)
                {
                    Console.WriteLine(user.Username);
                }
                Console.WriteLine();
                Console.WriteLine("-------- Tweets -----------");
                Console.WriteLine();
                foreach (var tweet in context.Tweets)
                {
                    Console.WriteLine(tweet.TweetText);
                }
                Console.WriteLine();
                Console.WriteLine("-------- Comments -----------");
                Console.WriteLine();
                foreach (var comment in context.Comments)
                {
                    Console.WriteLine(comment.CommentText);
                }

            }


        }

    }
}
