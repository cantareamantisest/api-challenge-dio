using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Models;

namespace SampleRestApi.Mappings
{
    public class NewsMap : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");

            builder.HasKey(c => c.IdNews);

            builder.Property(c => c.IdNews)
                .HasColumnType("INTEGER");

            builder.Property(c => c.Icon)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.HasOne(c => c.User)
                .WithMany(c => c.News)
                .HasForeignKey(c => c.IdUser);
        }
    }
}