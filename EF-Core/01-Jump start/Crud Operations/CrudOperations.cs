using _01_Jump_start.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Jump_start.Crud_Operations
{
    internal class CrudOperations
    {

        public static void InsertData()
        {
            var wallet = new Wallet
            {
                Holder = "Sander Boss",
                Balance = 1000

            };

            using (var context = new AppDbContext())
            {
                context.Wallets.Add(wallet); // only we add it in memory

                context.SaveChanges();   // save it in database 
            }

        }


        public static void UpdateData()
        {

            using (var context = new AppDbContext())
            {
                // update wallete with id = 4

                var wallet = context.Wallets.Single(w => w.Id == 4);

                wallet.Balance = 7000;

                context.SaveChanges();

            }

        }


        public static void DeleteData()
        {
            using (var context = new AppDbContext())
            {
                // delete wallet with id = 5

                var wallet = context.Wallets.Single(w => w.Id == 5);

                context.Wallets.Remove(wallet);

                context.SaveChanges();

            }
        }

        public static void QueryData()
        {
            // all wallets with balance > 5000;

            using (var context = new AppDbContext())
            {
                var result = context.Wallets.Where(w => w.Balance > 5000);

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

            }

        }


        // A way to make sure a group of database operations either all succeed or all fail together.
        public static void DataBaseTransactions()
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    // transfer 500$ from wallet id = 1 to id = 4;


                    var fromwallet = context.Wallets.Single(w => w.Id == 1);

                    var Towallet = context.Wallets.Single(w => w.Id == 4);

                    var amount = 500m;

                    // operation 1 : withdraw 500 from 

                    fromwallet.Balance -= amount;

                    context.SaveChanges();

                    // operation 2 : deposit 500 to wallet id = 4;


                    Towallet.Balance += amount;

                    context.SaveChanges();




                    transaction.Commit();
                }

            }


        }


    }
}
