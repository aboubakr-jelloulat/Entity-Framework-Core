using _03_EF_Core_Configuration.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03_EF_Core_Configuration.Override_Configuration_Using_Grouping_Configuration
{
    internal partial class clsOverrideConfigurationUsingGroupingConfiguration
    {

        public class AppDbContext : DbContext
        {

            public DbSet<User> Users { get; set; } = null!;

            public DbSet<Tweet> Tweets { get; set; } = null!;

            public DbSet<Comment> Comments { get; set; } = null!;

            // using Fluent API : best way
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                base.OnModelCreating(modelBuilder);

                ((IEntityTypeConfiguration<User>) new UserConfiguration()).Configure(modelBuilder.Entity<User>());

                ((IEntityTypeConfiguration<Comment>) new CommentConfiguration()).Configure(modelBuilder.Entity<Comment>());

                ((IEntityTypeConfiguration<Tweet>) new TweetConfiguration()).Configure(modelBuilder.Entity<Tweet>());

                // or you can use 

                //  public void Configure(EntityTypeBuilder<User> builder) 
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


        public static void OverrideConfigurationUsingGroupingConfiguration()
        {

            Console.WriteLine("KHass tfra9  Entity am3lem dak chi mkhreba9 odakhla fih lmirikan am3lem");



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
