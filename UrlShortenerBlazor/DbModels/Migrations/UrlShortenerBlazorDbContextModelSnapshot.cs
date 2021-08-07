﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortenerBlazor.DbModels;

namespace UrlShortenerBlazor.DbModels.Migrations
{
    [DbContext(typeof(UrlShortenerBlazorDbContext))]
    partial class UrlShortenerBlazorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("UrlShortenerBlazor.DbModels.ShortenedUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Short")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FullUrl")
                        .IsUnique();

                    b.HasIndex("Short")
                        .IsUnique();

                    b.ToTable("ShortenedUrls");
                });

            modelBuilder.Entity("UrlShortenerBlazor.DbModels.UrlVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShortenedUrlId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VisitedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("VisitedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShortenedUrlId");

                    b.ToTable("UrlVisit");
                });

            modelBuilder.Entity("UrlShortenerBlazor.DbModels.UrlVisit", b =>
                {
                    b.HasOne("UrlShortenerBlazor.DbModels.ShortenedUrl", "ShortenedUrl")
                        .WithMany("UrlVisits")
                        .HasForeignKey("ShortenedUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShortenedUrl");
                });

            modelBuilder.Entity("UrlShortenerBlazor.DbModels.ShortenedUrl", b =>
                {
                    b.Navigation("UrlVisits");
                });
#pragma warning restore 612, 618
        }
    }
}
