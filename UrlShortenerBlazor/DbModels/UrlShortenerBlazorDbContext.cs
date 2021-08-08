using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace UrlShortenerBlazor.DbModels
{
    public class UrlShortenerBlazorDbContext : DbContext
    {

        public UrlShortenerBlazorDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>()
                .HasIndex(i => i.FullUrl)
                .IsUnique();

            modelBuilder.Entity<ShortenedUrl>()
                .HasIndex(i => i.Short)
                .IsUnique();
        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
}
