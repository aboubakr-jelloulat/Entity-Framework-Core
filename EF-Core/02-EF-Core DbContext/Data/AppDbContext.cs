using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02_EF_Core_DbContext.Data
{
    // Way 1 : ParametreLessConstractor 


    //public class AppDbContext : DbContext
    //{
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        base.OnConfiguring(optionsBuilder);

    //        var config = new ConfigurationBuilder()
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var connectionString = config.GetSection("constr").Value;

    //        optionsBuilder.UseSqlServer(connectionString); // provider
    //    }

    //    public DbSet<Wallet> Wallets { get; set; } = null!;
    //}



    // Way 2 : External parametrize 

    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions options) : base(options)
       {

       }

        public DbSet<Wallet> Wallets { get; set; } = null!;
    }

}

