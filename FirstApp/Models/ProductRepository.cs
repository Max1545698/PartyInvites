using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    public class ProductRepository : IRepository
    {
        IQueryable<Product> products;
        public ProductRepository()
        {
            products = new List<Product>
           {
               new Product{Id = 1, Name = "tennis ball", Price = 19.50M},
               new Product{Id = 2, Name = "Soccer ball", Price = 25.37M},
               new Product{Id = 3, Name = "T-shirt" , Price = 34}
           }.AsQueryable();
        }

        public IQueryable<Product> Products => products;
    }
}
