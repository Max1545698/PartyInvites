using AspLanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspLanguageFeatures.Controllers
{

    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            string[] strArr = new string[] { $"Length: {length}" , " I'm nice!" };
            return View(strArr);
        }
    }
}
