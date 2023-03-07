using DDDWebapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDWebapi.Infrastructure.Objects
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().Property(x => x.CustomerName).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.OrderDate).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.TotalAmount).IsRequired();
        }
    }
}
