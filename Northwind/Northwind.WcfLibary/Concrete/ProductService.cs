using Northwind.Interfaces;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;

namespace Northwind.WcfLibary.Concrete
{
    public class ProductService : IProductService
    {
        ProductManger _productManger = new ProductManger(new EfProductDal());

        public void Add(Product product)
        {
            _productManger.Add(product);
        }

        public void Delete(int productId)
        {
            _productManger.Delete(productId);
        }

        public Product Get(int productId)
        {
            return _productManger.Get(productId);
        }

        public List<Product> GetAll()
        {
            return _productManger.GetAll();
        }

        public void Update(Product product)
        {
            _productManger.Update(product);
        }
    }
}
