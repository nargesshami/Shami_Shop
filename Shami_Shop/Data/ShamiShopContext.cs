using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shami_Shop.Models;

namespace Shami_Shop.Data
{
    public class ShamiShopContext: DbContext
    {
        public ShamiShopContext(DbContextOptions<ShamiShopContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        Random r=new Random();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int num = r.Next(100000);
            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("Money");
                i.HasKey(w => w.Id);
            });
            modelBuilder.Entity<Item>().HasData(new Item()
            {
                Id = 1,
                Price = 854.0M,
                QuantityInStock = 5
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                ItemId = 1,
                Name = "محصول شماره 1",
                Description = "این محصول تستی است"
            });
            modelBuilder.Entity<Users>().HasData(new Users()
            {
                UserId = 1,
                MobilePhone = "09372246289",
                Password = num.ToString(),
                IsAdmin = true
            }) ;
        }
    }
}
