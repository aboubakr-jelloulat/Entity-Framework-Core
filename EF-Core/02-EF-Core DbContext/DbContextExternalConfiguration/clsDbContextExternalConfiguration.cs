using _02_EF_Core_DbContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_EF_Core_DbContext.DbContextExternalConfiguration
{
    internal class clsDbContextExternalConfiguration
    {
        // Way 2 : External parametrize 
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<Wallet> Wallets { get; set; } = null!;
        }


        public static void   DbContextExternalConfigurationMethode()
        {
            Console.WriteLine("DbContext External Configuration : \n");


            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetSection("constr").Value;

            var optionBuilder = new DbContextOptionsBuilder();

            optionBuilder.UseSqlServer(connectionString);

            var option = optionBuilder.Options; // option :  readonly give you sql server

            using (var context = new AppDbContext(option))
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }

            }

        }

    }
}
