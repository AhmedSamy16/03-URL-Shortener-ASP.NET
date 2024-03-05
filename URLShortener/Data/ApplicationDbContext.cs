using Microsoft.EntityFrameworkCore;
using URLShortener.Models;

namespace URLShortener.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortURL>().HasIndex(s => s.Url).IsUnique();
            modelBuilder.Entity<ShortURL>().Property(s => s.Url).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ShortURL> ShortURLs { get; set; }
    }
}
