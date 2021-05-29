using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult Index(Cart cart)
        {
            return View(cart);
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId)
        {
            Product product = _productService.Get(productId); //seçili ürünü getir        
            cart.AddToCart(product, 1);
            return RedirectToAction("Index",cart);
        }

        public RedirectToRouteResult RemoveToCart(Cart cart,int productId)
        {
            Product product = _productService.Get(productId); //seçili ürünü getir
            cart.RemoveFormCart(product);
            return RedirectToAction("Index",cart);
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid) //burada kullanıcı isim doğru ise complate yanlış ise sayfayı yenileme işlemi yapıyor
            {
                return View("Complate");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult CartSummary(Cart cart)
        {           
            return PartialView(cart);
        }
    }
}