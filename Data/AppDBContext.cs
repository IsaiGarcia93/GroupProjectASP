using GroupProjectASP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProjectASP.Data
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderDetails> OrdersDetail { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<OrderDetails>().HasKey(od => new { od.OrderID, od.ItemID });
            builder.Entity<OrderDetails>().HasOne(O => O.Order).WithMany(od => od.OrderDetails).HasForeignKey(o => o.OrderID);
            builder.Entity<OrderDetails>().HasOne(i => i.Item).WithMany(od => od.OrderDetails).HasForeignKey(i => i.ItemID);

            builder.Entity<Item>().HasData(
                new Item {
                    ItemID = 1,
                    Title = "The Scream",
                    Description = "Beautiful Art Work",
                    DateOfCreation = new DateTime(1950,5,16),
                    Price = 5000.00,
                    ImageUpload = "Art1.jpg"
                },
                new Item {
                    ItemID = 2,
                    Title = "The Woman on the Wall",
                    Description = "Amazing Art Work",
                    DateOfCreation = new DateTime(1650,8,6),
                    Price = 15000.00,
                    ImageUpload = "Art2.jpg"
                });
            
            builder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    FirstName = "Isai",
                    LastName = "Gonzalez",
                    Address = "123 Adams St.",
                    City = "Lincoln",
                    State = "NE",
                    Zip = "68507",
                    OrderDate = new DateTime (2022,4,5),
                    TotalPrice = 15000.00
                }, new Order
                {
                    OrderID = 2,
                    FirstName = "Kris",
                    LastName = "Haskin",
                    Address = "123 Garland St.",
                    City = "Lincoln",
                    State = "NE",
                    Zip = "68507",
                    OrderDate = new DateTime(2022, 6, 25),
                    TotalPrice = 5000.00
                });
                
                builder.Entity<OrderDetails>().HasData(
                new OrderDetails
                {
                    OrderID = 1,                    
                    ItemID = 2,
                    Quantity = 1,
                    Amount = 15000.00
                }, new OrderDetails
                {
                    OrderID = 2,
                    ItemID = 1,
                    Quantity = 1,
                    Amount = 5000.00
                });
        }
    }
}
