﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository : IRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            Product[] prodArr = new Product[]
            {
                new Product{Name = "Kayack", Price = 275M},
                new Product{Name = "Lifejacket", Price = 48.95M},
                new Product{Name = "Soccer ball", Price = 19.50M},
                new Product{Name = "Corner flag", Price = 34.95M}
            };
            AddProducts(prodArr);
          //  products.Add("Error", null);
        }

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product p)
        {
            products.Add(p.Name, p);
        }
        public void AddProducts(IEnumerable<Product> products)
        {
            foreach (Product p in products)
            {
                this.products.Add(p.Name, p);
            }
        }
    }
}
