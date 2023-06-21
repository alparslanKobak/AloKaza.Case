using AloKaza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AloKaza.Data.Configurations
{
    internal class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x=> x.Image).HasMaxLength(100);

            builder.Property(x => x.FullName).IsRequired().HasColumnType("nvarchar(100)").HasMaxLength(100);

            builder.Property(x => x.Email).IsRequired().HasColumnType("nvarchar(100)").HasMaxLength(100);

            builder.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(70)").HasMaxLength(70);

            builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);

        }
    }
}
