using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SampleRestApi.Models;

namespace SampleRestApi.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(c => c.IdUser);

            builder.Property(c => c.IdUser)
                .HasColumnType("INTEGER");

            builder.Property(c => c.Name)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.HasOne(c => c.Account)
                .WithOne(c => c.User)
                .HasForeignKey<Account>(c => c.IdUser)
                .IsRequired();

            builder.HasOne(c => c.Card)
                .WithOne(c => c.User)
                .HasForeignKey<Card>(c => c.IdUser)
                .IsRequired();
        }
    }
}