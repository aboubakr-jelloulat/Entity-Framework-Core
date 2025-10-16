using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static _03_EF_Core_Configuration.ConfigurationByDataAnnotations.clsConfigurationByDataAnnotations;

namespace _03_EF_Core_Configuration.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.ToTable("tblUsers");

        }

    }

}

