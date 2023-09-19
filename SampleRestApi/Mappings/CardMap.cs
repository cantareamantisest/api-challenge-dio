using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Models;

namespace SampleRestApi.Mappings
{
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Card");

            builder.HasKey(c => c.IdCard);

            builder.Property(c => c.IdCard)
                .HasColumnType("INTEGER");

            builder.Property(c => c.Number)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(c => c.Limit)
               .HasColumnType("REAL")
               .IsRequired();
        }
    }
}