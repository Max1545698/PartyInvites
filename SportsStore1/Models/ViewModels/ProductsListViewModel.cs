using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore1.Models;

namespace SportsStore1.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
