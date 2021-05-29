using Northwind.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        NorthwindContext _context = new NorthwindContext();
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(p => p.ProductID == productId));
            _context.SaveChanges();
        }

        public Product Get(int productId)
        {
            return _context.Products.Where(p => p.ProductID == productId).FirstOrDefault();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            Product _productUpdate = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);
            _productUpdate.ProductName = product.ProductName;
            _productUpdate.CategoryID = product.CategoryID;
            _productUpdate.UnitPrice = product.UnitPrice;            
            _context.SaveChanges();
        }
    }
}
