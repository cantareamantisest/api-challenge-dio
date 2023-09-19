using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Models;

namespace SampleRestApi.Mappings
{
    public class FeaturesMap : IEntityTypeConfiguration<Features>
    {
        public void Configure(EntityTypeBuilder<Features> builder)
        {
            builder.ToTable("Features");

            builder.HasKey(c => c.IdFeature);

            builder.Property(c => c.IdFeature)
                .HasColumnType("INTEGER");

            builder.Property(c => c.Icon)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(c => c.Features)
                .HasForeignKey(c => c.IdUser);
        }
    }
}