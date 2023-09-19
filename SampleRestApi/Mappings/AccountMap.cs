using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Models;

namespace SampleRestApi.Mappings
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(c => c.IdAccount);

            builder.Property(c => c.IdAccount)
                .HasColumnType("INTEGER");

            builder.Property(c => c.Number)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(c => c.Agency)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(c => c.Balance)
               .HasColumnType("REAL")
               .IsRequired();

            builder.Property(c => c.Limit)
               .HasColumnType("REAL")
               .IsRequired();
        }
    }
}