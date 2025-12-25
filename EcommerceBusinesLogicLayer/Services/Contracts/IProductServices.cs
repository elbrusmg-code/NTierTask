using EcommerceBusinesLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBusinesLogicLayer.Services.Contracts
{
    public interface IProductServices
    {
        List<ProductDto> GetProducts();
        ProductDto? GetProductById(int id);
        void AddProduct(CreateProductDto createProduct);
        void UpdateProduct(int id, decimal price, UptadeProducDto uptadeProduct);
        void DeleteProduct(int id);
    }
}
