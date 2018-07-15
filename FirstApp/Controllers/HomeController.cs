using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {

        public int Sum(int a, int b) => a + b;

        public ViewResult Index()
        {
            ProductRepository repository = new ProductRepository();
            ViewBag.Products = repository.Products;
            return View("ListOfProducts");
        }
        //public ViewResult ListOfProducts()
        //{
            
        //    return View(repository.Products);
        //}
    }
}
