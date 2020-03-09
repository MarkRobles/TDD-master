using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDD.Models
{
    public partial class Category
    {


        public List<Product> GetProducts()
        {
            return this.Products.ToList();
        }
    }
}