using System.Collections.Generic;
using Northwind.Entities;

namespace Northwind.MvcWebUI.Models
{
    public class ProductViewModel
    {
        public PagingInfo PagingInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}