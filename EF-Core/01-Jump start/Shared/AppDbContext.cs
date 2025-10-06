using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Jump_start.Shared
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("Appsettings.json").Build();

            var constr = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
        }

        public DbSet<Wallet> Wallets { get; set; }


    }


}

