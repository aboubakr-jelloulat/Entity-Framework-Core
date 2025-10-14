using _02_EF_Core_DbContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_EF_Core_DbContext.DbContextParametreLessConstractor
{
    internal class clsDbContextParametreLessConstractor
    {

        public class AppDbContext : DbContext
        {

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);

                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = config.GetSection("constr").Value;

                optionsBuilder.UseSqlServer(connectionString); // provider
            }

            public DbSet<Wallet> Wallets { get; set; } = null!;
        }
        public static void DbContextParametreLessConstractorMethode()
        {


            Console.WriteLine("Using This Way see the comments : \n");




            using (var context = new AppDbContext())
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }

            }


        }

    }
}

