using _01_Jump_start.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Jump_start.Retrive_Data
{
    internal class RetriveData
    {

        public static void RetriveDataMethode()
        {

            Console.WriteLine("Retrive Data : \n\n");

            using(var context = new AppDbContext())
            {
                foreach (var item in context.Wallets)
                    Console.WriteLine(item);

            }

            Console.WriteLine("\n\nRerive Single Item : \n");

            int itemId = 2;

            using(var context = new AppDbContext())
            {
                var wallet = context.
                        Wallets.
                        FirstOrDefault(x => x.Id == itemId);

                Console.WriteLine(wallet);
            }
        }

    }
}
