using ConsoleApp1.Migrations;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp1
{

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
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
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=A1;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
  
        }
    } 
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext db = new MyDbContext())
            {
                foreach (var item in db.Products)
                {
                    Console.WriteLine(item.Name + "    " + item.Age);
                }
            }
        }
    }
}
