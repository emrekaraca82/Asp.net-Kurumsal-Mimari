using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Cart
    {
        List<CartLine> _lines = new List<CartLine>(); //ürün bilgisi ve üründen kaç tane bilgisi getirir
         //quantity adet anlamına gelir
        public void AddToCart(Product product,int quantity)
        {
            CartLine cartLine = _lines.FirstOrDefault(c => c.Product.ProductID == product.ProductID);//sepette bu üründen var mı diye kontrol edilir

            if (cartLine == null) //sepette ürün yoksa ekler
            {
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else //sepette ürün varsa quantity(adet) artttır
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveFormCart(Product product)
        {
            _lines.RemoveAll(p => p.Product.ProductID == product.ProductID); //Sepette seçili ürün siler
        }

        public decimal Total
        {
            get { return _lines.Sum(c => c.Product.UnitPrice * c.Quantity); } //sepetteki toplam fiyat getir
        }

        public void clear()
        {
            _lines.Clear(); //Sepetin tamamını temizler
        }

        public List<CartLine> Lines
        {
            get { return _lines; } //sepetteki tüm ürünleri listeler
        }
    }

    public class CartLine
    {
        public Product Product { get; internal set; }
        public int Quantity { get; internal set; }
    }
}
