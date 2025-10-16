using _02_EF_Core_DbContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_EF_Core_DbContext.DbContextFactory
{


    internal class clsDbContextFactory
    {


        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<Wallet> Wallets { get; set; } = null!;
        }

        public static void UsingDbContextFactory()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionStrng = config.GetSection("constr").Value;

            var services = new ServiceCollection();

            services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionStrng));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var contextFactory = serviceProvider.GetService<IDbContextFactory<AppDbContext>>();

            using (var context = contextFactory!.CreateDbContext())
            {
                foreach (var wallet in context!.Wallets)
                {
                    Console.WriteLine(wallet);
                }

            }


        }



        public static void DbContextLifeTime()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            var optionBuilder = new DbContextOptionsBuilder();

            optionBuilder.UseSqlServer(connectionString);

            var option = optionBuilder.Options;

            using (var context = new AppDbContext(option))
            {
                var w1 = new Wallet { Holder = "Sander", Balance = 5000m };

                context.Wallets.Add(w1);

                var w2 = new Wallet { Holder = "Vini", Balance = 800m };

                context.Wallets.Add(w2);

                context.SaveChanges();


                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }


            }



        }


        public static void AnotherDbContextConfiguration()
        {
            // 1. Load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // 2. Read connection string (make sure your appsettings.json has "constr": "..." )
            var connectionString = config.GetSection("constr").Value;

            // 3. Create strongly typed DbContext options builder
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // 4. Configure SQL Server and enable query logging to the console
            // "LogTo" prints all SQL commands EF Core executes.
            // LogLevel.Information = show detailed SQL and parameter values
            optionBuilder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);

            // 5. Build the options object
            var options = optionBuilder.Options;

            // 6. Use the context
            using (var context = new AppDbContext(options))
            {
                var w1 = new Wallet { Holder = "Sander", Balance = 5000m };
                var w2 = new Wallet { Holder = "Vini", Balance = 800m };


                context.Wallets.Add(w1);
                context.Wallets.Add(w2);

                context.SaveChanges();

                // 7. Print all wallets in the table
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }


        static AppDbContext context;
        private static async Task job1()
        {
            var w1 = new Wallet { Holder = "Jolia", Balance = 1500m };

            context.Wallets.Add(w1);

            await context.SaveChangesAsync();
        }

        private static async Task job2()
        {
            var w1 = new Wallet { Holder = "Karla", Balance = 1700m };

            context.Wallets.Add(w1);

            await context.SaveChangesAsync();
        }


        // is not work you can see another way 
        public static void DbContextAndConcurrency()
        {


            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionStrng = config.GetSection("constr").Value;

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStrng));

            IServiceProvider serviceProvider = services.BuildServiceProvider();


             context = serviceProvider.GetRequiredService<AppDbContext>();


            var Tasks = new[]
            {
                Task.Factory.StartNew(() => job1()),
                Task.Factory.StartNew(() => job2())
            };


            Task.WhenAll(Tasks).ContinueWith(t =>
            {
                Console.WriteLine("job1 and job2 execute concurrently");
            }).Wait(); 


            //using (var context = serviceProvider.GetService<AppDbContext>())
            //{
            //    foreach (var wallet in context!.Wallets)
            //    {
            //        Console.WriteLine(wallet);
            //    }

            //}

        }

    }
}
