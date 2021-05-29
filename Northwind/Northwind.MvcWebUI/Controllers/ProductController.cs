using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private  IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public int PageSize = 5;
        public ViewResult Index(int page=1,int category=0)
        {
            List<Product> products = _productService.GetAll().Where(p=>p.CategoryID==category||category==0).ToList();

             return View(new ProductViewModel
                {
                    Products = products.Skip((page - 1) * PageSize).Take(5).ToList(),
                    PagingInfo = new PagingInfo 
                    {
                        ItemsPerPage = PageSize, //bir sayfadaki eleman sayısı
                        TotalItems = products.Count, // Toplamda eleman sayısı
                        CurrentPage=page, //mevcut bulunduğun sayfa
                        CurrentCategory = category
                    }

                });
        }
    }
}