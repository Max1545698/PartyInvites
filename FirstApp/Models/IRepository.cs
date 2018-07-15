using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    public interface IRepository
    {
         IQueryable<Product> Products { get; }
    }
}
