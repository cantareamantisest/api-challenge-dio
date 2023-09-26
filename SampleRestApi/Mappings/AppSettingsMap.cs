using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Models;

namespace SampleRestApi.Mappings
{
    public class AppSettingsMap : IEntityTypeConfiguration<AppSettings>
    {
        public void Configure(EntityTypeBuilder<AppSettings> builder)
        {
            builder.ToTable("AppSettings");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnType("INTEGER");

            builder.Property(c => c.Hostname)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(c => c.Username)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(c => c.Password)
                .HasColumnType("TEXT")
                .IsRequired();
        }
    }
}