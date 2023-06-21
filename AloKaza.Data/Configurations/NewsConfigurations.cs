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
    internal class NewsConfigurations : IEntityTypeConfiguration<News>
    {
      

        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Image).HasMaxLength(100);
        }
    }
}
