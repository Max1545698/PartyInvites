using System;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
           using(MyDbContext db = new MyDbContext())
            {
                db.Products.Add(new Product { Name = "AAA", Price = 19.50m });
                db.Products.Add(new Product { Name = "BBB", Price = 20 });
                db.SaveChanges();
            }
        }
    }
}
