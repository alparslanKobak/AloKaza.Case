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
    internal class SliderConfigurations : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x=> x.Title).HasColumnType("nvarchar(50)").HasMaxLength(50);

            builder.Property(x=> x.Description).HasColumnType("nvarchar(500)").HasMaxLength(500);

            builder.Property(x=> x.Link).HasMaxLength(200);

            builder.Property(x=> x.Image).HasMaxLength(100);
        }
    }
}
