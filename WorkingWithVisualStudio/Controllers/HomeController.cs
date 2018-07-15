using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
       public IRepository Repository = SimpleRepository.SharedRepository;

        [HttpGet]
        public IActionResult Index() => View(Repository.Products
            .Where(p => p.Price < 50));

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new Product());
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            Repository.AddProduct(p);
            return RedirectToAction("Index");
        }
    }
}