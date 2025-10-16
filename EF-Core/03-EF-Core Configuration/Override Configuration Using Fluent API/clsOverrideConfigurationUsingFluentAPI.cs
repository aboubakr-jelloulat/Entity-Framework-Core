using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _03_EF_Core_Configuration.Override_Configuration_Using_Fluent_API
{
    internal class clsOverrideConfigurationUsingFluentAPI
    {

        public class User
        {
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
            public int Id { get; set; }
            public int TweetId { get; set; }
            public int CommentBy { get; set; }
            public string CommentText { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class AppDbContext : DbContext
        {

            public DbSet<User> Users { get; set; } = null!;

            public DbSet<Tweet> Tweets { get; set; } = null!;

            public DbSet<Comment> Comments { get; set; } = null!;

            // using Fluent API : best way
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                base.OnModelCreating(modelBuilder);


                modelBuilder.Entity<User>().ToTable("tblUsers");

                modelBuilder.Entity<Tweet>().ToTable("tblTweets");

                modelBuilder.Entity<Comment>().ToTable("tblComments");

                modelBuilder.Entity<Comment>().Property(p => p.Id)
                    .HasColumnName("CommentId");

                modelBuilder.Entity<Comment>().Property(p => p.CommentBy)
                    .HasColumnName("UserId");

            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);

                var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings2.json")
                .Build();

                var connectionString = config.GetSection("constr").Value;

                optionsBuilder.UseSqlServer(connectionString);

            }


        }



        public static void OverrideConfigurationUsingFluentAPI()
        {


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
