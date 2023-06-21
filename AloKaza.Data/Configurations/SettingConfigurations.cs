using AloKaza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AloKaza.Data.Configurations
{
    internal class SettingConfigurations : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(x=> x.Title).IsRequired().HasColumnType("nvarchar(100)").HasMaxLength(100);

            builder.Property(x => x.Logo).HasMaxLength(100);

            builder.Property(x => x.Favicon).HasMaxLength(100);

            builder.Property(x => x.Description).HasColumnType("nvarchar(500)").HasMaxLength(500);

            builder.Property(x => x.Email).HasMaxLength(100);

            builder.Property(x => x.Phone).HasMaxLength(20);

            builder.Property(x => x.MailServer).HasColumnType("nvarchar(100)").HasMaxLength(100);

            builder.Property(x => x.UserName).HasColumnType("nvarchar(100)").HasMaxLength(100);

            builder.Property(x => x.Password).HasMaxLength(100);
        }
    }
}
