using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEmpty.Models
{
    public class ProductService : IProductService
    {
        public void Add()
        {
            Console.Write("Add method  Called");
        }
    }
}