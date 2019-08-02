
using Microsoft.EntityFrameworkCore;

namespace APITest.Models
{
    public class APITestContext : DbContext
    {
        public APITestContext(DbContextOptions<APITestContext> options) : base(options)
        {
        }

        public DbSet<UserObject> Users { get; set; }
        public DbSet<CreditCardObject> CreditCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserObject>().ToTable("Users");
            modelBuilder.Entity<CreditCardObject>().ToTable("CreditCards");
        }

    }
}