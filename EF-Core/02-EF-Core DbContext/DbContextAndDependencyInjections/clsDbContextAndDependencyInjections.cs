using _02_EF_Core_DbContext.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_EF_Core_DbContext.DbContextAndDependencyInjections
{
    internal class clsDbContextAndDependencyInjections
    {

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<Wallet> Wallets { get; set; } = null!;
        }

        public static void DependencyInjections()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionStrng = config.GetSection("constr").Value;

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStrng));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                foreach (var wallet in context!.Wallets)
                {
                    Console.WriteLine(wallet);
                }

            }


        }

    }
}
