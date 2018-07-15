using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    public class CategoryListViewModel
    {
        public string CurrentCategory { get; set; }
       public IQueryable<string> Categories { get; set; }
    }
}
