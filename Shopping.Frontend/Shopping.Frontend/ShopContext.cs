using Microsoft.EntityFrameworkCore;

namespace Shopping.Frontend
{
    public class ShopContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Device> Devices { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.HasDefaultSchema("Shopping");
            modelBuilder.Entity<Book>()
                .HasKey(b => b.ProductIdentificator);
            modelBuilder.Entity<Device>()
                .HasKey(b => b.ProductIdentificator);

            modelBuilder.Entity<Book>()
                .Property(b => b.Name).HasMaxLength(30);

        }

    }
}
