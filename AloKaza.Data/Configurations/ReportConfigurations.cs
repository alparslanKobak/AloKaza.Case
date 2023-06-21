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
    internal class ReportConfigurations : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(x=> x.Title).IsRequired().HasColumnType("nvarchar(100)").HasMaxLength(100);

            builder.Property(x=> x.Description).IsRequired().HasColumnType("nvarchar(600)").HasMaxLength(600);

            builder.HasOne(x=> x.AppUser).WithMany(x=> x.Reports).HasForeignKey(x=> x.AppUserId);
        }
    }
}
