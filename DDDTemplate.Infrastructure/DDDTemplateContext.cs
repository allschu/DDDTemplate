using DDDTemplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDDTemplate.Infrastructure
{
    public class DDDTemplateContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public DDDTemplateContext(DbContextOptions<DDDTemplateContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.OrderLines)
                       .WithOne(x => x.Order)
                       .HasForeignKey(x => x.OrderId);

            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderNr = 1
                });

            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine
                {
                    Id = 1,
                    OrderId = 1,
                    OrderLineName = "OrderLineName1"
                });
        }
    }
}