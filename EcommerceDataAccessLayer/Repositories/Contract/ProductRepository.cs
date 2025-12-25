using EcommerceDataAccessLayer.DataContext;
using EcommerceDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDataAccessLayer.Repositories.Contract
{
    public class ProductRepository : IProductRepository
    {
        private static readonly EcommerceDataBase _database = new EcommerceDataBase();
        public void Add(Product entity)
        {
            EcommerceDataBase.Products.Add(entity);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product is not null)
            {
                EcommerceDataBase.Products.Remove(product);
                return;
            }
            throw new Exception("Product Not Found");
         }

        public Product? GetById(int id)
        {
            var product = EcommerceDataBase.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        public List<Product> GetAll()
        {
            return EcommerceDataBase.Products;
        }

      
        public void Update(int id, Product product)
        {

           var existingProduct = GetById(id);
            if (existingProduct is not null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
                return;
            }
            throw new Exception("Product Not Found");
        }
    }
}
