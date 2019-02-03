using Microsoft.EntityFrameworkCore;

namespace Shopping.DataAccess
{
    public class ShopContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=MSI\\SQLEXPRESS;Database=Shopping;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=sa;Password=2wsx2WSX");
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
