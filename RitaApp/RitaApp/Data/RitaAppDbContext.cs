using Microsoft.EntityFrameworkCore;
using RitaApp.Data.Models;

namespace RitaApp.Data
{
    public class RitaAppDbContext : DbContext
    {
        public RitaAppDbContext(DbContextOptions<RitaAppDbContext> options) 
            : base(options) 
        {
        }

        public DbSet<Category>Categories => Set<Category>();
        public DbSet<Magazine>Magazines => Set<Magazine>();
        public DbSet<Product>Products => Set<Product>();
        public DbSet<ProductCard>ProductCards => Set<ProductCard>();
        public DbSet<Unit>Units => Set<Unit>();
        public DbSet<User>Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Magazine>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ProductCard>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Unit>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }

    }
}
