using KaspiTask.Models;
using Microsoft.EntityFrameworkCore;

namespace KaspiTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderInfo> OrderInfo { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(o => o.Info);
            
            builder.Entity<Order>()
                .HasOne(o => o.Status);
            
            builder.Entity<OrderHistory>()
                .HasOne(oh => oh.Order)
                .WithMany(o => o.History)
                .HasForeignKey(oh => oh.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(po => po.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}