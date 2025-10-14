using _02_EF_Core_DbContext.DbContextAndDependencyInjections;
using _02_EF_Core_DbContext.DbContextExternalConfiguration;
using _02_EF_Core_DbContext.DbContextFactory;
using _02_EF_Core_DbContext.DbContextParametreLessConstractor;


namespace _02_EF_Core_DbContext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // clsDbContextParametreLessConstractor.DbContextParametreLessConstractorMethode(); //  Internal


            // clsDbContextExternalConfiguration.DbContextExternalConfigurationMethode(); // External


            // clsDbContextAndDependencyInjections.DependencyInjections();


            // clsDbContextFactory.UsingDbContextFactory();


            // clsDbContextFactory.DbContextLifeTime();


            // clsDbContextFactory.AnotherDbContextConfiguration();

            clsDbContextFactory.DbContextAndConcurrency();






            Console.ReadKey();
        }
    }
}
