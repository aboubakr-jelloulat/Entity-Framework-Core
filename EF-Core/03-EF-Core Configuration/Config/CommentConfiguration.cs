using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static _03_EF_Core_Configuration.ConfigurationByDataAnnotations.clsConfigurationByDataAnnotations;

namespace _03_EF_Core_Configuration.Config
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        void IEntityTypeConfiguration<Comment>.Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.ToTable("tblComments");

        }

    }

}

