

using EcommerceDataAccessLayer.Models;

namespace EcommerceBusinesLogicLayer.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        //public Category Category { get; set; }
        public string CategoryName { get; set; }
    }
    public class CreateProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
    public class UptadeProducDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        //public Category Category { get; set; }
    }
}

