using DemoApp1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp1.Data
{
   public class ShopingProductsContext:DbContext
    {
        public ShopingProductsContext()
        {

        }
        public ShopingProductsContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(x => x.Id).HasName("PK_Test");
            base.OnModelCreating(modelBuilder);
        }
    }
}
