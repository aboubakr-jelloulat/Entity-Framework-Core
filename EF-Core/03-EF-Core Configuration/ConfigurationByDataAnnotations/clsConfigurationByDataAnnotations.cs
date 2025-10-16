using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _03_EF_Core_Configuration.ConfigurationByDataAnnotations
{
    internal class clsConfigurationByDataAnnotations
    {
        [Table("tblUsers")]
        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; }
        }

        // add table attribute
        [Table("tblTweets")]
        public class Tweet
        {
            public int TweetId { get; set; }
            public int UserId { get; set; }
            public string TweetText { get; set; }
            public DateTime CreatedAt { get; set; }
        }


        [Table("tblComments")]
        public class Comment
        {
            [Column("CommentId")] // ila kan mbdel 
            public int Id { get; set; }
            public int TweetId { get; set; }
            public int UserId { get; set; }
            public string CommentText { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class AppDbContext : DbContext
        {

            public DbSet<User> Users { get; set; } = null!;

            public DbSet<Tweet> Tweets { get; set; } = null!;

            public DbSet<Comment> Comments { get; set; } = null!;


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

        public static void ConfigurationByDataAnnotations()
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
