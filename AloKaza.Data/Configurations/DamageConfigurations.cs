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
    internal class DamageConfigurations : IEntityTypeConfiguration<Damage>
    {
        public void Configure(EntityTypeBuilder<Damage> builder)
        {
            builder.Property(x=> x.Title).HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x=> x.Image).HasMaxLength(100);

            builder.HasOne(x=> x.Report).WithMany(x=> x.DamageRecords).HasForeignKey(x=> x.ReportId);
        }
    }
}
