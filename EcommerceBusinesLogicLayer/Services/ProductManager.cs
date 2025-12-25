using EcommerceBusinesLogicLayer.Dtos;
using EcommerceBusinesLogicLayer.Services.Contracts;
using EcommerceDataAccessLayer.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceDataAccessLayer.Models;
namespace EcommerceBusinesLogicLayer.Services
{
    
    public class ProductManager : IProductServices
    {
        private readonly IProductRepository _services;
        private readonly ICategoryRepository _categoryRepository;
        public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository)

        {
            _services = productRepository;
            _categoryRepository = categoryRepository;
        }



        public void AddProduct(CreateProductDto createProduct)
        {
            var category = _categoryRepository.GetById(createProduct.CategoryId);

            if (category == null)
            {
                throw new Exception($"Category with ID {createProduct.CategoryId} not found!");
            }
            _services.Add(new Product
            {
                Id = createProduct.Id,
                Name = createProduct.Name,
                Price = createProduct.Price,
                Category = category

            });
        }

     

        public void DeleteProduct(int id)
        {
            _services.Delete(id);
        }

        public ProductDto? GetProductById(int id)
        {
            var products = _services.GetById(id);
            if(products is null)
            {
                return null;
            }
            return new ProductDto
            {
                Id = id,
                Name = products.Name,
                Price = products.Price,
                CategoryName = products.Category?.Name ?? "No Category"
            };

        }

        public List<ProductDto> GetProducts()
        {
            var products = _services.GetAll();
            return products.Select(products => new ProductDto
            {
                Id = products.Id,
                Name = products.Name,
                Price = products.Price,
                CategoryName = products.Category?.Name ?? "No Category"
            }).ToList();
        }

        public void UpdateProduct(int id, decimal price, UptadeProducDto uptadeProduct)
        {
            var category = _categoryRepository.GetById(uptadeProduct.CategoryId);

            if (category == null)
            {
                throw new Exception("Category not found!");
            }
            var product = new Product
            {
                Name = uptadeProduct.Name,
                Price = (decimal)uptadeProduct.Price,
                Category = category
            };
            _services.Update(id, product);
        }

        //public void UpdateProduct(int id, UptadeProducDto uptadeProducDto)
        //{
        // var categor = _categoryRepository.GetById(uptadeProducDto.CategoryId);
        //    if(categor == null)
        //    {
        //        throw new Exception("Ctegory Not Found");
        //    }
        //    var product = new Product
        //    {
        //        Name = uptadeProducDto.Name,
        //        Price = uptadeProducDto.Price,
        //        Category = categor
        //    };
        //}

        //public void UpdateProduct(int id, decimal price, UptadeProducDto uptadeProduct)
        //{

        //}
    }
}
