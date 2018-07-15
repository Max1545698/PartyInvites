using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp2
{
    class Product
    {
        [Key]
        public int ProdID { get; set; }
        public string  Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
    class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-3SH96SB\SQLEXPRESS;Database=ConsoleApp2DB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
