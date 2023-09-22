﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleRestApi.Data;

#nullable disable

namespace SampleRestApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("SampleRestApi.Models.Account", b =>
                {
                    b.Property<long>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Agency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Balance")
                        .HasColumnType("REAL");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Limit")
                        .HasColumnType("REAL");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdAccount");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("SampleRestApi.Models.Card", b =>
                {
                    b.Property<long>("IdCard")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Limit")
                        .HasColumnType("REAL");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdCard");

                    b.HasIndex("IdUser")
                        .IsUnique();

                    b.ToTable("Card", (string)null);
                });

            modelBuilder.Entity("SampleRestApi.Models.Features", b =>
                {
                    b.Property<long>("IdFeature")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdFeature");

                    b.HasIndex("IdUser");

                    b.ToTable("Features", (string)null);
                });

            modelBuilder.Entity("SampleRestApi.Models.News", b =>
                {
                    b.Property<long>("IdNews")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdNews");

                    b.HasIndex("IdUser");

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("SampleRestApi.Models.User", b =>
                {
                    b.Property<long>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdUser");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("SampleRestApi.Models.Account", b =>
                {
                    b.HasOne("SampleRestApi.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("SampleRestApi.Models.Account", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SampleRestApi.Models.Card", b =>
                {
                    b.HasOne("SampleRestApi.Models.User", "User")
                        .WithOne("Card")
                        .HasForeignKey("SampleRestApi.Models.Card", "IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SampleRestApi.Models.Features", b =>
                {
                    b.HasOne("SampleRestApi.Models.User", "User")
                        .WithMany("Features")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SampleRestApi.Models.News", b =>
                {
                    b.HasOne("SampleRestApi.Models.User", "User")
                        .WithMany("News")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SampleRestApi.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Card")
                        .IsRequired();

                    b.Navigation("Features");

                    b.Navigation("News");
                });
#pragma warning restore 612, 618
        }
    }
}
