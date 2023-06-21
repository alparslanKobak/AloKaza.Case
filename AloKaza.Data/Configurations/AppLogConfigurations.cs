using AloKaza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AloKaza.Data.Configurations
{
    internal class AppLogConfigurations : IEntityTypeConfiguration<AppLog>
    {
        public void Configure(EntityTypeBuilder<AppLog> builder)
        {
            builder.Property(x=> x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.SlnDetail).HasMaxLength(300);
        }
    }
}
