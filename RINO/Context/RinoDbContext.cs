using Microsoft.EntityFrameworkCore;
using RINO.Models;

namespace RINO.Context
{
    public class RinoDbContext: DbContext
    {
        public RinoDbContext(DbContextOptions<RinoDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; } //load data in DbSet 
        public DbSet<Device> Devices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartItem>()
                .HasKey(sci => sci.ShoppingCartItemId);
        }
    }
   
}
