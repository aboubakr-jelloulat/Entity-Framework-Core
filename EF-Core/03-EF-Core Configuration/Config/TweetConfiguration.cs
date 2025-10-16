using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static _03_EF_Core_Configuration.ConfigurationByDataAnnotations.clsConfigurationByDataAnnotations;

namespace _03_EF_Core_Configuration.Config
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        void IEntityTypeConfiguration<Tweet>.Configure(EntityTypeBuilder<Tweet> builder)
        {

            builder.ToTable("tblTweets");

        }

    }

}

