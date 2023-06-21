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
    internal class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x => x.Surname).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x => x.Email).IsRequired().HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x => x.Phone).HasMaxLength(20);

            builder.Property(x => x.Message).HasMaxLength(500);
        }
    }
}
