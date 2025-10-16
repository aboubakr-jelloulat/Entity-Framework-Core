using _03_EF_Core_Configuration.ConfigurationByDataAnnotations;
using _03_EF_Core_Configuration.Convention_Over_Configuration;
using _03_EF_Core_Configuration.Override_Configuration_Using_Fluent_API;
using _03_EF_Core_Configuration.Override_Configuration_Using_Grouping_Configuration;

namespace _03_EF_Core_Configuration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // clsConventionOverConfiguration.ConventionOverConfiguration();


            // clsConfigurationByDataAnnotations.ConfigurationByDataAnnotations();


            // clsOverrideConfigurationUsingFluentAPI.OverrideConfigurationUsingFluentAPI();


            // clsOverrideConfigurationUsingGroupingConfiguration.OverrideConfigurationUsingGroupingConfiguration();

            Console.WriteLine("Call Groupping Configuration From Assembly : has a relation with the last one am3lem"); // akhir part 


            Console.ReadKey();

        }
    }
}

